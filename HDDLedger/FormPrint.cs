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

            cbPrintCondition.SelectedValue = PrintModeKbns.All;

            btnPrintStart.Click += ButtonPrintStart_Click;
        }

        private void ButtonPrintStart_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "台帳を印刷しますか？", "HDD台帳", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            if (cbPrintCondition.SelectedValue is PrintModeKbns kbn)
            {
                if (kbn == PrintModeKbns.NONE)
                {
                    MessageBox.Show(this, "絞込条件を選択してください。", "HDD台帳");
                    return;
                }

                var rows = (from a in FormLedger.Rows
                            select a);

                if (kbn == PrintModeKbns.NotDiscard)
                    rows = (from a in rows
                            where a.State.Value != HDDStateTypes.Discard
                            select a);


                Process.Start(Excel.CreateLedger(rows.ToList(), cbPrintCondition.Enabled));
            }
        }

        private void SetComboBoxes()
        {
            var cblist = new List<ComboBoxPrintModeItem>();
            cblist.Clear();

            var none = new ComboBoxPrintModeItem();
            none.PrintMode = PrintModeKbns.NONE;

            cblist.Add(none);

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
