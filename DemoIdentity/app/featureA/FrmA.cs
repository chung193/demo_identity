using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoIdentity.app.featureA
{
    public partial class FrmA : Form
    {
        public FrmA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
