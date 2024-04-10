using System;
using System.Collections;
using System.Collections.Generic;

namespace GameAnalyticsSDK.Utilities
{
    public static class ValuableInformation
    {
        private static Dictionary<string, string> AllInformation = new Dictionary<string, string>();

        public static void Set(string key, string value)
        {
            if(!AllInformation.TryAdd(key, value))
            {
                AllInformation[key] = value;
            }
        }

        public static void RemoveKey(string key)
        {
            if (!AllInformation.ContainsKey(key))
                return;

            AllInformation.Remove(key);
        }

        internal static Dictionary<string, string> Extract()
        {
            return AllInformation;
        }
    }
}
