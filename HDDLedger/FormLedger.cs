using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using static HDDLedger.Enum;
using System.Diagnostics;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Spreadsheet;

namespace HDDLedger
{
    public partial class FormLedger : Form
    {
        public static BindingList<HDDInfoRow> Rows { get; set; }

        public FormLedger()
        {
            InitializeComponent();

            dgvHDD.AutoGenerateColumns = false;
            dgvHDD.AllowUserToAddRows = false;

            SetColumnBindingName();

            this.Load += FormLedger_Load;

            btnAdd.Click += ButtonAdd_Click;
            btnStateChange.Click += ButtonStateChange_Click;
            btnStateChangeContinuous.Click += BtnStateChangeContinuous_Click;
            btnDetail.Click += ButtonDetail_Click;
            btnPrint.Click += ButtonPrint_Click;
            btnRowDelete.Click += ButtonRowDelete_Click;

            dgvHDD.RowPrePaint += dgvHDD_RowPrePaint;
        }

        private void BtnStateChangeContinuous_Click(object sender, EventArgs e)
        {
            FormStateChangeContinuous.Instance.ShowDialog(this);
        }

        private void dgvHDD_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHDD.Rows[e.RowIndex].DefaultCellStyle.BackColor = Rows[e.RowIndex].StateColor;
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            FormPrint.Instance.ShowDialog(this);
        }

        private void ButtonDetail_Click(object sender, EventArgs e)
        {
            FormRowDetail.Instance.ShowDialog(this);
        }

        private void ButtonRowDelete_Click(object sender, EventArgs e)
        {
            EditConfirmed();
            var selectrows = (from a in Rows
                              where a.Choose == true
                              select a).ToArray();

            if (selectrows.Count() == 0)
            {
                MessageBox.Show(this, "行が選択されていません。", "HDD台帳");
            }
            else
            {
                var result = MessageBox.Show(this, "削除すると戻せません。よろしいですか？", "HDD台帳", MessageBoxButtons.OKCancel);

                if (result != DialogResult.OK)
                    return;

                foreach (var row in selectrows)
                    Rows.Remove(row);

                UpdateData();

                MessageBox.Show(this, "削除しました", "HDD台帳");
            }
        }

        private void ButtonStateChange_Click(object sender, EventArgs e)
        {
            EditConfirmed();
            var selectrows = (from a in Rows
                              where a.Choose == true
                              select a);

            if (selectrows.Count() == 0)
            {
                MessageBox.Show(this, "行が選択されていません。", "HDD台帳");
            }
            else
            {
                var discard = (from a in selectrows
                               where a.State.Value == HDDStateTypes.Discard
                               select a);

                if (discard.Count() != 0)
                {
                    var result = MessageBox.Show(this, "廃棄済のHDDの状態を変更しますか？", "HDD台帳", MessageBoxButtons.OKCancel);

                    if (result != DialogResult.OK)
                        return;
                }

                FormStateChange.Instance.Rows = selectrows;
                FormStateChange.Instance.ShowDialog(this);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddRow.Instance.ShowDialog(this);

            dgvHDD.FirstDisplayedScrollingRowIndex = dgvHDD.Rows.Count - 1;
        }

        private void FormLedger_Load(object sender, EventArgs e)
        {
            try
            {
                var rows = GetData();
                Rows = rows == null ? new BindingList<HDDInfoRow>() : rows;

                dgvHDD.DataSource = Rows;
                dgvHDD.FirstDisplayedScrollingRowIndex = dgvHDD.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetColumnBindingName()
        {
            chChoose.DataPropertyName = nameof(HDDInfoRow.Choose);
            chRenban.DataPropertyName = nameof(HDDInfoRow.Renban);
            chName.DataPropertyName = nameof(HDDInfoRow.HDDName);
            chState.DataPropertyName = nameof(HDDInfoRow.StateViewValue);
            chRegisterTime.DataPropertyName = nameof(HDDInfoRow.RegisterTimeStr);
            chUpdateTime.DataPropertyName = nameof(HDDInfoRow.LatestUpdateTimeStr);
        }

        public static void UpdateData()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var json = JsonConvert.SerializeObject(Rows);

            using (StreamWriter sw = new StreamWriter(documents + @"\HDDLedger\Data.json", false, Encoding.ASCII))
            {
                sw.Write(json);
            }
        }

        public static BindingList<HDDInfoRow> GetData()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filepath = documents + @"\HDDLedger\Data.json";

            if (File.Exists(filepath) == false)
                return null;

            using (StreamReader sr = new StreamReader(filepath))
            {
                var json = sr.ReadToEnd();

                return JsonConvert.DeserializeObject<BindingList<HDDInfoRow>>(json);
            }
        }

        public void EditConfirmed()
        {
            this.dgvHDD.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
