using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HDDLedger.Enum;

namespace HDDLedger
{
    public partial class FormStateChangeContinuous : Form
    {
        private static FormStateChangeContinuous instance;

        public static FormStateChangeContinuous Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormStateChangeContinuous();

                return instance;
            }
        }

        private FormStateChangeContinuous()
        {
            InitializeComponent();

            this.Shown += FormStateChangeContinuous_Shown;
            this.VisibleChanged += FormStateChangeContinuous_VisibleChanged;

            this.cbCheckState.CheckedChanged += cbCheckState_CheckedChanged;
            this.btnClear.Click += btnClear_Click;
            this.btnRegist.Click += btnRegist_Click;

            cbBaseState.ValueMember = nameof(ComboBoxStateItem.Types);
            cbBaseState.DisplayMember = nameof(ComboBoxStateItem.Display);

            cbFocusControl.ValueMember = nameof(ComboBoxFocusItem.Types);
            cbFocusControl.DisplayMember = nameof(ComboBoxFocusItem.Display);

            cbChangeableHDDState.ValueMember = nameof(ComboBoxStateItem.Types);
            cbChangeableHDDState.DisplayMember = nameof(ComboBoxStateItem.Display);

            SetComboBoxes();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (cbBaseState.SelectedValue is HDDStateTypes type)
            {
                if (String.IsNullOrEmpty(txtBaseRenban.Text.Trim()) && String.IsNullOrEmpty(txtBaseHDDName.Text.Trim()))
                {
                    MessageBox.Show(this, "検索条件が入力されていません。連番かHDD名を入力してください", "HDD台帳");
                    return;
                }

                if (type == HDDStateTypes.NONE)
                {
                    MessageBox.Show(this, "変更後状態は空白にできません。値を変更してください", "HDD台帳");
                    return;
                }

                var rows = (from a in FormLedger.Rows
                            select a);


                rows = (from a in rows
                        where a.HDDName == txtBaseHDDName.Text.Trim() ||
                              a.BarcodeRenban == txtBaseRenban.Text.Trim()
                        select a);

                if (rows.Count() == 0)
                {
                    MessageBox.Show(this, "アイテムが見つかりませんでした。\n検索条件を変更してください", "HDD台帳");
                    return;
                }
                else if (rows.Count() != 1)
                {
                    MessageBox.Show(this, "2件以上のHDDが見つかりました。変更できません。検索条件を変更してください。", "HDD台帳");
                    return;
                }

                var row = rows.FirstOrDefault();

                if (cbCheckState.Checked && cbChangeableHDDState.SelectedValue is HDDStateTypes type2)
                {
                    if (type2 == HDDStateTypes.NONE)
                    {
                        MessageBox.Show(this, "変更前状態は空白にできません。\n値を変更するか、チェックを外してください", "HDD台帳");
                        return;
                    }

                    if (row.State.Value != type2)
                    {
                        var result = MessageBox.Show(this, "指定された状態ではないHDDを読み取りました。\n状態を変更しますか？\nHDDの状態:" + row.State.ViewValue, "HDD台帳", MessageBoxButtons.OKCancel);

                        if (result == DialogResult.Cancel)
                            return;
                    }
                }

                row.State = type;
                FormLedger.UpdateData();
                BasicPanel_Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            BasicPanel_Clear();
        }

        private void cbCheckState_CheckedChanged(object sender, EventArgs e)
        {
            cbChangeableHDDState.Enabled = cbCheckState.Checked;

            if (cbChangeableHDDState.Enabled == false)
                cbChangeableHDDState.SelectedValue = HDDStateTypes.NONE;
        }

        private void BasicPanel_Clear(bool clearstate = false)
        {
            txtBaseRenban.Clear();
            txtBaseHDDName.Clear();

            if (clearstate)
                cbBaseState.SelectedValue = HDDStateTypes.NONE;
        }

        private void OptionPanel_Clear()
        {
            cbCheckState.Checked = false;
            cbFocusControl.SelectedValue = NextFocusKbns.Renban;
            cbChangeableHDDState.SelectedValue = HDDStateTypes.NONE;
        }

        private void FormStateChangeContinuous_VisibleChanged(object sender, EventArgs e)
        {
            BasicPanel_Clear(true);
            OptionPanel_Clear();
        }

        private void FormStateChangeContinuous_Shown(object sender, EventArgs e)
        {
            BasicPanel_Clear(true);
            OptionPanel_Clear();
        }

        private void SetComboBoxes()
        {
            var cbstatelist1 = new List<ComboBoxStateItem>();
            cbstatelist1.Clear();

            var cbnone1 = new ComboBoxStateItem();
            cbnone1.HDDState = HDDStateTypes.NONE;

            cbstatelist1.Add(cbnone1);

            foreach (var tcg in System.Enum.GetValues(typeof(HDDStateTypes)))
            {
                if (tcg is HDDStateTypes type && type != HDDStateTypes.NONE)
                {
                    var item = new ComboBoxStateItem();
                    item.HDDState = type;

                    cbstatelist1.Add(item);
                }
            }

            cbBaseState.DataSource = cbstatelist1;


            var cbstatelist2 = new List<ComboBoxStateItem>();
            cbstatelist2.Clear();

            var cbnone2 = new ComboBoxStateItem();
            cbnone2.HDDState = HDDStateTypes.NONE;

            cbstatelist2.Add(cbnone2);

            foreach (var tcg in System.Enum.GetValues(typeof(HDDStateTypes)))
            {
                if (tcg is HDDStateTypes type && type != HDDStateTypes.NONE)
                {
                    var item = new ComboBoxStateItem();
                    item.HDDState = type;

                    cbstatelist2.Add(item);
                }
            }

            cbChangeableHDDState.DataSource = cbstatelist2;


            var cbfocuslist = new List<ComboBoxFocusItem>();
            cbfocuslist.Clear();

            foreach (var tcg in System.Enum.GetValues(typeof(NextFocusKbns)))
            {
                if (tcg is NextFocusKbns type && type != NextFocusKbns.NONE)
                {
                    var item = new ComboBoxFocusItem();
                    item.NextFocus = type;

                    cbfocuslist.Add(item);
                }
            }

            cbFocusControl.DataSource = cbfocuslist;
        }

        private class ComboBoxStateItem
        {
            public HDDStateType HDDState { get; set; }

            public HDDStateTypes Types => HDDState.Value;

            public string Display => HDDState.ViewValue;
        }

        private class ComboBoxFocusItem
        {
            public NextFocusKbn NextFocus { get; set; }

            public NextFocusKbns Types => NextFocus.Value;

            public string Display => NextFocus.ViewValue;
        }
    }
}
