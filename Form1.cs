using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basicWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            change();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cbRed.Checked == true)
            {
                btnGo.BackColor = Color.Red;
            }
            else
            {
                btnGo.BackColor = Color.Blue;
            }
        }

        private void tbValue_Scroll(object sender, EventArgs e)
        {
            change();
        }

        public void change()
        {
            string[] message = { "Hello", "Welcome", "How ya doin'", "Howdy", "Bonjour" };
            lblWelcome.Text = String.Format("{0} user!", message[tbValue.Value]);
        }
    }
}
