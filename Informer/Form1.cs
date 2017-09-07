using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using HardwareMonitor.Hardware;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Informer
{
    public partial class Form1 : Form
    {
        Computer pc;
        public Form1()
        {
            InitializeComponent();
            string fullPath = Application.StartupPath.ToString();
            INIManager manager = new INIManager(fullPath + "\\my.ini");
            manager.WritePrivateString("main", "version", "1.2.1");
            pc = new Computer();
            pc.Open();
            pc.GPUEnabled = true;
            ini();
            update();

            //  timer5.Tick += button1_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer3.Enabled = false;
            button2.Visible = false;
            button1.Enabled = true;
            timer11.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;
            timer8.Enabled = false;
            timer9.Enabled = false;
            timer10.Enabled = false;
            timer12.Enabled = false;
            timer13.Enabled = false;
            label6.Text = "Остановлен";
            GlobalVars.timer_t_max = -100;
            GlobalVars.timer_t_min = -100;
            GlobalVars.timer_fan_max = -100;
            GlobalVars.timer_fan_min = -100;
            GlobalVars.timer_r_min = -100;
            GlobalVars.timer_clock = -100;
            GlobalVars.timer_memory = -100;
        }
        public void ini()
        {
            string fullPath = Application.StartupPath.ToString();
            INIManager manager = new INIManager(fullPath + "\\my.ini");
            string email = manager.GetPrivateString("main", "email");
            string secret = manager.GetPrivateString("main", "secret");
            string worker = manager.GetPrivateString("main", "worker");
            string version = manager.GetPrivateString("main", "version");
            string reboot_max = manager.GetPrivateString("main", "reboot_max");
            string reboot_max_fan = manager.GetPrivateString("main", "reboot_max_fan");
            string reboot_min = manager.GetPrivateString("main", "reboot_min");
            string reboot_min_fan = manager.GetPrivateString("main", "reboot_min_fan");
            string reboot_clock = manager.GetPrivateString("main", "reboot_clock");
            string reboot_memory = manager.GetPrivateString("main", "reboot_memory");
            string max = manager.GetPrivateString("main", "max");
            string min = manager.GetPrivateString("main", "min");
            string t_min = manager.GetPrivateString("main", "t_min");
            string t_max = manager.GetPrivateString("main", "t_max");
            string stat = manager.GetPrivateString("main", "stat");
            string pool = manager.GetPrivateString("main", "pool");
            string wallet = manager.GetPrivateString("main", "wallet");
            string t_start = manager.GetPrivateString("main", "t_start");
            string reload = manager.GetPrivateString("main", "reload");
            string r_min = manager.GetPrivateString("main", "r_min");
            string rt_min = manager.GetPrivateString("main", "rt_min");
            string filename = manager.GetPrivateString("main", "filename");
            string path = manager.GetPrivateString("main", "path");
            string dir = manager.GetPrivateString("main", "dir");
            string filename2 = manager.GetPrivateString("main", "filename2");
            string path2 = manager.GetPrivateString("main", "path2");
            string dir2 = manager.GetPrivateString("main", "dir2");
            string fan_max = manager.GetPrivateString("main", "fan_max");
            string t_fan_max = manager.GetPrivateString("main", "t_fan_max");
            string fan_min = manager.GetPrivateString("main", "fan_min");
            string t_fan_min = manager.GetPrivateString("main", "t_fan_min");
            string clock = manager.GetPrivateString("main", "clock");
            string t_clock = manager.GetPrivateString("main", "t_clock");
            string memory = manager.GetPrivateString("main", "memory");
            string t_memory = manager.GetPrivateString("main", "t_memory");
            string t_inet = manager.GetPrivateString("main", "t_inet");
            string internet_r = manager.GetPrivateString("main", "internet_r");
            GlobalVars.internet_r = internet_r;
            if (string.IsNullOrEmpty(t_inet)) { t_inet = "300"; }
            GlobalVars.t_inet = Convert.ToInt32(t_inet);
            if (string.IsNullOrEmpty(t_fan_max)) { t_fan_max = "10"; }
            GlobalVars.t_fan_max = Convert.ToInt32(t_fan_max);
            //  MessageBox.Show(GlobalVars.t_fan_max.ToString());
            if (string.IsNullOrEmpty(t_fan_min)) { t_fan_min = "10"; }
            GlobalVars.t_fan_min = Convert.ToInt32(t_fan_min);
            if (string.IsNullOrEmpty(fan_max)) { fan_max = "100"; }
            GlobalVars.fan_max = Convert.ToInt32(fan_max);
            if (string.IsNullOrEmpty(fan_min)) { fan_min = "0"; }
            GlobalVars.fan_min = Convert.ToInt32(fan_min);
            if (string.IsNullOrEmpty(clock)) { clock = "0"; }
            GlobalVars.clock1 = Convert.ToInt32(clock);
            if (string.IsNullOrEmpty(t_clock)) { t_clock = "2500"; }
            GlobalVars.t_clock = Convert.ToInt32(t_clock);
            if (string.IsNullOrEmpty(memory)) { memory = "0"; }
            if (string.IsNullOrEmpty(t_memory)) { t_memory = "2500"; }
            GlobalVars.memory = Convert.ToInt32(memory);
            GlobalVars.t_memory = Convert.ToInt32(t_memory);
            GlobalVars.dir = dir;
            GlobalVars.filename = filename;
            GlobalVars.pathreload = path;
            GlobalVars.dir2 = dir2;
            GlobalVars.filename2 = filename2;
            GlobalVars.pathreload2 = path2;
            GlobalVars.reload = reload;
            bool start;
            GlobalVars.email = email;
            GlobalVars.worker = worker;
            GlobalVars.secret = secret;
            GlobalVars.versions = version;
            GlobalVars.reboot_max = reboot_max;
            GlobalVars.reboot_max_fan = reboot_max_fan;
            GlobalVars.reboot_min_fan = reboot_min_fan;
            GlobalVars.reboot_min = reboot_min;
            GlobalVars.reboot_clock = reboot_clock;
            GlobalVars.reboot_memory = reboot_memory;
            GlobalVars.stat = stat;
            if (string.IsNullOrEmpty(r_min)) { r_min = "40"; }
            GlobalVars.r_min = Convert.ToInt32(r_min);
            if (string.IsNullOrEmpty(rt_min)) { rt_min = "10"; }
            GlobalVars.rt_min = Convert.ToInt32(rt_min);
            if (string.IsNullOrEmpty(min)) { min = "40"; }
            GlobalVars.min = Convert.ToInt32(min);
            if (string.IsNullOrEmpty(max)) { max = "90"; }
            GlobalVars.max = Convert.ToInt32(max);
            if (string.IsNullOrEmpty(t_min)) { t_min = "10"; }
            GlobalVars.t_min = Convert.ToInt32(t_min);
            if (string.IsNullOrEmpty(t_max)) { t_max = "0"; }
            GlobalVars.t_max = Convert.ToInt32(t_max);
            if (string.IsNullOrEmpty(t_start))
            {
                t_start = "30";
            }
            GlobalVars.t_start = Convert.ToInt32(t_start);
            GlobalVars.pool = pool;
            GlobalVars.wallet = wallet;
            if (string.IsNullOrEmpty(email))
            {
                start = false;
            } else if (string.IsNullOrEmpty(secret))
            {
                start = false;
            } else if (string.IsNullOrEmpty(worker))
            {
                start = false;
            }
            else
            {
                start = true;
                textBox1.Text = email;
                textBox2.Text = secret;
                textBox3.Text = worker;
            }
            if (start)
            {
                timer2.Interval = GlobalVars.t_start * 1000;
                timer2.Enabled = true;
                timer3.Enabled = true;
                timer5.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ini();
                //MessageBox.Show("timer");
                button1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                button2.Visible = true;
                gpu_temp();

            }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
                Log.writeLogLine(ex.Message + "timer tick1");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer11.Enabled = true;
            send();
            timer3.Enabled = false;
            button2.Visible = true;
            button1.Enabled = false;
            GlobalVars.time = 0;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            GlobalVars.t_start = GlobalVars.t_start - 1;
            button1.Text = "Запустить(" + GlobalVars.t_start.ToString() + ")";
        }

        public void gpu_temp()
        {
            try
            {
                pc = new Computer();
                pc.Open();
                pc.GPUEnabled = true;
                GlobalVars.card = "";
                GlobalVars.temp = "";
                GlobalVars.fan = "";
                GlobalVars.load = "";
                GlobalVars.clock = "";
                GlobalVars.mem = "";
                int r_count = 0;
                int c_count = 0;
                int m_count = 0;
                int max_count = 0;
                int min_count = 0;
                int fan_max_count = 0;
                int fan_min_count = 0;
                GlobalVars.counts = 0;
                int temp1 = 0;
                int fan1 = 0;
                int fanmin = 200;
                int tempmin = 200;
                int tempmax = -10;
                int fanmax = -10;
                int clockmin = 99999;
                int memorymin = 99999;
                int clockk1;
                int mem1;
                foreach (var hard in pc.Hardware)// ВЫБИРАЕМ ЖЕЛЕЗО
                {
                    hard.Update();
                    if (hard.HardwareType == HardwareType.GpuAti || hard.HardwareType == HardwareType.GpuNvidia)//КАРТЫ
                    {

                        GlobalVars.counts = GlobalVars.counts + 1;
                        GlobalVars.card += hard.Name + ",";

                        foreach (var sensor in hard.Sensors)//ИДЕМ по сенсорам
                        {
                            // MessageBox.Show(hard.Sensors.ToString());
                            if (sensor.SensorType == SensorType.Clock)
                            {//ЧАСТОТЫ
                                if (sensor.Name == "GPU Core")//ЯДРО
                                {

                                    GlobalVars.clock += sensor.Value.GetValueOrDefault() + ";";
                                    // MessageBox.Show(GlobalVars.clock.Split(new char[] {','}).ToString());
                                    clockk1 = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                    if (clockmin > clockk1)
                                    {
                                        clockmin = clockk1;
                                    }
                                   

                                }
                                if (hard.HardwareType == HardwareType.GpuAti)
                                {
                                    if (sensor.Name == "GPU Memory")//ПАМЯТЬ
                                    {
                                        GlobalVars.mem += sensor.Value.GetValueOrDefault() + ";";
                                        mem1 = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                        if (memorymin > mem1)
                                        {
                                            memorymin = mem1;
                                        }

                                    }

                                }
                                else
                                {
                                    if (sensor.Name == "GPU Memory")//ПАМЯТЬ
                                    {
                                        GlobalVars.mem += sensor.Value.GetValueOrDefault() + ";";
                                        mem1 = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                        if (memorymin > mem1)
                                        {
                                            memorymin = mem1;
                                        }
                                    }
                                }
                            }
                            else if (sensor.SensorType == SensorType.Temperature)//Температура
                            {
                                GlobalVars.temp += sensor.Value.GetValueOrDefault() + ",";
                                temp1 = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                if (tempmin> temp1)
                                {
                                    tempmin = temp1;
                                }
                                if (tempmax < temp1)
                                {
                                    tempmax = temp1;
                                }
                            }
                            else if (sensor.SensorType == SensorType.Control)// FAN
                            {

                                GlobalVars.fan += sensor.Value.GetValueOrDefault() + ",";
                                fan1 = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                if (fanmin > fan1)
                                {
                                    fanmin = fan1;
                                }
                                if (fanmax < fan1)
                                {
                                    fanmax = fan1;
                                }
                                //   MessageBox.Show(fan1.ToString());
                            }
                            else if (sensor.SensorType == SensorType.Load)//LOAD
                            {
                                if (sensor.Name == "GPU Core")
                                {
                                    GlobalVars.load += sensor.Value.GetValueOrDefault() + ",";
                                    //  MessageBox.Show("LOAD +++ "+ sensor.Value.GetValueOrDefault());
                                }
                            }
                            if (GlobalVars.reboot_max == "1")
                            {
                                if (tempmax >= GlobalVars.max)
                                {
                                    //   timer6.Enabled = true;

                                    max_count =  1;
                                }
                                else
                                {
                                    max_count = 0;
                                }

                            }
                            if (GlobalVars.reboot_min == "1")
                            {
                                if (tempmin <= GlobalVars.min)
                                {
                                    min_count =  1;
                                    //timer7.Enabled = true;
                                    //     MessageBox.Show("Карта с низкой т" + temp1);
                                }
                                else
                                {
                                    min_count =  0;

                                }
                            }
                            if (GlobalVars.reboot_max_fan == "1")
                            {
                                if (fanmax >= GlobalVars.fan_max)
                                {

                                    fan_max_count = 1;
                                   // label10.Text = fan_max_count.ToString();
                                }
                                else
                                {
                                    fan_max_count = 0;
                                    //label10.Text = fan_max_count.ToString();
                                }
                            }
                            if (GlobalVars.reboot_min_fan == "1")
                            {
                                if (fanmin <= GlobalVars.fan_min)
                                {

                                    fan_min_count = 1;
                                   // label10.Text = fan_min_count.ToString();
                                }
                                else
                                {
                                    fan_min_count = 0;
                                   // label10.Text = fan_min_count.ToString();
                                }

                                //fan_min_count = 0;
                            }
                            if (GlobalVars.reload == "1")
                            {
                                if (tempmin <= GlobalVars.r_min)
                                {
                                    r_count =  1;
                                   // label10.Text = r_count.ToString();
                                    // timer8.Enabled = true;
                                }
                                else
                                {
                                    r_count =  0;
                                  //  label10.Text = r_count.ToString();
                                    //reload = true;
                                }


                            }
                            if (GlobalVars.reboot_clock == "1")
                            {
                                if (clockmin < GlobalVars.clock1)
                                {
                                    c_count = 1;
                                    // label10.Text = r_count.ToString();
                                    // timer8.Enabled = true;
                                }
                                else
                                {
                                    c_count = 0;
                                    //  label10.Text = r_count.ToString();
                                    //reload = true;
                                }


                            }
                            if (GlobalVars.reboot_memory == "1")
                            {
                                if (memorymin < GlobalVars.memory)
                                {
                                   m_count = 1;
                                    // label10.Text = r_count.ToString();
                                    // timer8.Enabled = true;
                                }
                                else
                                {
                                    m_count = 0;
                                    //  label10.Text = r_count.ToString();
                                    //reload = true;
                                }


                            }

                        }

                    }
                }

                //ПРОВЕРКА
                if (max_count > 0)//max temp
                {
                    //label7.Text = "ON_max";
                    timer6.Enabled = true;
                    label7.Text = "Перегрев!";
                    label9.Text = GlobalVars.timer_t_max.ToString();
                }
                else
                {
                    timer6.Enabled = false;
                    GlobalVars.timer_t_max = -100;
                    
                        label7.Text = "OK";
                        label9.Text = "";
                    
                    
                }
                if (min_count > 0)//min temp
                {
                    
                    label12.Text = "Холодный!";
                    label13.Text = GlobalVars.timer_t_min.ToString();
                    timer7.Enabled = true;
                    
                }
                else
                {
                    timer7.Enabled = false;
                    GlobalVars.timer_t_min = -100;
                  
                        label12.Text = "OK";
                        label13.Text = "";
                    
                }
                if (r_count > 0)
                {
                    timer8.Enabled = true;
                    //  label10.Text = r_count.ToString();
                    
                        label16.Text = "Холодный!";
                        label17.Text = GlobalVars.timer_r_min.ToString();
                   
                }
                else
                {
                    timer8.Enabled = false;
                    GlobalVars.timer_r_min = -100;
                    //  label10.Text = r_count.ToString();

                    label16.Text = "ОК";
                   
                        label17.Text = "";
                    
                    
                }
                if (fan_max_count > 0)
                {
                    timer9.Enabled = true;
                    label19.Text = "Высокие обороты!";
                    label20.Text = GlobalVars.timer_fan_max.ToString();
                }
                else
                {
                    timer9.Enabled = false;
                    GlobalVars.timer_fan_max = -100;
                    label19.Text = "ОК";
                    label20.Text = "";
                }
                if (fan_min_count > 0)
                {
                    timer10.Enabled = true;
                    label21.Text = "Низкие обороты!";
                    label22.Text = GlobalVars.timer_fan_min.ToString();
                }
                else
                {
                    timer10.Enabled = false;
                    GlobalVars.timer_fan_min = -100;
                    label21.Text = "ОК";
                    label22.Text = "";
                }
                //xfnclock
                if (c_count > 0)
                {
                    timer12.Enabled = true;
                    label25.Text = "Низкие частоты ядра!";
                    label26.Text = GlobalVars.timer_clock.ToString();
                }
                else
                {
                    timer12.Enabled = false;
                    GlobalVars.timer_clock = -100;
                    label25.Text = "ОК";
                    label26.Text = "";
                }
                if (m_count > 0)
                {
                      timer13.Enabled = true;
                     label27.Text = "Низкие частоты памяти!";
                     label28.Text = GlobalVars.timer_memory.ToString();
                }
                else
                {
                     timer13.Enabled = false;
                      GlobalVars.timer_memory = -100;
                      label27.Text = "ОК";
                       label28.Text = "";
                }
            }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
                Log.writeLogLine(ex.Message+ "get parameters sensors");
            }
        }
public void send()
{
    try
    {
        string pack = new WebClient().DownloadString("http://allminer.ru/api.php?email=" + GlobalVars.email + "&worker=" + GlobalVars.worker + "&gpu=" + GlobalVars.card + "&temp=" + GlobalVars.temp + "&fan=" + GlobalVars.fan + "&timer=" + GlobalVars.time.ToString() + "&secret=" + GlobalVars.secret + "&v=" + GlobalVars.versions + "&load=" + GlobalVars.load + "&clock=" + GlobalVars.clock + "&mem=" + GlobalVars.mem);
        //string pack = new WebClient().DownloadString("http://myminers.ru/api.php?email=" + GlobalVars.email + "&worker=" + GlobalVars.worker + "&gpu=" + GlobalVars.card + "&temp=" + GlobalVars.temp + "&fan=" + GlobalVars.fan + "&timer=" + GlobalVars.time.ToString());
        label6.Text = pack;
    }
    catch (Exception ex)
    {
        LogFile Log = new LogFile("error");
        Log.writeLogLine(ex.Message + "function send() Отправка на сайт");
    }
}
        public void reboot(string msg, string bat)
        {
            try
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                 string pack = new WebClient().DownloadString("http://allminer.ru/api.php?email=" + GlobalVars.email + "&worker=" + GlobalVars.worker + "&gpu=" + GlobalVars.card + "&temp=" + GlobalVars.temp + "&fan=" + GlobalVars.fan + "&status=6&msg=" +msg);
               // string pack = new WebClient().DownloadString("http://myminers.ru/api.php?email=" + GlobalVars.email + "&worker=" + GlobalVars.worker + "&gpu=" + GlobalVars.card + "&temp=" + GlobalVars.temp + "&fan=" + GlobalVars.fan + "&status=6");
                Process.Start(bat);
            }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
                Log.writeLogLine(ex.Message);
            }
        }
        
        public void update()
        {
            try
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                string v = manager.GetPrivateString("main", "version");
                string pack = new WebClient().DownloadString("http://allminer.ru/api/?method=version");
                Movie m = JsonConvert.DeserializeObject<Movie>(pack);
                string ver = m.version;
                GlobalVars.link = m.link;
                if (v == ver)
                {
                    //MessageBox.Show("У Вас старая версия");
                    linkLabel1.Visible = false;
                }
                else
                {
                    linkLabel1.Visible = true;
                    linkLabel1.Text = "Обновите клиент до версии v" + ver;
                    //MessageBox.Show("Новая версия!!!" + v + " " + ver);
                }

            }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
                Log.writeLogLine(ex.Message);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                string fullPath = Application.StartupPath.ToString();
                INIManager manager = new INIManager(fullPath + "\\my.ini");
                string v = manager.GetPrivateString("main", "version");
                string pack = new WebClient().DownloadString("http://allminer.ru/api/?method=version");
                Movie m = JsonConvert.DeserializeObject<Movie>(pack);
                string ver = m.version;
                GlobalVars.link = m.link;
                if (v == ver)
                {
                    //MessageBox.Show("У Вас старая версия");
                    linkLabel1.Visible = false;
                }
                else
                {
                    linkLabel1.Visible = true;
                    linkLabel1.Text = "Обновите клиент до версии v" + ver;
                    //MessageBox.Show("Новая версия!!!" + v + " " + ver);
                }

            }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
                Log.writeLogLine(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string l = GlobalVars.link;
            System.Diagnostics.Process.Start(l);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            GlobalVars.time = GlobalVars.time + 1;
            int min = GlobalVars.time;
            int d = min / 1440;
            min = min - (d * 1440);
            int h = min / 60;
            min = min - (h * 60);
            label8.Text = ("Дни: " +d.ToString()+ " Часы: " +h.ToString()+ " Минуты: " +min.ToString());
        }
        public void reload(string msg)
        {
            try
            {
                
                timer8.Enabled = false;
                GlobalVars.timer_r_min = -100;
               // MessageBox.Show(GlobalVars.rt_min.ToString());
                //ProcessStartInfo ppsi;
                Process ppsi;
                //ppsi = new ProcessStartInfo("cmd", @"/c taskkill /f /im " + GlobalVars.filename);
                ppsi = Process.Start("cmd", @"/c taskkill /f /im " + GlobalVars.filename);
                //Process.Start(ppsi);
                ppsi.Close();
                System.Threading.Thread.Sleep(1000);
                timer8.Enabled = false;
               GlobalVars.timer_r_min = -100;
                Process psiw;
                psiw = Process.Start("cmd", @"/c taskkill /f /im conhost.exe");
                psiw.Close();
                System.Threading.Thread.Sleep(1000);
                timer8.Enabled = false;
                GlobalVars.timer_r_min = -100;
                Process psi;
                psi = Process.Start("cmd", @"/c taskkill /f /im cmd.exe");
                psi.Close();
                System.Threading.Thread.Sleep(1000);
                timer8.Enabled = false;
                GlobalVars.timer_r_min = -100;
               // Process m;
                //ppsi = new ProcessStartInfo("cmd", @"/c taskkill /f /im " + GlobalVars.filename);
               // m = Process.Start("cmd", @"/c taskkill /f /im " + GlobalVars.miners[i]);
                //Process.Start(ppsi);
               // m.Close();
                System.Threading.Thread.Sleep(1000);
                Process.Start("nice.bat");
               // MessageBox.Show("sas");
                timer8.Enabled = false;
                GlobalVars.timer_r_min = -100;
                System.Threading.Thread.Sleep(1500);
                ProcessStartInfo rpsi;
                rpsi = new ProcessStartInfo();
                   rpsi.WorkingDirectory = GlobalVars.dir2;
                   rpsi.FileName = GlobalVars.pathreload2;
                System.Threading.Thread.Sleep(1000);
                
                Process.Start(rpsi);/**/


                string pack = new WebClient().DownloadString("http://allminer.ru/api.php?email=" + GlobalVars.email + "&worker=" + GlobalVars.worker + "&gpu=" + GlobalVars.card + "&temp=" + GlobalVars.temp + "&fan=" + GlobalVars.fan + "&status=6&msg=" +msg);
                //return;
                timer8.Enabled = false;
                GlobalVars.timer_r_min = -100;
            }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
                Log.writeLogLine(ex.Message);
            }
            }
        public void pool(string pool)
        {
            
            if (pool == "nanozec")
            {
                
                string pack = new WebClient().DownloadString("https://api.nanopool.org/v1/zec/workers/" + GlobalVars.wallet);//свой кошель
                RootObject m = JsonConvert.DeserializeObject<RootObject>(pack);
                foreach (var item in m.data)
                {
                    if (item.id == GlobalVars.worker)
                    {
                        label7.Text = item.hashrate.ToString();
                       // MessageBox.Show(item.hashrate.ToString());
                    }
                }


            }
            else if (pool == "nanoetc")
            {
                string pack = new WebClient().DownloadString("https://api.nanopool.org/v1/etc/workers/" + GlobalVars.wallet);//свой кошель
                RootObject m = JsonConvert.DeserializeObject<RootObject>(pack);
               // MessageBox.Show("12");
                foreach (var item in m.data)
                {
                    if (item.id == GlobalVars.worker)
                    {
                        label7.Text = item.hashrate.ToString();
                        // MessageBox.Show(item.hashrate.ToString());
                    }
                }

            }
            else if (pool == "nanoeth")
            {
                string pack = new WebClient().DownloadString("https://api.nanopool.org/v1/eth/workers/" + GlobalVars.wallet);//свой кошель
                RootObject m = JsonConvert.DeserializeObject<RootObject>(pack);
                foreach (var item in m.data)
                {
                    if (item.id == GlobalVars.worker)
                    {
                        label7.Text = item.hashrate.ToString();
                        // MessageBox.Show(item.hashrate.ToString());
                    }
                }
            }
            else if (pool == "nanosia")
            {
                string pack = new WebClient().DownloadString("https://api.nanopool.org/v1/sia/workers/" + GlobalVars.wallet);//свой кошель
                RootObject m = JsonConvert.DeserializeObject<RootObject>(pack);
                foreach (var item in m.data)
                {
                    if (item.id == GlobalVars.worker)
                    {
                        label7.Text = item.hashrate.ToString();
                        // MessageBox.Show(item.hashrate.ToString());
                    }
                }
            }
            else if (pool == "nanoxmr")
            {
                string pack = new WebClient().DownloadString("https://api.nanopool.org/v1/xmr/workers/" + GlobalVars.wallet);//свой кошель
                RootObject m = JsonConvert.DeserializeObject<RootObject>(pack);
                foreach (var item in m.data)
                {
                    if (item.id == GlobalVars.worker)
                    {
                        label7.Text = item.hashrate.ToString();
                        // MessageBox.Show(item.hashrate.ToString());
                    }
                }
            }
            else if (pool == "nanopasc")
            {
                string pack = new WebClient().DownloadString("https://api.nanopool.org/v1/pasc/workers/" + GlobalVars.wallet);//свой кошель
                RootObject m = JsonConvert.DeserializeObject<RootObject>(pack);
                foreach (var item in m.data)
                {
                    if (item.id == GlobalVars.worker)
                    {
                        label7.Text = item.hashrate.ToString();
                        // MessageBox.Show(item.hashrate.ToString());
                    }
                }
            }
            else if (pool == "nicehash")
            {

                string pack = new WebClient().DownloadString("https://api.nicehash.com/api?method=stats.provider.ex&addr=" + GlobalVars.wallet);//свой кошель
                RootObject m = JsonConvert.DeserializeObject<RootObject>(pack);
                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string fullPath = Application.StartupPath.ToString();
            INIManager manager = new INIManager(fullPath + "\\my.ini");
            string email = textBox1.Text;
            string secret = textBox2.Text;
            string worker1 = textBox3.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введите EMAIL!");
            }
            else if (string.IsNullOrEmpty(secret))
            {
                MessageBox.Show("Введите SECRET KEY!");
            }
            else if (string.IsNullOrEmpty(worker1))
            {
                MessageBox.Show("Задайте имя ригу!");
            }

            else
            {
                manager.WritePrivateString("main", "email", email);
                manager.WritePrivateString("main", "worker", worker1);
                manager.WritePrivateString("main", "secret", secret);
                timer1.Enabled = true;
                timer11.Enabled = true;
                button1.Enabled = false;
                button2.Visible = true;
                timer3.Enabled = false;
                string email1 = manager.GetPrivateString("main", "email");
                string worker = manager.GetPrivateString("main", "worker");
                string secret1 = manager.GetPrivateString("main", "secret");
                GlobalVars.email = email1;
                GlobalVars.worker = worker;
                GlobalVars.secret = secret1;
                //int t = Convert.ToInt32(textBox4.Text);
                //timer1.Interval = t;
                gpu_temp();
                send();
                GlobalVars.time = 0;
                 // MessageBox.Show(GlobalVars.t_fan_max.ToString());
            }
            ini();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            string msg = "Температура выше максимальной, перезагрузка!";
            string bat = "reboot_t_max.bat";
                if (GlobalVars.timer_t_max < 0) {
                    GlobalVars.timer_t_max = GlobalVars.t_max;
                }
                
                if (GlobalVars.timer_t_max == 0)
                {
                if (!GlobalVars.reboot1)
                {
                    reboot(msg, bat);
                    GlobalVars.reboot1 = true;
                   // System.Threading.Thread.Sleep(10000);
                }
                    
                }
                GlobalVars.timer_t_max = GlobalVars.timer_t_max - 1;
               // MessageBox.Show(GlobalVars.timer.ToString());
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(GlobalVars.miners.Length.ToString());
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            string msg = "Температура ниже минимальной, перезагрузка!";
            string bat = "reboot_t_min.bat";
            if (GlobalVars.timer_t_min < 0)
                {
                    GlobalVars.timer_t_min = GlobalVars.t_min;
                }
                if (GlobalVars.timer_t_min == 0)
                {
                if (!GlobalVars.reboot2)
                {
                    reboot(msg, bat);
                    GlobalVars.reboot2 = true;
                    // System.Threading.Thread.Sleep(10000);
                }
            }
                GlobalVars.timer_t_min = GlobalVars.timer_t_min - 1;

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            // MessageBox.Show("Таймер");
            string msg = "Температура ниже минимальной, перезапуск приложения " + GlobalVars.filename2 +"!";
            //string bat = "reboot_r_min.bat";
            if (GlobalVars.timer_r_min < 0)
                {
                    GlobalVars.timer_r_min = GlobalVars.rt_min;
                }
                if (GlobalVars.timer_r_min == 0)
                {
                    
                    reload(msg);
               // timer8.Enabled = false;
                //GlobalVars.timer_r_min = -100;
            }

            
                GlobalVars.timer_r_min = GlobalVars.timer_r_min - 1;
            
            
                
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            string msg = "Обороты выше максимальных, перезагрузка!";
            string bat = "reboot_fan_max.bat";
            if (GlobalVars.timer_fan_max < 0)
            {
               // label10.Text = GlobalVars.t_fan_max.ToString();
                GlobalVars.timer_fan_max = GlobalVars.t_fan_max;
                
            }
            if (GlobalVars.timer_fan_max == 0)
            {
                if (!GlobalVars.reboot3)
                {
                    reboot(msg, bat);
                    GlobalVars.reboot3 = true;
                }
                
            }
            GlobalVars.timer_fan_max = GlobalVars.timer_fan_max - 1;
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            string msg = "Обороты ниже минимальных, перезагрузка!";
            string bat = "reboot_fan_min.bat";
            if (GlobalVars.timer_fan_min < 0)
            {
               // label10.Text = GlobalVars.fan_min.ToString();
                GlobalVars.timer_fan_min = GlobalVars.t_fan_min;
            }
            if (GlobalVars.timer_fan_min == 0)
            {
                if (!GlobalVars.reboot4)
                {
                    reboot(msg, bat);
                    GlobalVars.reboot4 = true;
                }
                
            }
            GlobalVars.timer_fan_min = GlobalVars.timer_fan_min - 1;
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            send();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            string msg = "Частоты ядра ниже минимальных, перезагрузка!";
            string bat = "reboot_clock.bat";
            if (GlobalVars.timer_clock < 0)
            {
                // label10.Text = GlobalVars.fan_min.ToString();
                GlobalVars.timer_clock = GlobalVars.t_clock;
            }
            if (GlobalVars.timer_clock == 0)
            {
                if (!GlobalVars.reboot5)
                {
                    reboot(msg, bat);
                    GlobalVars.reboot5 = true;
                }

            }
            GlobalVars.timer_clock = GlobalVars.timer_clock - 1;
        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            string msg = "Частоты памяти ниже минимальных, перезагрузка!";
            string bat = "reboot_memory.bat";
            if (GlobalVars.timer_memory < 0)
            {
                // label10.Text = GlobalVars.fan_min.ToString();
                GlobalVars.timer_memory = GlobalVars.t_memory;
            }
            if (GlobalVars.timer_memory == 0)
            {
                if (!GlobalVars.reboot6)
                {
                    reboot(msg, bat);
                    GlobalVars.reboot6 = true;
                }

            }
            GlobalVars.timer_memory = GlobalVars.timer_memory - 1;
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void timer14_Tick(object sender, EventArgs e)
        {
            try { 
            string pack = new WebClient().DownloadString("https://ya.ru/");
                if (!string.IsNullOrEmpty(pack)) {
                    label30.Text = "OK";
                    GlobalVars.internet = true;
                }
                else
                {
                    label30.Text = "OK";
                    label30.Text = "Нет доступа к интернету";
                    GlobalVars.internet = false;
                }
                
        }
            catch (Exception ex)
            {
                LogFile Log = new LogFile("error");
        Log.writeLogLine(ex.Message + " INTERNET OFF");
                label30.Text = "Нет доступа к интернету";
                GlobalVars.internet = false;
            }
}

        private void timer15_Tick(object sender, EventArgs e)
        {
            if (!GlobalVars.internet)
            {
                if (GlobalVars.timer_inet < 0)
                {
                    GlobalVars.timer_inet = GlobalVars.t_inet;
                }
                if (GlobalVars.timer_inet == 0)
                {

                }
            }
        }
    }
}
//class nanopul
public class Datum
{
    public string id { get; set; }
    public double hashrate { get; set; }
    public int lastShare { get; set; }
    public int rating { get; set; }
}


