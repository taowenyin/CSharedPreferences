using CSharedPreferences.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharedPreferences.Editor
{
    class SimpleEditor : IEditor
    {
        private JObject sharedPref = null;
        private SharedPreferences preferences = null;
        private string preferencesPath = null;

        public SimpleEditor(JObject sharedPref, SharedPreferences preferences)
        {
            this.sharedPref = sharedPref;
            this.preferences = preferences;
            preferencesPath = Path.Combine(Environment.CurrentDirectory,
                Preferences.SHARE_PREF_DIR, 
                preferences.getSharedPrefName() + Preferences.SHARE_PREF_SUFFIX);
        }

        public IEditor Clear()
        {
            sharedPref.RemoveAll();
            return this;
        }

        public IEditor Commit()
        {
            FileInfo info = new FileInfo(preferencesPath);
            DirectoryInfo parentDirectory = info.Directory;
            if(!parentDirectory.Exists)
            {
                parentDirectory.Create();
            }
            if (!File.Exists(preferencesPath))
            {
                FileStream fs = File.Create(preferencesPath);
                fs.Close();
            }

            File.WriteAllText(preferencesPath, sharedPref.ToString());
            return this;
        }

        public IEditor PutBoolean(string key, bool value)
        {
            if(preferences.Contains(key))
            {
                sharedPref[key] = value;
            }
            else
            {
                sharedPref.Add(key, new JValue(value));
            }

            return this;
        }

        public IEditor PutFloat(string key, float value)
        {
            if (preferences.Contains(key))
            {
                sharedPref[key] = value;
            }
            else
            {
                sharedPref.Add(key, new JValue(value));
            }

            return this;
        }

        public IEditor PutInt(string key, int value)
        {
            if (preferences.Contains(key))
            {
                sharedPref[key] = value;
            }
            else
            {
                sharedPref.Add(key, new JValue(value));
            }

            return this;
        }

        public IEditor PutLong(string key, long value)
        {
            if (preferences.Contains(key))
            {
                sharedPref[key] = value;
            }
            else
            {
                sharedPref.Add(key, new JValue(value));
            }

            return this;
        }

        public IEditor PutString(string key, string value)
        {
            if (preferences.Contains(key))
            {
                sharedPref[key] = value;
            }
            else
            {
                sharedPref.Add(key, new JValue(value));
            }

            return this;
        }

        public IEditor PutDouble(string key, double value)
        {
            if (preferences.Contains(key))
            {
                sharedPref[key] = value;
            }
            else
            {
                sharedPref.Add(key, new JValue(value));
            }

            return this;
        }

        public IEditor Remove(string key)
        {
            if (preferences.Contains(key))
            {
                sharedPref.Remove(key);
            }

            return this;
        }
    }
}
