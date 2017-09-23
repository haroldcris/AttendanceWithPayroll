using AiTech.LiteOrm;

namespace Dll.Biometric
{
    public class BiometricUserScheduleCollection : EntityCollection<BiometricUserSchedule>
    {
        private BiometricUser _biometricUser;

        public BiometricUserScheduleCollection()
        {
            //
        }


        public BiometricUserScheduleCollection(BiometricUser parentBiometricUser)
        {
            _biometricUser = parentBiometricUser;
        }
    }
}
