using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDDLedger
{
    public partial class FormAddRow : Form
    {
        public bool OpenExcel { get; set; }

        private static FormAddRow instance;

        public static FormAddRow Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormAddRow();

                return instance;
            }
        }

        private FormAddRow()
        {
            InitializeComponent();

            this.Shown += FormAddRow_Shown;
            this.FormClosing += FormAddRow_FormClosing;
            this.btnRegist.Click += BtnRegist_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void FormAddRow_VisibleChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FormAddRow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void BtnRegist_Click(object sender, EventArgs e)
        {
            if (false == string.IsNullOrEmpty(txtHDDName.Text.Trim()))
            {
                var row = new HDDInfoRow();

                row.HDDName = txtHDDName.Text.Trim();
                row.RegisterTime = DateTime.Now;
                row.LatestUpdateTime = DateTime.Now;
                row.Renban = FormLedger.Rows == null || FormLedger.Rows.Count() == 0 ? 1 : FormLedger.Rows.Max(x => x.Renban) + 1;
                row.State = Enum.HDDStateTypes.BeforeErased;


                var file = Excel.CreateLabel(row);

                if (OpenExcel)
                    Process.Start(file);

                FormLedger.Rows.Add(row);
                FormLedger.UpdateData();

                if (cbContinuousScan.Checked)
                    txtHDDName.Clear();
                else
                    this.Visible = false;
            }
            else
            {
                MessageBox.Show(this, "HDD名が入力されていません。", "HDD台帳");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormAddRow_Shown(object sender, EventArgs e)
        {
            txtHDDName.Clear();
            txtHDDName.Focus();
            cbContinuousScan.Checked = false;
        }
    }
}
