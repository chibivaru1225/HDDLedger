using DocumentFormat.OpenXml.Office2010.CustomUI;
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
    public partial class FormPrint : Form
    {
        private static FormPrint instance;

        public static FormPrint Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormPrint();

                return instance;
            }
        }

        private FormPrint()
        {
            InitializeComponent();

            cbPrintCondition.ValueMember = nameof(ComboBoxPrintModeItem.Types);
            cbPrintCondition.DisplayMember = nameof(ComboBoxPrintModeItem.Display);

            SetComboBoxes();

            btnPrintStart.Click += ButtonPrintStart_Click;
            cbUsePrintOption.CheckedChanged += cbUsePrintOption_CheckedChanged;
            this.VisibleChanged += FormPrint_VisibleChanged;
            this.FormClosing += FormPrint_FormClosing;
        }

        private void cbUsePrintOption_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUsePrintOption.Checked && !FormPrintOption.Instance.Visible)
                FormPrintOption.Instance.Show();
        }

        private void FormPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void FormPrint_VisibleChanged(object sender, EventArgs e)
        {
            cbPrintCondition.SelectedValue = PrintModeKbns.All;
            cbUsePrintOption.Checked = false;

            if (FormPrintOption.Instance.Visible)
                FormPrintOption.Instance.Visible = false;
        }

        private void ButtonPrintStart_Click(object sender, EventArgs e)
        {
            if (cbPrintCondition.SelectedValue is PrintModeKbns kbn)
            {
                if (kbn == PrintModeKbns.NONE)
                {
                    MessageBox.Show(this, "絞込条件を選択してください。", "HDD台帳");
                    return;
                }

                var rows = (from a in FormLedger.Rows
                            select a);

                switch (kbn)
                {
                    case PrintModeKbns.NotDiscard:
                        rows = (from a in rows
                                where a.State.Value != HDDStateTypes.Discard
                                select a);
                        break;
                    case PrintModeKbns.SelectRow:
                        rows = (from a in rows
                                where a.Choose == true
                                select a);
                        break;
                }

                if (rows.Count() == 0)
                {
                    MessageBox.Show(this, "印刷される行はありません。", "HDD台帳");
                    return;
                }

                var result = MessageBox.Show(this, "台帳を印刷しますか？", "HDD台帳", MessageBoxButtons.OKCancel);

                if (result != DialogResult.OK)
                    return;

                var crows = (from a in FormPrintOption.Instance.DefaultColumnRows()
                             where a.IsPrint
                             orderby a.ColumnOrder
                             select a);

                if (cbUsePrintOption.Checked)
                    crows = (from a in FormPrintOption.Instance.ColumnRows
                             where a.IsPrint
                             orderby a.ColumnOrder
                             select a);

                Process.Start(Excel.CreateLedger(rows, crows, FormPrintOption.Instance.Orientation));
                MessageBox.Show(this, "出力完了しました。", "HDD台帳");
            }
        }

        private void SetComboBoxes()
        {
            var cblist = new List<ComboBoxPrintModeItem>();
            cblist.Clear();

            foreach (var tcg in System.Enum.GetValues(typeof(PrintModeKbns)))
            {
                if (tcg is PrintModeKbns type && type != PrintModeKbns.NONE)
                {
                    var item = new ComboBoxPrintModeItem();
                    item.PrintMode = type;

                    cblist.Add(item);
                }
            }

            cbPrintCondition.DataSource = cblist;
        }

        private class ComboBoxPrintModeItem
        {
            public PrintModeKbn PrintMode { get; set; }

            public PrintModeKbns Types => PrintMode.Value;

            public string Display => PrintMode.ViewValue;
        }
    }
}
