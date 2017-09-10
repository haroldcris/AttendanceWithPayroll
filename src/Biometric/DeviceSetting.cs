using System;
using zkemkeeper;

namespace Biometric
{
    public class DeviceSetting
    {
        private Device _Device;
        private CZKEMClass ZApi;

        public DeviceSetting(Device device)
        {
            _Device = device;
            ZApi = device.ZApi;
        }

        public void ClearAdminAccount()
        {
            _Device.CheckConnection();
            ZApi.ClearAdministrators(_Device.MachineId);
        }


        public void SyncDateAndTimeFromPC()
        {
            _Device.CheckConnection();

            if (!ZApi.SetDeviceTime(_Device.MachineId))
            {
                int errorCode = 0;
                ZApi.GetLastError(ref errorCode);
                throw new Exception("Device Error " + errorCode);
            }

            ZApi.RefreshData(_Device.MachineId);
        }

        public bool SetDateAndTime(DateTime data)
        {
            _Device.CheckConnection();

            if (!ZApi.SetDeviceTime2(_Device.MachineId, data.Year, data.Month, data.Day, data.Hour, data.Minute, data.Second))
            {
                int errorCode = 0;
                ZApi.GetLastError(ref errorCode);
                throw new Exception("Device Error " + errorCode);
            }

            ZApi.RefreshData(_Device.MachineId);
            return true;
        }

        public DateTime GetCurrentTime()
        {
            _Device.CheckConnection();

            int idwErrorCode = 0;

            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;

            if (!ZApi.GetDeviceTime(_Device.MachineId, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond))
            {
                ZApi.GetLastError(ref idwErrorCode);
                throw new Exception("Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            return new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
        }
    }
}
