using System;
using System.IO;
using System.Windows.Forms;

namespace HDDLedger
{
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SafeCreateDirectory(documents + @"\HDDLedger\Barcode\");
            SafeCreateDirectory(documents + @"\HDDLedger\Excel\");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FormLedger());
        }


        private static DirectoryInfo SafeCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }

            return Directory.CreateDirectory(path);
        }
    }
}
