using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharedPreferences;

namespace Test
{
    [TestClass]
    public class SharedPreferenceTest
    {
        [TestMethod]
        public void TestSingleton()
        {
            SharedPreferences preferences1 = SharedPreferences.GetInstance("park");
            SharedPreferences preferences2 = SharedPreferences.GetInstance("park");
            Assert.AreSame(preferences1, preferences2, "同名单例测试失败");

            SharedPreferences preferences3 = SharedPreferences.GetInstance("park1");
            Assert.AreNotSame(preferences1, preferences3, "异名单例测试失败");
        }

        [TestMethod]
        public void TestCommitData()
        {
            SharedPreferences preference = SharedPreferences.GetInstance("park");
            IEditor editor = preference.GetEditor();
            editor.PutInt("intData", 1);
            editor.PutBoolean("booleanData", true);
            editor.PutFloat("floatData", 3.43f);
            editor.PutLong("longData", 123);
            editor.PutDouble("doubleData", 5.76);
            editor.PutString("stringData", "test");
            editor.Commit();
        }

        [TestMethod]
        public void TestDataRead()
        {
            SharedPreferences preference = SharedPreferences.GetInstance("park");

            Assert.AreEqual(preference.GetInt("intData", 0), 1, "读取Int失败");
            Assert.AreEqual(preference.GetBoolean("booleanData", false), true, "读取Boolean失败");
            Assert.AreEqual(preference.GetFloat("floatData", 0.0f), 3.43f, "读取Float失败");
            Assert.AreEqual(preference.GetLong("longData", 0), 123, "读取Long失败");
            Assert.AreEqual(preference.GetDouble("doubleData", 0), 5.76, "读取Double失败");
            Assert.AreEqual(preference.GetString("stringData", "No Data"), "test", "读取String失败");
        }

        [TestMethod]
        public void TestDataChange()
        {
            SharedPreferences preference = SharedPreferences.GetInstance("park");
            IEditor editor = preference.GetEditor();
            editor.PutInt("intData", 10);
            editor.Commit();
        }

        [TestMethod]
        public void TestRemoveData()
        {
            SharedPreferences preference = SharedPreferences.GetInstance("park");
            IEditor editor = preference.GetEditor();
            editor.Remove("intData");
            editor.Commit();
        }

        [TestMethod]
        public void TestRemoveAllData()
        {
            SharedPreferences preference = SharedPreferences.GetInstance("park");
            IEditor editor = preference.GetEditor();
            editor.Clear();
            editor.Commit();
        }

        [TestMethod]
        public void TestTwoSingleton()
        {
            SharedPreferences preferences1 = SharedPreferences.GetInstance("park1");
            IEditor editor1 = preferences1.GetEditor();
            editor1.PutInt("intData", 1);
            editor1.PutString("stringData", "test1");

            SharedPreferences preferences2 = SharedPreferences.GetInstance("park2");
            IEditor editor2 = preferences2.GetEditor();
            editor2.PutInt("intData", 2);
            editor2.PutString("stringData", "test2");

            editor1.Commit();
            editor2.Commit();
        }

        [TestMethod]
        public void TestNullValue()
        {
            SharedPreferences preferences = SharedPreferences.GetInstance("park3");
            string value = preferences.GetString("test", "No Data");
            Console.WriteLine("String data = " + value);
        }
    }
}
