using MetaOptimizer.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetaOptimizer
{
    public partial class Form1 : Form
    {
        private Color defaultColor = Color.FromArgb(255, 255, 255);
        private Color optimizedColor = Color.FromArgb(100, 100, 255);

        private ConsoleFormat console;

        public Form1()
        {
            InitializeComponent();

            console = new ConsoleFormat();
            console.SetLevel(ConsoleFormat.LogLevel.DEBUG);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowMessage();

            CheckPlatform();
            UpdateStatus();
        }

        private void ShowMessage()
        {
            if (Settings.Default.AgreeToUse)
            {
                return;
            }

            DialogResult ret = MessageBox.Show("警告: このソフトウェアはレジストリ操作を行います。\nほとんどの場合はシステムには何も影響は与えませんが、不安な方はこのソフトウェアを使用しないでください。\n\n本当にこのソフトウェアを使用しますか？", "MetaOptimizer Alpha", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (ret == DialogResult.OK)
            {
                Settings.Default.AgreeToUse = true;
                Settings.Default.Save();
                return;
            }
            else
            {
                Application.Exit();
            }
        }

        // Default Button Click
        private async void default_Button_Click(object sender, EventArgs e)
        {
            default_Button.Enabled = false;
            steamvr_Button.Enabled = false;

            await Task.Run(() => Task_Default());

            default_Button.Enabled = true;
            steamvr_Button.Enabled = true;
        }

        // SteamVR Button Click
        private async void steamvr_Button_Click(object sender, EventArgs e)
        {
            default_Button.Enabled = false;
            steamvr_Button.Enabled = false;

            await Task.Run(() => Task_SteamVR());

            default_Button.Enabled = true;
            steamvr_Button.Enabled = true;
        }

        private void Task_Default()
        {
            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Setting Registry...";
            }));
            Set_Registry(Settings.Default.RegistryName, Settings.Default.KeyName, 0);

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Restarting Service...";
            }));
            Restart_Service(Settings.Default.ServiceName);

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Wait a moment...";
            }));
            UpdateStatus();

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Resetted to Default!";
            }));
        }

        private void Task_SteamVR()
        {
            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Setting Registry...";
            }));
            Set_Registry(Settings.Default.RegistryName, Settings.Default.KeyName, 1);

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Restarting Service...";
            }));
            Restart_Service(Settings.Default.ServiceName);

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Wait a moment...";
            }));
            UpdateStatus();

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "Boom! Optimized!";
            }));
        }

        private void UpdateStatus()
        {
            int value = Get_Registry(Settings.Default.RegistryName, Settings.Default.KeyName);

            if (value != -1)
            {
                if (value == 0)
                {
                    state_Label.Text = "Default";
                    state_Label.ForeColor = defaultColor;
                }
                else if (value == 1)
                {
                    state_Label.Text = "SteamVR";
                    state_Label.ForeColor = optimizedColor;
                }
            }
            else
            {
                MessageBox.Show($"Unable to find registry. \nMeta Appが正常にインストールされているかご確認ください。", "Optimize Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            UpdateServiceStatus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateServiceStatus();
        }

        private void UpdateServiceStatus()
        {
            using (var sc = new ServiceController(Settings.Default.ServiceName))
            {
                statusStrip1.Invoke(new Action(() =>
                {
                    servicemode.Text = $"{Settings.Default.ServiceName}: {sc.Status.ToString()}";
                }));
            }
        }

        // Check OS Platform
        private void CheckPlatform()
        {
            var platform = Environment.OSVersion.Platform;

            // Check OS Platform
            if (platform == PlatformID.Win32NT)
            {
                return;
            }
            else
            {
                MessageBox.Show($"This application is only supported on Windows NT. \nCurrent Platform: {platform.ToString()}", "Unsupported Platform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        // Restart Service Function
        private void Restart_Service(string serviceName)
        {
            try
            {
                using (var sc = new ServiceController(serviceName))
                {
                    // まずOculusを停止
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        console.Debug($"{serviceName} Stopping...", nameof(Name));
                        sc.Stop();
                        console.Debug($"Stopped!", nameof(Name));
                    }
                    else if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        console.Debug($"{serviceName} already Stopped!", nameof(Name));
                    }
                }

                using (var sc = new ServiceController(serviceName))
                {
                    // 次にOculusを起動
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        console.Debug($"{serviceName} Starting...", nameof(Name));
                        sc.Start();
                        console.Debug("Started!", nameof(Name));
                    }
                    else if (sc.Status == ServiceControllerStatus.Running)
                    {
                        console.Debug($"{serviceName} already Started!", nameof(Name));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Optimize Failed! (Restart Service) \n{ex.Message}", "Optimize Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // Registry Get Function
        private int Get_Registry(string path, string keyname)
        {
            try
            {
                // システム関数から値をゲット
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(path))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(keyname, 0);

                        if (value is int dwordvalue)
                            return dwordvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Optimize Failed! (Get Registry) \n{ex.Message}", "Optimize Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return -1;
        }

        // Registry Set Function
        private void Set_Registry(string path, string keyname, int value)
        {
            try
            {
                // システム関数から値をゲット
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(path))
                {
                    if (key != null)
                    {
                        key.SetValue(keyname, value, RegistryValueKind.DWord);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Optimize Failed! (Set Registry) \n{ex.Message}", "Optimize Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
