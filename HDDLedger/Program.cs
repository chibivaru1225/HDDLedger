using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HDDLedger.Enum;

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
