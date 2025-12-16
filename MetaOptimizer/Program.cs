using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetaOptimizer
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 管理者権限チェック
            if (!IsRunAsAdmin())
            {
                try
                {
                    var proc = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName,
                        UseShellExecute = true,
                        Verb = "runas" // 管理者として実行
                    };
                    System.Diagnostics.Process.Start(proc);
                }
                catch
                {
                    MessageBox.Show("管理者権限が必要です。", "権限エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // 管理者権限で実行中か判定
        private static bool IsRunAsAdmin()
        {
            try
            {
                var wi = System.Security.Principal.WindowsIdentity.GetCurrent();
                var wp = new System.Security.Principal.WindowsPrincipal(wi);
                return wp.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }
    }
}
