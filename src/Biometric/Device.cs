using System;
using zkemkeeper;
using System.Runtime.InteropServices;

namespace AiTech.Biometric
{
    [ComVisible(true)]
    public class Device
    {
        internal CZKEMClass ZApi;

        public event EventHandler Disconnected;
        public event EventHandler Connected;
        public event EventHandler FingerIsPlaced;

        public event EventHandler<TransactionEventArgs> TransactionEvent;

        public int MachineId { get; set; }
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public bool IsConnected { get; private set; }

        public DeviceSetting Settings { get; }

        //public DeviceUserManager Users { get; set; }
        //public AttendanceManager Attendance { get; set; }

        public Device( string ipAddress)
        {
            MachineId = 1;
            ZApi = new CZKEMClass();

            Settings = new DeviceSetting(this);
            //Users = new DeviceUserManager(this);
            //Attendance = new AttendanceManager(this);

            //RegisterEvent();
            ZApi.BASE64 = 0;

            IpAddress = ipAddress;
        }

        private void RegisterEvent()
        {
            //if (!IsConnected) return;
            //if (!ZApi.RegEvent(MachineId, 65535)) return false;

            if (!ZApi.RegEvent (MachineId, 1)) throw new Exception("Events NOt Registered");

            Console.WriteLine("Registering Events");

            ZApi.OnConnected -= ZApi_OnConnected;
            ZApi.OnConnected += ZApi_OnConnected;

            ZApi.OnDisConnected -= ZApi_OnDisConnected;
            ZApi.OnDisConnected += ZApi_OnDisConnected;

            ZApi.OnFinger -= ZApi_OnFinger;
            ZApi.OnFinger += ZApi_OnFinger;

            ZApi.OnVerify -= ZApi_OnVerify;
            ZApi.OnVerify += ZApi_OnVerify;

            ZApi.OnAttTransaction -= ZApi_OnAttTransaction;
            ZApi.OnAttTransaction += ZApi_OnAttTransaction;

            ZApi.OnAttTransactionEx -= ZApi_OnAttTransactionEx;
            ZApi.OnAttTransactionEx += ZApi_OnAttTransactionEx;
        }



        #region zAPI - Actions
        private void ZApi_OnFinger()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Finger is Placed");
            FireEvent(ref FingerIsPlaced);
        }

        private void ZApi_OnDisConnected()
        {
            //throw new NotImplementedException();
            FireEvent(ref Disconnected);
        }

        private void ZApi_OnConnected()
        {
            FireEvent(ref Connected);
        }

        private void ZApi_OnAttTransaction(int enrollNumber, int isInValid, int attState, int verifyMethod, int year,
            int month, int day, int hour, int minute, int second)
        {
            //  throw new NotImplementedException();
            Console.WriteLine("OnTransaction");
            Console.WriteLine(enrollNumber);
        }

        private void ZApi_OnVerify(int userId)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Verifying Module Triggered");
        }

        private void ZApi_OnAttTransactionEx(string enrollNumber, int isInValid, int attState, int verifyMethod,
            int year, int month, int day, int hour, int minute, int second, int workCode)
        {

            var id = Int32.Parse(enrollNumber);

            var user = new DeviceUser()
            {
                BiometricId = id,
                //Name = DataManager.Instance.GetName(id)
            };
            //if(user == null) { throw new Exception("User Data Not Found");}

            var transaction = new TransactionEventArgs()
            {
                State = attState,
                UserData = user,
                TransactionDate = new DateTime(year, month, day, hour, minute, second)
            };

            FireEventTransaction(ref TransactionEvent, transaction);
        }

        #endregion

        internal void CheckConnection()
        {
            if (!IsConnected) throw new InvalidOperationException("Not Connected To Device");
        }

        public void EnableDevice(bool state)
        {
            CheckConnection();
            ZApi.EnableDevice(MachineId, state);
        }

        public bool Connect(int port = 4370)
        {
            if (IsConnected) ZApi.Disconnect();

            int errorCode = 0;

            ZApi.MachineNumber = MachineId;

            IsConnected = ZApi.Connect_Net(IpAddress, port);

            if (!IsConnected)
            {
                ZApi.GetLastError(ref errorCode);
                throw new Exception("Error " + errorCode);
            }

            RegisterEvent();

            FireEvent(ref Connected);

            return IsConnected;
        }

        public bool Disconnect()
        {
            CheckConnection();

            ZApi.Disconnect();
            IsConnected = false;

            FireEvent(ref Disconnected);
            return true;
        }

        public string GetSerialNumber()
        {
            CheckConnection();
            string serial;
            ZApi.GetSerialNumber(MachineId, out serial);
            return serial;
        }

        public string GetPlatform()
        {
            CheckConnection();
            string data = string.Empty;
            ZApi.GetPlatform(MachineId, ref data);
            return data;
        }


        private void FireEvent(ref EventHandler eHandler)
        {
            eHandler?.Invoke(this, EventArgs.Empty);
        }

        private void FireEventTransaction(ref EventHandler<TransactionEventArgs> eHandler,
          TransactionEventArgs eventArgs)
        {
            eHandler?.Invoke(this, eventArgs);
        }



        //public void ClearAllData()
        //{
        //    /*
        //    1 - Attendance Record
        //    2 - FingerPrint Template Data
        //    3 - None
        //    4 - Operation Record
        //    5 - User Information
        //    */
        //    ZApi.ClearData(MachineId, 2);
        //    ZApi.ClearData(MachineId, 5);
        //}




        public void WriteChangesToDevice()
        {
            //if (!IsConnected) throw new NotConnectedException("Not Connected");

            //try
            //{
            //    ZApi.EnableDevice(MachineId, false);

            //    //If ClearAll
            //    //if (Users.ClearAllUserActivated)
            //    //{
            //    //    /*
            //    //    1 - Attendance Record
            //    //    2 - FingerPrint Template Data
            //    //    3 - None
            //    //    4 - Operation Record
            //    //    5 - User Information
            //    //    */

            //    //    ZApi.ClearData(MachineId, 2);
            //    //    ZApi.ClearData(MachineId, 5);
            //    //}


            //    if (ZApi.BeginBatchUpdate(MachineId, 1))
            //    {
            //        foreach (var person in Users.Items)
            //        {
            //            /* 
            //             *  0 - Common User 
            //             *  1 - Enroller
            //             */
            //            var name = person.Name;
            //            Console.WriteLine("Writing " + person.Name);
            //            //if (ZApi.SSR_SetUserInfo(MachineId, person.BiometricId.ToString(), name, "", 0 ,true))
            //            //if (ZApi.SetUserInfo(MachineId, person.BiometricId, name, "", 0, true))
            //            if (Users.EnrollUser(person))
            //            {
            //                foreach (var item in person.FingerPrints.Items)
            //                {
            //                    //Console.WriteLine("\t\t" + item.FingerIndex + " ==> " + item.Data );
            //                    if (!ZApi.SetUserTmpExStr(MachineId, person.BiometricId.ToString(), item.FingerIndex, 1, item.Data))
            //                        throw new Exception("Error Saving Fingerprint");
            //                }
            //            }
            //        }
            //        ZApi.BatchUpdate(MachineId);
            //        ZApi.RefreshData(MachineId);
            //    }
            //}
            //finally { ZApi.EnableDevice(MachineId, true); }
        }

        public bool ReadRTLog()
        {
            return ZApi.ReadRTLog(MachineId);
        }


        public bool GetRtLog()
        {
            return ZApi.GetRTLog(MachineId);
        }
    }
}