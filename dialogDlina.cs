using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chast1
{
    public partial class dialogDlina : Form
    {
        Form1 mainForm;
        public dialogDlina(Form1 mainForm)
        {
            this.mainForm = mainForm; 
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                mainForm.DialogRes = Convert.ToInt32(textBox1.Text);
            else
                CancelButton.PerformClick();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && (e.KeyChar != 45 | textBox1.Text != "" && textBox1.Text.IndexOf('-') != -1))
                e.Handled = true;
        }


        private void dialogDlina_Load(object sender, EventArgs e)
        {
            textBox1.TabIndex = 0;
        }


    }
}
