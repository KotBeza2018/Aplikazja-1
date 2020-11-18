using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja2_Szyfrator
{
    public partial class wpisz_tu_hasło : Form
    {
        public wpisz_tu_hasło()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void zaloguj_Click(object sender, EventArgs e)
        {
            if (pastword.Text == "test")
            {
                Console.WriteLine("Zalogowano");
                new MainWindow().Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("Błedne hasło!", "Wpisane hasło jest nieprawidłowe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }

        }


        

        
    }
}
