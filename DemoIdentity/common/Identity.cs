using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoIdentity.common
{
    public static class Identity
    {
        public static string json = "";
        public static string name = "";
        public static string password = "";
        public static int group_id = 0;
        public static string group_name = "";
        public static string permission = "";

        public static List<System.Type> getClassList()
        {
            List<System.Type> list = new List<System.Type>();
            list = Assembly.GetExecutingAssembly().GetTypes()
                      .Where(t => t.Namespace.Contains("DemoIdentity.app"))
                      .ToList();
            return list;
        }

        public static MethodInfo[] getMethodList(string selectedObjcClass)
        {
            MethodInfo[] methodInfos = Type.GetType(selectedObjcClass)
                            .GetMethods(
                                        BindingFlags.DeclaredOnly |
                                        BindingFlags.Instance |
                                        BindingFlags.Public |
                                        BindingFlags.NonPublic
                                    );
            return methodInfos;
        }

        //public static string[] initPermission()
        //{
        //    string[] permission = new string[2];
        //    string result1 = "\"";
        //    string result2 = "\"";
        //    List<System.Type> classList = getClassList();

        //    Dictionary<string, Dictionary<string, bool>> MyDic = new Dictionary<string, Dictionary<string, bool>>(classList.Count);
        //    int i=0, j=0;
        //    foreach (var val in classList)
        //    {
        //        Dictionary<string, bool> list = new Dictionary<string, bool>();
        //        MethodInfo[] methodList = getMethodList(val.ToString());

        //        result1 += "{name:" + val.ToString() + ", members:";
        //        result2 += "{name:" + val.ToString() + ", members:";
        //        i++;

        //        string temp1 = "[";
        //        string temp2 = "[";
        //        foreach (var item in methodList)
        //        {
        //            temp1 += "{name: " + item.ToString() + ", value: 1}";
        //            temp2 += "{name: " + item.ToString() + ", value: 0}";
        //            list.Add(item.ToString(), false);

        //            if(j < methodList.Length)
        //            {
        //                temp1 += ",";
        //                temp2 += ",";
        //            }
        //            j++;
        //        }
        //        j = 0;
        //        temp1 += "]";
        //        temp2 += "]";
        //        result1 = result1 + temp1 + "}";
        //        result2 = result2 + temp2 + "}";
        //        if (i < classList.Count)
        //        {
        //            result1 += ",";
        //            result2 += ",";
        //        }
        //        MyDic.Add(val.ToString(), list);
        //    }
        //    permission[0] = result1 + "\"";
        //    permission[1] = result2 + "\"";
        //    return permission;
        //}
        public static string[] initPermission()
        {
            string[] permission = new string[2];
            string result1 = "\'";
            string result2 = "\'";
            List<System.Type> classList = getClassList();

            Dictionary<string, Dictionary<string, bool>> MyDic = new Dictionary<string, Dictionary<string, bool>>(classList.Count);
            int i = 0, j = 0;
            foreach (var val in classList)
            {
                Dictionary<string, bool> list = new Dictionary<string, bool>();
                MethodInfo[] methodList = getMethodList(val.ToString());

                result1 += "{\"name\":\"" + val.ToString() + "\", \"members\":\"";
                result2 += "{\"name\":\"" + val.ToString() + "\", \"members\":\"";
                i++;

                string temp1 = "[";
                string temp2 = "[";
                foreach (var item in methodList)
                {
                    temp1 += "{\"name\": " + item.ToString() + ", \"value\": 1}";
                    temp2 += "{\"name\": " + item.ToString() + ", \"value\": 0}";
                    list.Add(item.ToString(), false);

                    if (j < methodList.Length)
                    {
                        temp1 += ",";
                        temp2 += ",";
                    }
                    j++;
                }
                j = 0;
                temp1 += "]\"";
                temp2 += "]\"";
                result1 = result1 + temp1 + "}";
                result2 = result2 + temp2 + "}";
                if (i < classList.Count)
                {
                    result1 += ",";
                    result2 += ",";
                }
                MyDic.Add(val.ToString(), list);
            }
            permission[0] = result1 + "\'";
            permission[1] = result2 + "\'";
            return permission;
        }
    }
}