public class RootObject
{
    public string workers { get; set; }
    public bool status { get; set; }
    public List<Datum> data { get; set; }
    //nice
    public Result result { get; set; }
    public string method { get; set; }
}
//nice
public class Result
{
    public string addr { get; set; }
    public List<List<object>> workers { get; set; }
    public int algo { get; set; }
}

public class Movie
{
    public string version { get; set; }
    public string link { get; set; }
}
static class GlobalVars
{
    public static string email;
    public static string secret;
    public static string worker;
    public static string versions;
    public static string stat;
    public static string pool;
    public static string wallet;
    public static string card;
    public static string temp;
    public static string fan;
    public static int max;
    public static int min;
    public static int t_min;
    public static int t_max;
    public static int t_start;
    public static int time=-1;
    public static int r_min;
    public static int rt_min;
    public static string link;
    public static int timer_r_min = -100;
    public static int timer_t_min = -100;
    public static int timer_t_max = -100;
    public static string pathreload;
    public static string filename;
    public static string dir;
    public static string pathreload2;
    public static string filename2;
    public static string dir2;
    public static string reload;
    public static string reboot_max;
    public static string reboot_min;
    public static string load;
    public static int counts;
    public static int fan_max;
    public static int fan_min;
    public static string reboot_max_fan;
    public static string reboot_min_fan;
    public static string reboot_clock;
    public static string reboot_memory;
    public static string internet_r;
    public static int timer_fan_max = -100;
    public static int timer_fan_min = -100;
    public static int timer_clock = -100;
    public static int timer_memory = -100;
    public static int timer_inet = -100;
    public static int t_fan_min;
    public static int t_fan_max;
    public static int t_clock;
    public static int t_memory;
    public static int clock1;
    public static int memory;
    public static int t_inet;
    public static string clock;
    public static string mem;
    public static bool reboot1 = false;
    public static bool reboot2 = false;
    public static bool reboot3 = false;
    public static bool reboot4 = false;
    public static bool reboot5 = false;
    public static bool reboot6 = false;
    public static bool internet = true;
    public static string[] miners = { "ccminer.exe", "ethminer.exe", "excavator.exe", "nheqminer.exe", "sgminer.exe", "xmr-stak-cpu.exe", "NsGpuCNMiner.exe", "EthDcrMiner64.exe", "ZecMiner64.exe", "miner.exe", "Optiminer.exe", "prospector.exe" };
    //public static bool nice;
    //итд
}
//Класс для чтения/записи INI-файлов
public class INIManager
{
    //Конструктор, принимающий путь к INI-файлу
    public INIManager(string aPath)
    {
        path = aPath;
    }

