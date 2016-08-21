using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharedPreferences
{
    public class SharedPreferences
    {
        private static SharedPreferences instance = null;
        private string sharedPrefName = null;

        private SharedPreferences(string name)
        {
            this.sharedPrefName = name;
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
            return false;
        }

        /// <summary>
        /// 获取Editor对象
        /// </summary>
        /// <returns>Editor对象</returns>
        public IEditor GetEditor()
        {
            return null;
        }

        /// <summary>
        /// 获取Boolean类型的Key值
        /// </summary>
        /// <param name="key">检索的Key值</param>
        /// <param name="defValue">如果Key不存在，则使用的默认值</param>
        /// <returns>Key对应的值</returns>
        public bool GetBoolean(string key, bool defValue)
        {
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
            return defValue;
        }

        /// <summary>
        /// 获取SharedPreferences文件名
        /// </summary>
        /// <returns>SharedPreferences文件名</returns>
        private string getSharedPrefName()
        {
            return this.sharedPrefName;
        }
    }
}
