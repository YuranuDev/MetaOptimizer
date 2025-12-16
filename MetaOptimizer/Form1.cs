using MetaOptimizer.Properties;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MetaOptimizer
{
    public partial class Form1 : Form
    {
        private Color defaultColor = Color.FromArgb(255, 255, 255);
        private Color optimizedColor = Color.FromArgb(100, 100, 255);
        private Color processingColor = Color.FromArgb(150, 150, 150);

        private bool isProcessing = false;

        private Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

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

            if (ver != null)
            {
                versionText.Text = $"v{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}";
            }
        }

        private void ShowMessage()
        {
            if (Settings.Default.AgreeToUse)
            {
                return;
            }

            DialogResult ret1 = MessageBox.Show("このツールは必ず説明書を読んでから使用してください。\nこのツールの説明書は読みましたか？\n\n(「いいえ」を押すと説明書のページが開かれます。)", "MetaOptimizer Alpha", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (ret1 == DialogResult.Cancel)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/YuranuDev/MetaOptimizer",
                    UseShellExecute = true
                });
                

                DialogResult ret2 = MessageBox.Show("注意: このソフトウェアはレジストリ操作を行います。\nほとんどの場合、システムには何も影響は与えませんが、不安な方はこのソフトウェアを使用しないでください。\n\n本当にこのソフトウェアを使用しますか？", "MetaOptimizer Alpha", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (ret2 == DialogResult.OK)
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
        }

        // Default Button Click
        private async void default_Button_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                MessageBox.Show("現在処理中です。", "Processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isProcessing = true;

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "通常モード 実行";
            }));

            default_Button.Enabled = false;
            steamvr_Button.Enabled = false;

            await Task.Run(async () => await Run_Change(0));

            default_Button.Enabled = true;
            steamvr_Button.Enabled = true;

            isProcessing = false;
        }

        // SteamVR Button Click
        private async void steamvr_Button_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                MessageBox.Show("現在処理中です。", "Processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isProcessing = true;

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "最適化モード 実行";
            }));

            default_Button.Enabled = false;
            steamvr_Button.Enabled = false;

            await Task.Run(async () => await Run_Change(1));

            default_Button.Enabled = true;
            steamvr_Button.Enabled = true;

            isProcessing = false;
        }

        private async Task Run_Change(int value)
        {
            DialogResult res = MessageBox.Show("万が一の問題を避けるため、Link接続などを一時的に切断することをお勧めします。\nまた、再使用時は「Meta Horizon Link」を起動することをお勧めします。\n\n実行しますか？", "Optimize Start", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (res == DialogResult.Cancel)
            {
                statusStrip1.Invoke(new Action(() =>
                {
                    statusText.Text = "最適化処理 キャンセル";
                }));
                return;
            }

            state_Label.ForeColor = processingColor;

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "レジストリ設定中...";
            }));
            Set_Registry(Settings.Default.RegistryName, Settings.Default.KeyName, value);

            await Task.Delay(100);

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "サービスを再起動中...";
            }));
            Restart_Service(Settings.Default.ServiceName);

            await Task.Delay(100);

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "しばらくお待ちください";
            }));
            UpdateStatus();

            await Task.Delay(100);

            statusStrip1.Invoke(new Action(() =>
            {
                statusText.Text = "変更処理完了";
            }));
        }

        private void UpdateStatus()
        {
            int value = Get_Registry(Settings.Default.RegistryName, Settings.Default.KeyName);

            if (value != -1)
            {
                if (value == 0)
                {
                    state_Label.Text = "通常 モード";
                    state_Label.ForeColor = defaultColor;
                }
                else if (value == 1)
                {
                    state_Label.Text = "最適化 モード";
                    state_Label.ForeColor = optimizedColor;
                }
            }
            else
            {
                MessageBox.Show($"Meta Appが正常にインストールされているかご確認ください。", "Optimize Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    // 起動時
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        servicemode.ForeColor = Color.DarkGreen;
                        servicemode.Text = $"OVRサービス: 実行中";
                    }
                    // 停止時
                    else if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        servicemode.ForeColor = Color.DarkRed;
                        servicemode.Text = $"OVRサービス: 停止中";
                    }
                    // 起動待機中
                    else if (sc.Status == ServiceControllerStatus.StartPending)
                    {
                        servicemode.ForeColor = Color.Orange;
                        servicemode.Text = $"OVRサービス: 起動処理中";
                    }
                    // 停止待機中
                    else if (sc.Status == ServiceControllerStatus.StopPending)
                    {
                        servicemode.ForeColor = Color.Orange;
                        servicemode.Text = $"OVRサービス: 停止処理中";
                    }
                    else
                    {
                        servicemode.ForeColor = Color.Yellow;
                        servicemode.Text = $"サービス: {sc.Status.ToString()}";
                    }
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
                MessageBox.Show($"このソフトウェアはWindowsのみで動作します。\n現在のプラットフォーム: {platform.ToString()}", "Unsupported Platform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        // Restart Service Function
        private async void Restart_Service(string serviceName)
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

                await Task.Delay(200);

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 処理中の場合、警告文を表記
            if (isProcessing)
            {
                DialogResult res = MessageBox.Show("現在最適化処理中です。本当に終了しますか？", "Processing", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
