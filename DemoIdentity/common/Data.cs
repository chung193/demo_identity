using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DemoIdentity.common
{
    public static class Data
    {
        public static SQLiteConnection _con = new SQLiteConnection();
        public static string createTableUserGroup = "CREATE TABLE IF NOT EXISTS tbl_groups ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name nvarchar(50))";
        public static string createTableUser = "CREATE TABLE IF NOT EXISTS tbl_users ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, fullname nvarchar(50), email varchar(30), password nvarchar(100), group_id int)";
        public static string createTablePermission = "CREATE TABLE IF NOT EXISTS tbl_permissions ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, group_id int, json varchar(500))";
        public static void initDataFile()
        {
            SQLiteConnection.CreateFile("demo.sqlite");
        }
        public static void createConection()
        {
            string _strConnect = "Data Source=demo.sqlite;Version=3;";
            _con.ConnectionString = _strConnect;
            _con.Open();
        }

        public static void createTable()
        {
            createConection();
            SQLiteCommand command = new SQLiteCommand(createTableUser, _con);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(createTableUserGroup, _con);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(createTablePermission, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public static void closeConnection()
        {
            _con.Close();
        }
    }
}
