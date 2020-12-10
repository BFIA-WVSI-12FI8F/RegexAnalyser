using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexAnalyser
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Text = Program.PROJECT_NAME;
        }

        private void inpSearchPattern_TextChanged(object sender, EventArgs e)
        {
            outTextResult.Text = RegexImpl.RegexImpl.GetAnswer(inpSearchPattern.Text);
        }
    }
}
