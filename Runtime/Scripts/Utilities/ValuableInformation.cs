using System;
using System.Collections;
using System.Collections.Generic;

namespace GameAnalyticsSDK.Utilities
{
    public static class ValuableInformation
    {
        private static Dictionary<string, int> Keys = new Dictionary<string, int>();
        private static int Entries = 0;

        private static InformationEntryCollection AllInformation = new InformationEntryCollection();
    
        [System.Serializable]
        private class InformationEntry
        {
            public string Key;
            public string Value;
        } 

        [System.Serializable]
        private class InformationEntryCollection
        {
            public InformationEntry[] Entries = new InformationEntry[10];
        }

        public static void Set(string key, string value)
        {
            int index = 0;
            if (Keys.TryAdd(key, Entries))
            {
                index = Keys[key];
                if (Entries + 1 == AllInformation.Entries.Length)
                {
                    Array.Resize(ref AllInformation.Entries, AllInformation.Entries.Length * 2);
                }
                AllInformation.Entries[index] = new InformationEntry();
                Entries++;
            }

            index = Keys[key];
        
            var relatedObject = AllInformation.Entries[index];
            relatedObject.Key = key;
            relatedObject.Value = value;
        }

        public static void RemoveKey(string key)
        {
            if (!Keys.ContainsKey(key))
                return;

            var index = Keys[key];
            Entries--;
            Keys.Remove(key);
            AllInformation.Entries[index] = null;
        }

        internal static string Extract() => UnityEngine.JsonUtility.ToJson(AllInformation);
    }
}
