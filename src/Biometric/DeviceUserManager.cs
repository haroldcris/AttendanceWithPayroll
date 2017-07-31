using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTech.Biometric
{
    public class DeviceUserManager
    {
        public enum Privilege
        {
            CommonUser = 0,
            Enroller = 1,
            Administrator = 2,
            SuperAdmin = 3
        }

        public IEnumerable<DeviceUser> Items;

        protected ICollection<DeviceUser> ListOfUsers;
        protected Device _Device;

        public DeviceUserManager(Device device)
        {
            _Device = device;

            ListOfUsers = new List<DeviceUser>();
            Items = ListOfUsers;
        }


        public void Add(DeviceUser user)
        {
            ListOfUsers.Add(user);
        }

        public void AddRange(IEnumerable<DeviceUser> users)
        {
            foreach (var item in users)
            {
                ListOfUsers.Add(item);
            }
        }

        public void Remove(DeviceUser user)
        {
            ListOfUsers.Remove(user);
        }

        /// <summary>
        /// Must Issue SaveChangesToDevice
        /// </summary>
        public void ClearAllUsers()
        {
            if (!_Device.IsConnected) throw new InvalidOperationException("Not Connected");

            //ClearAllUserActivated = true;
            /*
            1 - Attendance Record
            2 - FingerPrint Template Data
            3 - None
            4 - Operation Record
            5 - User Information
            */

            var result = false;
            result = _Device.ZApi.ClearData(_Device.MachineId, 2) &&
                     _Device.ZApi.ClearData(_Device.MachineId, 5);

            if (!result)
            {
                int errorCode = 0;
                _Device.ZApi.GetLastError(ref errorCode);
                throw new Exception("Device Error " + errorCode);
            }
        }



    }
}

