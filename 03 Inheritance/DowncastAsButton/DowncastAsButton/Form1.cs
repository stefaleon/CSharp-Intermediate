using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DowncastAsButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = sender as Button; // downcasting the sender object as Button so that the Button properties are available to button
            if (button != null)
            {
                MessageBox.Show(button.Height.ToString()); // button has the Height property of Button
            }
        }
    }
}
