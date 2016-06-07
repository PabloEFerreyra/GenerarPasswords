using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerarPasswords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password ="";
            password =NewPassword.GenerarPass();
            textBox1.Text = password;
        }

        public class NewPassword
        {
            static char[] ValueAfanumeric = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '!', '#', '$', '%', '&', '?', '¿' };

            public static string GenerarPass()
            {
                Random ram = new Random();
                int LogitudPass = ram.Next(50, 50);
                string Password = String.Empty;

                for (int i = 0; i < LogitudPass; i++)
                {
                    int rm = ram.Next(0, 2);

                    if (rm == 0)
                    {
                        Password += ram.Next(0, 10);
                    }
                    else
                    {
                        Password += ValueAfanumeric[ram.Next(0, 59)];
                    }
                }
                
                return Password;

            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Enter)
            {
                string password = "";
                password = NewPassword.GenerarPass();
                textBox1.Text = password;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ayuda Ayuda = new Ayuda();
            Ayuda.Show();
        }
    }
}
