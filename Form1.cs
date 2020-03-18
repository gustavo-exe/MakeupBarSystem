using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        
        public void progresbar()
        {
            progressBar1.Increment(1);
            if(progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                Login ventana = new Login();
                ventana.Show();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progresbar();
        }

      
    }
}
