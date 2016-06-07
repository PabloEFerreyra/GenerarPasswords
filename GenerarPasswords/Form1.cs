using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GenerarPasswords
{
    

public partial class Form1 : Form
{
        
    static string Path = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") +
                                        "\\Documents\\lineas.txt";
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

        private static char[] _valueAfanumeric =
        {
            'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd',
            'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I',
            'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '!', '#', '$',
            '%', '&', '?', '¿'
        };

        public static string GenerarPass()
        {
            string[] _lines = File.ReadAllLines(Path);
            Random ram = new Random();
            int logitudPass = ram.Next(25, 25);
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
                    password += _valueAfanumeric[ram.Next(0, 59)];
                }
            }
            foreach (string line in _lines)
            {
                if (line == password)
                {
                    GenerarPass();
                }
                else
                {
                    using (StreamWriter file = new StreamWriter(Path, true))
                    {
                        file.WriteLine(password+',');
                    }
                    return password;
                }
            }
            using (StreamWriter file = new StreamWriter(Path, true))
            {
                file.WriteLine(password+',');
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

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        if(File.Exists(Path))
                File.Delete(Path);
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            var archivo = Path;
            if (File.Exists(archivo))
                File.Delete(archivo);
            using (var fileStream = File.Create(archivo))
            {
                fileStream.Flush();
            }

            var password = NewPassword.GenerarPass();
            textBox1.Text = password;

        }

}

}

