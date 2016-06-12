using System;
using System.Collections.Generic;
using System.Configuration;

namespace ContactManager
{
    public class AppSettings
    {
        public static string GoogleClientId
        {
            get { return ReadSetting("googleClientId"); }
        }

        public static string GoogleClientSecret
        {
            get { return ReadSetting("googleClientSecret"); }
        }

        public static HashSet<string> AuthAllowedEmails
        {
            get
            {
                var emails = ReadSetting("authAllowedEmails").Split(new[] { ';' });
                return new HashSet<string>(emails);
            }
        }

        private static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key];
            if (result == null)
                throw new ArgumentException($"AppSetting: '{key}' not found");
            return result;
        }
    }
}