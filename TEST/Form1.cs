using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int hour = 0;
        string c = ":";        
        bool Colon()
        {
            String Time = txtinput.Text;
            int startIndex = 2;
            int length = 1;
            String colon = Time.Substring(startIndex, length);
            bool result = colon.Equals(c);
            return result;
        }
        int MIN(int hour)
        {
            
            String Time = txtinput.Text;
            int startIndex = 3;
            int length = 2;
            String Mintime = Time.Substring(startIndex, length);
            if (int.TryParse(Mintime, out int min))
            {
                if (min >= 0 && min <= 59)
                {
                    if (hour <= 11 &&  hour > 0)
                    {
                        txtoutput.Text = txtoutput.Text + ":" + Mintime + " AM";
                        return hour;
                    }
                    else if(hour == 0)
                    {
                        txtoutput.Text = hour+12 + ":" + Mintime + " AM";
                    }
                    else if(hour >= 13 && hour <=21)
                    {
                        txtoutput.Text = "0"+ txtoutput.Text + ":" + Mintime + " PM";
                        return hour;
                    }
                    else
                    {
                        txtoutput.Text = txtoutput.Text + ":" + Mintime + " PM";
                    }
                }
                else
                {
                    MessageBox.Show("ERROR");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("ERROR");
                Application.Exit();
            }
            return 0;
        }
        int HR()
        {
            int G;
            String Time = txtinput.Text;
            int startIndex = 0;
            int length = 2;
            String Hourtime = Time.Substring(startIndex, length);
            if (int.TryParse(Hourtime, out int hour))
            {
                if (hour <= 12)
                {
                    txtoutput.Text = Hourtime;
                    return hour;
                }
                else if (hour > 12 && hour < 24)
                {
                    G = hour - 12;
                    txtoutput.Text = G.ToString();
                    return hour;
                }
                else
                {
                    MessageBox.Show("ERROR");                   
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("ERROR");
                Application.Exit();
            }
            return hour;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtinput.TextLength != 5)
                {
                    MessageBox.Show("ERROR");
                    Application.Exit();
                    return;
                }
                if (Colon() != true)
                {
                    MessageBox.Show("ERROR");
                    Application.Exit();
                }
                hour = HR();
                MIN(hour);
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.ToString());
                throw ;
            }                             
        }
    }
}
