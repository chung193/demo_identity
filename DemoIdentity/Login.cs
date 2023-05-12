using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoIdentity
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string? className = MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
            MessageBox.Show(className);
            MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (!helper.Helper.checkFileExits("demo.sqlite"))
            {
                common.Data.initDataFile();
                common.Data.createTable();
                common.Data.initDataDemo();
                common.Data.initPermission();
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPw.Text != "" && txtUsername.Text != "")
            {
                string sql = "SELECT tbl_users.*, tbl_groups.name as groupName, tbl_permissions.json as json FROM tbl_users JOIN tbl_groups ON tbl_users.group_id = tbl_groups.id JOIN tbl_permissions ON tbl_permissions.group_id = tbl_groups.id WHERE tbl_users.name = '" + txtUsername.Text + "' AND password = '" + txtPw.Text + "'";
                DataSet ds = new DataSet();
                ds = common.Data.loadData(sql);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("login success");
                    Form frmMain = new app.Main();

                    DataRow[] dr = ds.Tables[0].Select("name = '" + txtUsername.Text +"' and password = '"+ txtPw.Text+"'");
                    common.Identity.name = dr[0].ItemArray[1].ToString();
                    common.Identity.password = dr[0].ItemArray[2].ToString();
                    common.Identity.group_id = int.Parse(dr[0].ItemArray[3].ToString());
                    common.Identity.group_name = dr[0].ItemArray[4].ToString();
                    common.Identity.permission = dr[0].ItemArray[5].ToString();
                    frmMain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("username or password incorrect");
                }
            }
        }

    }
}
