using System;
using System.Collections;
using System.Collections.Generic;

namespace GameAnalyticsSDK.Utilities
{
    public static class ValuableInformation
    {
        private static Dictionary<string, object> AllInformation = new Dictionary<string, object>();

        public static void Set(string key, object value)
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

        internal static Dictionary<string, object> Extract()
        {
            return AllInformation;
        }
    }
}
