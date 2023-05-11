using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Text.Json.Nodes;

namespace DemoIdentity.common
{
    public static class Data
    {
        public static SQLiteConnection _con = new SQLiteConnection();
        public static string response = "";
        public static string createTableUserGroup = "CREATE TABLE IF NOT EXISTS tbl_groups ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name nvarchar(50))";
        public static string createTableUser = "CREATE TABLE IF NOT EXISTS tbl_users ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name nvarchar(50), password nvarchar(100), group_id int)";
        public static string createTablePermission = "CREATE TABLE IF NOT EXISTS tbl_permissions ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, group_id int, json varchar(500))";

        public static string demoGroup = "Insert into tbl_groups (name) values ('admin');Insert into tbl_groups (name) values ('guest')";
        public static string demoUser = "Insert into tbl_users (name, password, group_id) values ('chung', '123123', 1);Insert into tbl_users (name, password, group_id) values ('thuy', '123123', 2)";

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

        public static void initDataDemo()
        {
            createConection();
            SQLiteCommand command = new SQLiteCommand(demoGroup, _con);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(demoUser, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public static void initPermission()
        {
            string[] permission = common.Identity.initPermission();
            string demo1 = String.Format("INSERT INTO tbl_permissions(group_id, json) VALUES(1, {0})", permission[0]);
            string demo2 = String.Format("INSERT INTO tbl_permissions(group_id, json) VALUES(1, {0})",permission[1]);

            createConection();
            SQLiteCommand cmd = new SQLiteCommand(demo1, _con);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(demo2, _con);
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public static void closeConnection()
        {
            _con.Close();
        }

        public static DataSet loadData(string query)
        {
            DataSet ds = new DataSet();
            createConection();
            SQLiteDataAdapter da = new SQLiteDataAdapter(query, _con);
            da.Fill(ds);
            closeConnection();
            return ds;
        }

        // lệnh vô hướng
        public static void updateData(string query)
        {
            try
            {
                createConection();
                SQLiteCommand cmd = new SQLiteCommand(query, _con);
                cmd.ExecuteNonQuery();
                closeConnection();
            }
            catch(Exception ex)
            {
                response = ex.Message;
            }
        }

    }
}
