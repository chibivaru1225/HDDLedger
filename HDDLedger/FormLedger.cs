using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static HDDLedger.Enum;

namespace HDDLedger
{
    public partial class FormLedger : Form
    {
        private HDDLedgerColumnType ct;

        public static BindingList<HDDInfoRow> Rows { get; set; }

        public FormLedger()
        {
            InitializeComponent();

            dgvHDD.AutoGenerateColumns = false;
            dgvHDD.AllowUserToAddRows = false;

            SetColumnBindingName();

            this.Load += FormLedger_Load;
            ct = new HDDLedgerColumnType(HDDLedgerColumnTypes.NONE);

            btnAdd.Click += ButtonAdd_Click;
            btnStateChange.Click += ButtonStateChange_Click;
            btnStateChangeContinuous.Click += BtnStateChangeContinuous_Click;
            btnDetail.Click += ButtonDetail_Click;
            btnPrint.Click += ButtonPrint_Click;
            btnRowDelete.Click += ButtonRowDelete_Click;

            dgvHDD.RowPrePaint += dgvHDD_RowPrePaint;
            dgvHDD.ColumnHeaderMouseClick += dgvHDD_ColumnHeaderMouseClick;
        }

        private void dgvHDD_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender is DataGridView dgv && dgv != null)
            {
                var column = new HDDLedgerColumnType(dgv.Columns[e.ColumnIndex].DataPropertyName);

                var rows = (from a in Rows
                            select a).ToList();

                switch (column.SortColumnName)
                {
                    case nameof(HDDInfoRow.Choose):
                        if (column.Value == ct.Value)
                            ct = HDDLedgerColumnTypes.NONE;
                        else
                            ct = column;

                        foreach (var row in Rows)
                            row.Choose = column.Value == ct.Value;
                        break;
                    default:
                        if (column.Value == ct.Value)
                        {
                            rows = (from a in rows
                                    orderby a[column.SortColumnName] descending
                                    select a).ToList();
                            ct = HDDLedgerColumnTypes.NONE;
                        }
                        else
                        {
                            rows = (from a in rows
                                    orderby a[column.SortColumnName] ascending
                                    select a).ToList();
                            ct = column;
                        }
                        break;
                }

                Rows = new BindingList<HDDInfoRow>(rows);
                dgvHDD.DataSource = Rows;
            }
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
            var json = JsonConvert.SerializeObject(Rows.OrderBy(x => x.Renban));

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