    //Конструктор без аргументов (путь к INI-файлу нужно будет задать отдельно)
    public INIManager() : this("") { }

    //Возвращает значение из INI-файла (по указанным секции и ключу) 
    public string GetPrivateString(string aSection, string aKey)
    {
        //Для получения значения
        StringBuilder buffer = new StringBuilder(SIZE);

        //Получить значение в buffer
        GetPrivateString(aSection, aKey, null, buffer, SIZE, path);

        //Вернуть полученное значение
        return buffer.ToString();
    }

    //Пишет значение в INI-файл (по указанным секции и ключу) 
    public void WritePrivateString(string aSection, string aKey, string aValue)
    {
        //Записать значение в INI-файл
        WritePrivateString(aSection, aKey, aValue, path);
    }

    //Возвращает или устанавливает путь к INI файлу
    public string Path { get { return path; } set { path = value; } }

    //Поля класса
    private const int SIZE = 1024; //Максимальный размер (для чтения значения из файла)
    private string path = null; //Для хранения пути к INI-файлу

    //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
    private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);

    //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
    private static extern int WritePrivateString(string section, string key, string str, string path);
}
class LogFile
{
    private System.IO.StreamWriter sw;

    public LogFile(string path)
    {
        try
        {
            sw = new System.IO.StreamWriter(path + ".log", true, Encoding.UTF8);
        }
        catch (System.IO.IOException e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
        }
    }
    ~LogFile()
    {
        sw.Close();
    }

    public void writeLogLine(string line)
    {
        DateTime presently = DateTime.Now;
        line = presently.ToString() + " - " + line;
        sw.WriteLine(line);
        sw.Flush();
        sw.Close();
    }
}