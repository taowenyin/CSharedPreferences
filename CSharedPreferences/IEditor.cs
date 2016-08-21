using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharedPreferences
{
    public interface IEditor
    {
        /// <summary>
        /// 清空所有Key值
        /// </summary>
        /// <returns>IEditor对象</returns>
        IEditor Clear();

        /// <summary>
        /// 提交所有值
        /// </summary>
        /// <returns>IEditor对象</returns>
        IEditor Commit();

        /// <summary>
        /// 向SharesPreference添加Boolean类型的值
        /// </summary>
        /// <param name="key">Boolean类型的Key</param>
        /// <param name="value">Boolean类型的值</param>
        /// <returns>IEditor对象</returns>
        IEditor PutBoolean(string key, bool value);

        /// <summary>
        /// 向SharesPreference添加Float类型的值
        /// </summary>
        /// <param name="key">Float类型的Key</param>
        /// <param name="value">Float类型的值</param>
        /// <returns>IEditor对象</returns>
        IEditor PutFloat(string key, float value);

        /// <summary>
        /// 向SharesPreference添加Int类型的值
        /// </summary>
        /// <param name="key">Int类型的Key</param>
        /// <param name="value">Int类型的值</param>
        /// <returns>IEditor对象</returns>
        IEditor PutInt(string key, int value);

        /// <summary>
        /// 向SharesPreference添加Long类型的值
        /// </summary>
        /// <param name="key">Long类型的Key</param>
        /// <param name="value">Long类型的值</param>
        /// <returns>IEditor对象</returns>
        IEditor PutLong(string key, long value);

        /// <summary>
        /// 向SharesPreference添加String类型的值
        /// </summary>
        /// <param name="key">String类型的Key</param>
        /// <param name="value">String类型的值</param>
        /// <returns>IEditor对象</returns>
        IEditor PutString(string key, string value);

        /// <summary>
        /// 移除对应Key的值
        /// </summary>
        /// <param name="key">要移除的Key</param>
        /// <returns>IEditor对象</returns>
        IEditor Remove(string key);
    }
}
