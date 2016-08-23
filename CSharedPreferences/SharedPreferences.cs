using CSharedPreferences.Common;
using CSharedPreferences.Editor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharedPreferences
{
    public class SharedPreferences
    {
        private static SharedPreferences instance = null;

        private string sharedPrefName = null;
        private JObject sharedPref = null;

        private SharedPreferences(string name)
        {
            string preferencesPath = Path.Combine(Environment.CurrentDirectory, 
                Preferences.SHARE_PREF_DIR, name + Preferences.SHARE_PREF_SUFFIX);
            sharedPrefName = name;

            if(File.Exists(preferencesPath))
            {
                string jsonText = File.ReadAllText(preferencesPath, Encoding.UTF8);
                sharedPref = JObject.Parse(jsonText);
            }
            else
            {
                sharedPref = new JObject();
            }
        }

        /// <summary>
        /// 获取SharedPreferences文件名
        /// </summary>
        /// <returns>SharedPreferences文件名</returns>
        public string getSharedPrefName()
        {
            return this.sharedPrefName;
        }

        /// <summary>
        /// 获取SharedPreferences单例
        /// </summary>
        /// <param name="name">SharedPreferences文件名</param>
        /// <returns>SharedPreferences单例对象</returns>
        public static SharedPreferences GetInstance(string name)
        {
            if(instance == null || !instance.getSharedPrefName().Equals(name))
            {
                instance = new SharedPreferences(name);
            }

            return instance;
        }

        /// <summary>
        /// 判断Key值是否存在
        /// </summary>
        /// <param name="key">要判断的Key值</param>
        /// <returns>Ture：表示Key存在，False：表示Key不存在</returns>
        public bool Contains(string key)
        {
            if(sharedPref.SelectToken(key) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取Editor对象
        /// </summary>
        /// <returns>Editor对象</returns>
        public IEditor GetEditor()
        {
            return new SimpleEditor(sharedPref, this);
        }

        /// <summary>
        /// 获取Boolean类型的Key值
        /// </summary>
        /// <param name="key">检索的Key值</param>
        /// <param name="defValue">如果Key不存在，则使用的默认值</param>
        /// <returns>Key对应的值</returns>
        public bool GetBoolean(string key, bool defValue)
        {
            if(Contains(key))
            {
                return (bool)(sharedPref[key]);
            }

            return defValue;
        }

        /// <summary>
        /// 获取Float类型的Key值
        /// </summary>
        /// <param name="key">检索的Key值</param>
        /// <param name="defValue">如果Key不存在，则使用的默认值</param>
        /// <returns>Key对应的值</returns>
        public float GetFloat(string key, float defValue)
        {
            if (Contains(key))
            {
                return (float)(sharedPref[key]);
            }

            return defValue;
        }

        /// <summary>
        /// 获取Int类型的Key值
        /// </summary>
        /// <param name="key">检索的Key值</param>
        /// <param name="defValue">如果Key不存在，则使用的默认值</param>
        /// <returns>Key对应的值</returns>
        public int GetInt(string key, int defValue)
        {
            if (Contains(key))
            {
                return (int)(sharedPref[key]);
            }

            return defValue;
        }

        /// <summary>
        /// 获取Long类型的Key值
        /// </summary>
        /// <param name="key">检索的Key值</param>
        /// <param name="defValue">如果Key不存在，则使用的默认值</param>
        /// <returns>Key对应的值</returns>
        public long GetLong(string key, long defValue)
        {
            if (Contains(key))
            {
                return (long)(sharedPref[key]);
            }

            return defValue;
        }

        /// <summary>
        /// 获取Double类型的Key值
        /// </summary>
        /// <param name="key">检索的Key值</param>
        /// <param name="defValue">如果Key不存在，则使用的默认值</param>
        /// <returns>Key对应的值</returns>
        public double GetDouble(string key, double defValue)
        {
            if (Contains(key))
            {
                return (double)(sharedPref[key]);
            }

            return defValue;
        }

        /// <summary>
        /// 获取String类型的Key值
        /// </summary>
        /// <param name="key">检索的Key值</param>
        /// <param name="defValue">如果Key不存在，则使用的默认值</param>
        /// <returns>Key对应的值</returns>
        public string GetString(string key, string defValue)
        {
            if (Contains(key))
            {
                return (string)(sharedPref[key]);
            }

            return defValue;
        }
    }
}
