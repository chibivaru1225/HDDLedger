﻿using ClosedXML.Excel;
using DocumentFormat.OpenXml.Presentation;
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
    public partial class FormPrintOption : Form
    {
        public BindingList<ColumnRow> ColumnRows { get; set; }

        public XLPageOrientation Orientation
        {
            get
            {
                if (cbPrintOrientation.SelectedValue is XLPageOrientation type)
                    return type;

                return XLPageOrientation.Default;
            }
        }


        private static FormPrintOption instance;

        public static FormPrintOption Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormPrintOption();

                return instance;
            }
        }

        public FormPrintOption()
        {
            InitializeComponent();

            dgvPrintColumn.AutoGenerateColumns = false;
            dgvPrintColumn.AllowUserToAddRows = false;

            ColumnRows = DefaultColumnRows();

            SetColumnBindingName();
            SetComboBoxes();

            dgvPrintColumn.DataSource = ColumnRows;

            btnDefault.Click += btnDefault_Click;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            ColumnRows = DefaultColumnRows();
            dgvPrintColumn.DataSource = ColumnRows;
        }

        private void SetColumnBindingName()
        {
            chPrint.DataPropertyName = nameof(ColumnRow.IsPrint);
            chColumnName.DataPropertyName = nameof(ColumnRow.ColumnName);
            chPrintTurn.DataPropertyName = nameof(ColumnRow.ColumnOrder);

            cbPrintOrientation.ValueMember = nameof(ComboBoxPrintOrientationItem.Types);
            cbPrintOrientation.DisplayMember = nameof(ComboBoxPrintOrientationItem.Display);
        }

        private void SetComboBoxes()
        {
            var cblist = new List<ComboBoxPrintOrientationItem>();
            cblist.Clear();

            foreach (var tcg in System.Enum.GetValues(typeof(XLPageOrientation)))
            {
                if (tcg is XLPageOrientation type)
                {
                    var item = new ComboBoxPrintOrientationItem();
                    item.Orientation = type;

                    cblist.Add(item);
                }
            }

            cbPrintOrientation.DataSource = cblist;
        }

        public BindingList<ColumnRow> DefaultColumnRows()
        {
            var list = new BindingList<ColumnRow>();

            foreach (var tcg in System.Enum.GetValues(typeof(PrintColumnKbns)))
            {
                if (tcg is PrintColumnKbns type && type != PrintColumnKbns.NONE)
                {
                    var item = new ColumnRow();
                    item.Kbn = type;
                    item.IsPrint = item.Kbn.DefaultPrint;

                    list.Add(item);
                }
            }

            return list;
        }

        private class ComboBoxPrintOrientationItem
        {
            public PrintOrientationKbn Orientation { get; set; }

            public XLPageOrientation Types => Orientation.Value;

            public string Display => Orientation.ViewValue;
        }
    }
}
