using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoIdentity.app
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lbUser.Text = "Hello, " + common.Identity.name;
            lbGroup.Text = "User group: " + common.Identity.group_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Permission frm = new Permission();
            frm.ShowDialog();
        }

        protected void MyMethod()
        {
            Console.WriteLine("I just got executed!");
        }
        public void sayHello(string fname)
        {
            Console.WriteLine("Hello " + fname);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
