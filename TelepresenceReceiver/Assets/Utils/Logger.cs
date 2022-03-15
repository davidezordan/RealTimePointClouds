using UnityEngine;

namespace Utils
{
    public class Logger
    {
        private static bool IsEnabled = false;
        public static void Info(string s)
        {
            if (IsEnabled)
            {
                Debug.Log(s);
            }
        }
    }
}