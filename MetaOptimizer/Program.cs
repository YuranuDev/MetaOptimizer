using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetaOptimizer
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// 

        private static System.Threading.Mutex mutex;

        [STAThread]
        static void Main()
        {

            // すでに起動中のアプリがないか確認
            bool mutexchk;
            bool canhandle = false;

            mutex = new System.Threading.Mutex(false, "MetaOptimizer_Checking_Mutex", out mutexchk);

            if (mutexchk)
            {
                canhandle = mutex.WaitOne(0, false);
            }

            if (!canhandle)
            {
                // すでに起動中の場合はメッセージを表示して終了
                MessageBox.Show("MetaOptimizerはすでに起動しています。", "多重起動エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            // アプリケーションの起動
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
