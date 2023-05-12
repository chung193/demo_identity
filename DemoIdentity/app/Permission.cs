using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoIdentity.common;
using Newtonsoft.Json;
namespace DemoIdentity.app
{
    public partial class Permission : Form
    {
        public Permission()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        protected void MyMethod()
        {
            Console.WriteLine("I just got executed!");
        }
        public void sayHello(string fname)
        {
            Console.WriteLine("Hello " + fname);
        }

        private void Permission_Load(object sender, EventArgs e)
        {
            
            //var n = className.Namespace;
            List<Struct> list = helper.Helper.StringToObj(common.Identity.permission);

        }

        public void loadTreeView()
        {
            DataSet ds = new DataSet();
            string query = "select * from tbl_permissions";
            ds = common.Data.loadData(query);
        }
    }
}
