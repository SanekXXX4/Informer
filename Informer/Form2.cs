using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Informer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ini();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                string max = textBox1.Text;
                string min = textBox2.Text;
                string t_max = textBox7.Text;
                string t_min = textBox8.Text;
                //string pool = textBox9.Text;
                //string wallet = textBox4.Text;
                string t_start = comboBox2.Text;
                string r_min = textBox5.Text;
                string rt_min = textBox11.Text;
                string fan_max = textBox4.Text;
                string fan_min = textBox6.Text;
                string t_fan_max = textBox9.Text;
                string t_fan_min = textBox10.Text;
                string clock1 = textBox13.Text;
               // string t_inet = textBox17.Text;
               // manager.WritePrivateString("main", "t_inet", t_inet);
               // GlobalVars.t_inet = Convert.ToInt32(t_inet);
                manager.WritePrivateString("main", "clock", clock1);
                GlobalVars.clock1 = Convert.ToInt32(clock1);
                string t_clock = textBox14.Text;
                manager.WritePrivateString("main", "t_clock", t_clock);
                GlobalVars.t_clock = Convert.ToInt32(t_clock);
                string memory = textBox15.Text;
                manager.WritePrivateString("main", "memory", memory);
                GlobalVars.memory = Convert.ToInt32(memory);
                string t_memory = textBox16.Text;
                manager.WritePrivateString("main", "t_memory", t_memory);
                GlobalVars.t_memory = Convert.ToInt32(t_memory);
                manager.WritePrivateString("main", "t_fan_max", t_fan_max);
                GlobalVars.t_fan_max = Convert.ToInt32(t_fan_max);
                manager.WritePrivateString("main", "t_fan_min", t_fan_min);
                GlobalVars.t_fan_min = Convert.ToInt32(t_fan_min);
                manager.WritePrivateString("main", "fan_max", fan_max);
                GlobalVars.fan_max = Convert.ToInt32(fan_max);
                manager.WritePrivateString("main", "fan_min", fan_min);
                GlobalVars.fan_min = Convert.ToInt32(fan_min);
                manager.WritePrivateString("main", "max", max);
                GlobalVars.max = Convert.ToInt32(max);
                manager.WritePrivateString("main", "min", min);
                GlobalVars.min = Convert.ToInt32(min);
                manager.WritePrivateString("main", "t_min", t_min);
                GlobalVars.t_min = Convert.ToInt32(t_min);
                manager.WritePrivateString("main", "t_max", t_max);
                GlobalVars.t_max = Convert.ToInt32(t_max);
                // manager.WritePrivateString("main", "pool", pool);
                //  manager.WritePrivateString("main", "wallet", wallet);
                GlobalVars.t_start = Convert.ToInt32(t_start);
                manager.WritePrivateString("main", "t_start", t_start);
                manager.WritePrivateString("main", "r_min", r_min);
                manager.WritePrivateString("main", "rt_min", rt_min);
                ini();
                Hide();
            }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
                Log.writeLogLine(ex.Message);
            }
        }
        public void ini()
        {
            string fullPath = Application.StartupPath.ToString();
            INIManager manager = new INIManager(fullPath + "\\my.ini");
            string max = manager.GetPrivateString("main", "max");
            string min = manager.GetPrivateString("main", "min");
            string t_min = manager.GetPrivateString("main", "t_min");
            string t_max = manager.GetPrivateString("main", "t_max");
            string reboot_max = manager.GetPrivateString("main", "reboot_max");
            string reboot_max_fan = manager.GetPrivateString("main", "reboot_max_fan");
            string reboot_min = manager.GetPrivateString("main", "reboot_min");
            string reboot_min_fan = manager.GetPrivateString("main", "reboot_min_fan");
            string reboot_clock = manager.GetPrivateString("main", "reboot_clock");
            string reboot_memory = manager.GetPrivateString("main", "reboot_memory");
            string stat = manager.GetPrivateString("main", "stat");
            string reload = manager.GetPrivateString("main", "reload");
            string pool = manager.GetPrivateString("main", "pool");
            string wallet = manager.GetPrivateString("main", "wallet");
            string t_start = manager.GetPrivateString("main", "t_start");
            string r_min = manager.GetPrivateString("main", "r_min");
            string rt_min = manager.GetPrivateString("main", "rt_min");
            string path = manager.GetPrivateString("main", "path");
            string path2 = manager.GetPrivateString("main", "path2");
            string fan_max = manager.GetPrivateString("main", "fan_max");
            string fan_min = manager.GetPrivateString("main", "fan_min");
            string t_fan_max = manager.GetPrivateString("main", "t_fan_max");
            string t_fan_min = manager.GetPrivateString("main", "t_fan_min");
            string memory = manager.GetPrivateString("main", "memory");
            string clock = manager.GetPrivateString("main", "clock");
            string t_memory = manager.GetPrivateString("main", "t_memory");
            string t_clock = manager.GetPrivateString("main", "t_clock");
            string t_inet = manager.GetPrivateString("main", "t_inet");
            string internet_r = manager.GetPrivateString("main", "internet_r");
            if (reboot_max == "1")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
           
            if (reboot_min == "1")
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (reload == "1")
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if (reboot_max_fan == "1")
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
            if (reboot_min_fan == "1")
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
            if (reboot_clock == "1")
            {
                checkBox6.Checked = true;
            }
            else
            {
                checkBox6.Checked = false;
            }
            if (reboot_memory == "1")
            {
                checkBox7.Checked = true;
            }
            else
            {
                checkBox7.Checked = false;
            }
            if (internet_r == "1")
            {
                checkBox8.Checked = true;
            }
            else
            {
                checkBox8.Checked = false;
            }
            textBox1.Text = max;
            textBox2.Text = min;
            textBox7.Text = t_max;
            textBox8.Text = t_min;
            //textBox4.Text = wallet;
            //textBox9.Text = pool;
            comboBox2.Text = t_start;
            textBox11.Text = rt_min;
            textBox5.Text = r_min;
            textBox3.Text = path;
            textBox12.Text = path2;
            textBox4.Text = fan_max;
            textBox6.Text = fan_min;
            textBox9.Text = t_fan_max;
            textBox10.Text = t_fan_min;
            textBox13.Text = clock;
            textBox14.Text = t_clock;
            textBox15.Text = memory;
            textBox16.Text = t_memory;
            textBox17.Text = t_inet;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_max", "1");
                GlobalVars.reboot_max = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_max", "0");
                GlobalVars.reboot_max = "0";
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            string filename1 = openFileDialog1.SafeFileName;
            string dir = Path.GetDirectoryName(openFileDialog1.FileName);
            //MessageBox.Show(Path.GetDirectoryName(openFileDialog1.FileName));
            textBox3.Text = filename;
            
        string fullPath = Application.StartupPath.ToString();
            INIManager manager = new INIManager(fullPath + "\\my.ini");
            manager.WritePrivateString("main", "path", filename);
            manager.WritePrivateString("main", "filename", filename1);
            manager.WritePrivateString("main", "dir", dir);
            GlobalVars.dir = dir;
            GlobalVars.pathreload = filename;
            GlobalVars.filename = filename1;
            //MessageBox.Show(filename+" без "+ filename1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reload", "1");
                GlobalVars.reload = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reload", "0");
                GlobalVars.reload = "0";
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_min", "1");
                GlobalVars.reboot_min = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_min", "0");
                GlobalVars.reboot_min = "0";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://yobit.io/?bonus=HZAve");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_min_fan", "1");
                GlobalVars.reboot_min_fan = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_min_fan", "0");
                GlobalVars.reboot_min_fan = "0";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_max_fan", "1");
                GlobalVars.reboot_max_fan = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_max_fan", "0");
                GlobalVars.reboot_max_fan = "0";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog2.FileName;
            string filename1 = openFileDialog2.SafeFileName;
            string dir = Path.GetDirectoryName(openFileDialog2.FileName);
            //MessageBox.Show(Path.GetDirectoryName(openFileDialog1.FileName));
            textBox12.Text = filename;

            string fullPath = Application.StartupPath.ToString();
            INIManager manager = new INIManager(fullPath + "\\my.ini");
            manager.WritePrivateString("main", "path2", filename);
            manager.WritePrivateString("main", "filename2", filename1);
            manager.WritePrivateString("main", "dir2", dir);
            GlobalVars.dir2 = dir;
            GlobalVars.pathreload2 = filename;
            GlobalVars.filename2 = filename1;
            //MessageBox.Show(filename+" без "+ filename1);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_clock", "1");
                GlobalVars.reboot_clock = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_clock", "0");
                GlobalVars.reboot_clock = "0";
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_memory", "1");
                GlobalVars.reboot_memory = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "reboot_memory", "0");
                GlobalVars.reboot_memory = "0";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "internet_r", "1");
                GlobalVars.internet_r = "1";
            }
            else
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                manager.WritePrivateString("main", "internet_r", "0");
                GlobalVars.internet_r = "0";
            }
        }
    }
}
