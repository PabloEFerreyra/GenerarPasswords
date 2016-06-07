using System;
using System.IO;
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
            var password = NewPassword.GenerarPass();
            textBox1.Text = password;
        }

        public class NewPassword
        {
            private static string Path = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") +
                                         "\\Documents\\lineas.txt";

            private static string[] lines = File.ReadAllLines(@Path);

            private static char[] ValueAfanumeric =
            {
                'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd',
                'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I',
                'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '!', '#', '$',
                '%', '&', '?', '¿'
            };

            public static string GenerarPass()
            {
                Random ram = new Random();
                int logitudPass = ram.Next(50, 50);
                string password = String.Empty;

                for (int i = 0; i < logitudPass; i++)
                {
                    int rm = ram.Next(0, 2);

                    if (rm == 0)
                    {
                        password += ram.Next(0, 10);
                    }
                    else
                    {
                        password += ValueAfanumeric[ram.Next(0, 59)];
                    }
                }
                foreach (string line in lines)
                {
                    if (line == password)
                    {
                        GenerarPass();
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(@Path, true))
                        {
                            file.WriteLine(password);
                        }
                        return password;
                    }
                }
                using (StreamWriter file = new StreamWriter(@Path, true))
                {
                    file.WriteLine(password);
                }
                return password;
            }
        }


    private void button1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (int) Keys.Enter)
                {
                    var password = NewPassword.GenerarPass();
                    textBox1.Text = password;
                }
            }
        }
    }
