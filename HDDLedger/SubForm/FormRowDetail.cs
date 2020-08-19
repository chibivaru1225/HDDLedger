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
using static HDDLedger.Enum;

namespace HDDLedger
{
    public partial class FormRowDetail : Form
    {
        private static FormRowDetail instance;

        private HDDInfoRow row;

        public static FormRowDetail Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormRowDetail();

                return instance;
            }
        }

        private FormRowDetail()
        {
            InitializeComponent();

            cbState.ValueMember = nameof(ComboBoxStateItem.Types);
            cbState.DisplayMember = nameof(ComboBoxStateItem.Display);

            SetComboBoxes();

            this.Shown += FormRowDetail_Shown;
            this.FormClosing += FormRowDetail_FormClosing;
            this.VisibleChanged += FormRowDetail_VisibleChanged;

            btnSearch.Click += ButtonSearch_Click;
            btnClear.Click += BtnClear_Click;
            btnUpdate.Click += ButtonUpdate_Click;
            btnLabelPrint.Click += BtnLabelPrint_Click;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.txtRenban.Clear();
            this.txtHDDName.Clear();
            this.txtDetailRenban.Clear();
            this.txtDetailHDDName.Clear();
            this.cbState.SelectedValue = HDDStateTypes.NONE;
            this.txtDetailRegisterTime.Clear();
            this.txtDetailUpdateTime.Clear();

            this.txtRenban.Focus();
            row = null;
        }

        private void BtnLabelPrint_Click(object sender, EventArgs e)
        {
            if (row == null)
            {
                MessageBox.Show(this, "行が選択されていません。", "HDD台帳");
                return;
            }

            var result = MessageBox.Show(this, "ラベルを再出力しますか？", "HDD台帳", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                var file = Excel.CreateLabel(row);

                Process.Start(file);
            }
        }

        private void FormRowDetail_VisibleChanged(object sender, EventArgs e)
        {
            this.txtRenban.Clear();
            this.txtHDDName.Clear();
            this.txtDetailRenban.Clear();
            this.txtDetailHDDName.Clear();
            this.cbState.SelectedValue = HDDStateTypes.NONE;
            this.txtDetailRegisterTime.Clear();
            this.txtDetailUpdateTime.Clear();

            this.txtRenban.Focus();
            row = null;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRenban.Text.Trim()) && String.IsNullOrEmpty(txtHDDName.Text.Trim()))
            {
                MessageBox.Show(this, "連番もしくはHDD名を入力してください", "HDD台帳");
                return;
            }

            var srows = (from a in FormLedger.Rows
                         select a);

            if (String.IsNullOrEmpty(txtRenban.Text.Trim()) == false)
            {
                srows = (from a in srows
                         where a.BarcodeRenban == txtRenban.Text.Trim().PadLeft(8, '0')
                         select a);
            }

            if (String.IsNullOrEmpty(txtHDDName.Text.Trim()) == false)
            {
                srows = (from a in srows
                         where a.HDDName.Contains(txtHDDName.Text.Trim())
                         select a);
            }

            if (srows.Count() == 0)
            {
                MessageBox.Show(this, "HDDが見つかりませんでした。検索条件を変更してください。", "HDD台帳");
                return;
            }
            else if (srows.Count() != 1)
            {
                MessageBox.Show(this, "2件以上のHDDが見つかりました。表示できません。検索条件を変更してください。", "HDD台帳");
                return;
            }
            else
            {
                row = srows.FirstOrDefault();
                SetRowDetail(row);
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if(row == null)
            {
                MessageBox.Show(this, "行が選択されていません。", "HDD台帳");
                return;
            }

            if (cbState.SelectedValue is HDDStateTypes type)
            {
                if (String.IsNullOrEmpty(txtDetailHDDName.Text.Trim()))
                {
                    MessageBox.Show(this, "HDD名は空白にできません。HDD名を入力してください", "HDD台帳");
                    return;
                }

                if (type == HDDStateTypes.NONE)
                {
                    MessageBox.Show(this, "状態は空白にできません。状態を変更してください", "HDD台帳");
                    return;
                }

                var result = MessageBox.Show(this, "変更を保存しますか？", "HDD台帳", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    row.State = type;
                    row.HDDName = txtDetailHDDName.Text.Trim();
                    row.LatestUpdateTime = DateTime.Now;

                    FormLedger.UpdateData();

                    MessageBox.Show(this, "変更を保存しました。", "HDD台帳");

                    SetRowDetail(row);
                }
            }
        }

        private void FormRowDetail_Shown(object sender, EventArgs e)
        {
            this.txtRenban.Clear();
            this.txtHDDName.Clear();
            this.txtDetailRenban.Clear();
            this.txtDetailHDDName.Clear();
            this.cbState.SelectedValue = HDDStateTypes.NONE;
            this.txtDetailRegisterTime.Clear();
            this.txtDetailUpdateTime.Clear();

            this.txtRenban.Focus();
        }

        private void FormRowDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void SetRowDetail(HDDInfoRow row)
        {
            this.txtDetailRenban.Text = row.BarcodeRenban;
            this.txtDetailHDDName.Text = row.HDDName;
            this.cbState.SelectedValue = row.State.Value;
            this.txtDetailRegisterTime.Text = row.RegisterTimeStr;
            this.txtDetailUpdateTime.Text = row.LatestUpdateTimeStr;
        }

        private void SetComboBoxes()
        {
            var cblist = new List<ComboBoxStateItem>();
            cblist.Clear();

            var tcgnone = new ComboBoxStateItem();
            tcgnone.HDDState = HDDStateTypes.NONE;

            cblist.Add(tcgnone);

            foreach (var tcg in System.Enum.GetValues(typeof(HDDStateTypes)))
            {
                if (tcg is HDDStateTypes type && type != HDDStateTypes.NONE)
                {
                    var item = new ComboBoxStateItem();
                    item.HDDState = type;

                    cblist.Add(item);
                }
            }

            cbState.DataSource = cblist;
        }

        private class ComboBoxStateItem
        {
            public HDDStateType HDDState { get; set; }

            public HDDStateTypes Types => HDDState.Value;

            public string Display => HDDState.ViewValue;
        }
    }
}
