using UnityEngine.Device;

namespace Utils
{
    public class DeviceHelper
    {
        public static bool IsRunningOnIphoneDevice() => SystemInfo.deviceName.StartsWith("iPhone");
    }
}