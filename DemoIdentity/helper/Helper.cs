using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using DemoIdentity.common;

namespace DemoIdentity.helper
{
    public static class Helper
    {
        public static bool checkFileExits(string path)
        {
            return File.Exists(path);
        }
        public static bool checkFolderExits(string path)
        {
            return Directory.Exists(path);
        }

        public static string[] getDirectories(string path)
        {
            return System.IO.Directory.GetDirectories(path, "*", System.IO.SearchOption.AllDirectories);
        }
        

        public static List<Struct> StringToObj(string jsonStr)
        {
            List<Struct> x = JsonConvert.DeserializeObject<List<Struct>>(jsonStr);
            return x;
        } 

}
}

