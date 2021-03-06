﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static HDDLedger.Enum;

namespace HDDLedger
{
    public partial class FormStateChange : Form
    {
        private static FormStateChange instance;

        public IEnumerable<HDDInfoRow> Rows { get; set; }

        public static FormStateChange Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormStateChange();

                return instance;
            }
        }

        public HDDStateTypes State { get; private set; }

        private FormStateChange()
        {
            InitializeComponent();

            this.State = HDDStateTypes.NONE;

            cbState.ValueMember = nameof(ComboBoxStateItem.Types);
            cbState.DisplayMember = nameof(ComboBoxStateItem.Display);

            SetComboBoxes();

            this.Shown += FormStateChange_Shown;
            this.FormClosing += FormStateChange_FormClosing;
            this.btnRegist.Click += BtnRegist_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void FormStateChange_Shown(object sender, EventArgs e)
        {
            cbState.SelectedValue = HDDStateTypes.BeforeErased;
        }

        private void FormStateChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void BtnRegist_Click(object sender, EventArgs e)
        {
            if (cbState.SelectedValue is HDDStateTypes type)
            {
                switch (type)
                {
                    case HDDStateTypes.NONE:
                        MessageBox.Show(this, "状態が選択されていません", "HDD台帳");
                        return;
                    default:
                        if (cbState.SelectedValue is HDDStateTypes tp)
                        {
                            foreach (var row in Rows)
                            {
                                row.State = tp;
                                row.Choose = false;
                                row.LatestUpdateTime = DateTime.Now;
                            }
                        }
                        FormLedger.UpdateData();

                        MessageBox.Show(this, "状態を変更しました", "HDD台帳");
                        this.Visible = false;
                        break;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void SetComboBoxes()
        {
            var cblist = new List<ComboBoxStateItem>();
            cblist.Clear();

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
