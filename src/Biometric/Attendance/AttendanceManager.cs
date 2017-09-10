using System;
using System.Collections.Generic;

namespace Biometric
{
    public class AttendanceManager
    {
        protected ICollection<Attendance> ListOfItems;
        protected Device _Device;
        public IEnumerable<Attendance> Items;

        public AttendanceManager(Device device)
        {
            _Device = device;
            ListOfItems = new List<Attendance>();
            Items = ListOfItems;
        }

        public void Add(Attendance item)
        {
            ListOfItems.Add(item);
        }

        /// <summary>
        /// Clear Device Log Entry
        /// </summary>
        public void ClearDataLog()
        {
            if (!_Device.IsConnected) throw new InvalidOperationException("Not Connected");

            int errorCode = 0;
            string platform = _Device.GetPlatform();

            //var result = false;

            switch (platform)
            {
                case DevicePlatform.ZEM560: //Mr. Sy
                    if (!_Device.ZApi.ClearGLog(_Device.MachineId))
                    {
                        _Device.ZApi.GetLastError(errorCode);
                        throw new Exception("Device Error " + errorCode);
                    }
                    break;

                default:
                    if (!_Device.ZApi.ClearGLog(_Device.MachineId))
                    {
                        _Device.ZApi.GetLastError(errorCode);
                        throw new Exception("Device Error " + errorCode);
                    }
                    break;
            }

        }


        /// <summary>
        /// Read Device Log
        /// </summary>
        public void ReadDataLog()
        {
            if (!_Device.IsConnected) throw new InvalidOperationException("Not Connected");

            int errorCode = 0;
            string platform = _Device.GetPlatform();

            if (!_Device.ZApi.ReadGeneralLogData(_Device.MachineId))
            {
                _Device.ZApi.GetLastError(errorCode);
                throw new Exception("Device Error " + errorCode);
            }

            bool result = true;
            int iMachineId = _Device.MachineId, biometricId = 0, enrollId = 0, verifyMode = 0, inOutMode = 0, year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0, workCode = 0;
            string sEnrollId = "";

            while (result)
            {

                switch (platform)
                {
                    case "ZEM560": //Mr. Sy
                        result = _Device.ZApi.GetGeneralLogData(iMachineId, ref iMachineId, ref enrollId, ref iMachineId, ref verifyMode,
                                                                ref inOutMode, ref year, ref month, ref day, ref hour, ref minute);
                        biometricId = enrollId;
                        break;

                    default:
                        result = _Device.ZApi.SSR_GetGeneralLogData(_Device.MachineId, out sEnrollId, out verifyMode,
                            out inOutMode, out year, out month, out day, out hour, out minute, out second, ref workCode);
                        biometricId = Convert.ToInt32(sEnrollId);
                        break;
                }

                if (result)
                {

                    var item = new Attendance();
                    item.BiometricId = biometricId;
                    item.Station = String.IsNullOrEmpty(_Device.DeviceName) ? _Device.IpAddress : _Device.DeviceName;
                    //item.EntryType = inOutMode == 0 ? "Out" : "In";
                    item.EntryType = inOutMode == 0 ? "In" : "Out";

                    item.TimeLog = new DateTime(year, month, day, hour, minute, second);

                    ListOfItems.Add(item);
                }
            }
        }
    }
}
