﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoIdentity.app.featureB
{
    public partial class FrmB : Form
    {
        public FrmB()
        {
            InitializeComponent();
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
    }
}
