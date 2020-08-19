namespace HDDLedger
{
    partial class FormPrintOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrintOption));
            this.dgvPrintColumn = new System.Windows.Forms.DataGridView();
            this.chPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chPrintTurn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbPrintOrientation = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.btnAllClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintColumn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPrintColumn
            // 
            this.dgvPrintColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrintColumn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chPrint,
            this.chPrintTurn,
            this.chColumnName});
            this.dgvPrintColumn.Location = new System.Drawing.Point(6, 70);
            this.dgvPrintColumn.Name = "dgvPrintColumn";
            this.dgvPrintColumn.RowTemplate.Height = 21;
            this.dgvPrintColumn.Size = new System.Drawing.Size(425, 395);
            this.dgvPrintColumn.TabIndex = 0;
            // 
            // chPrint
            // 
            this.chPrint.HeaderText = "印刷する";
            this.chPrint.Name = "chPrint";
            this.chPrint.Width = 80;
            // 
            // chPrintTurn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chPrintTurn.DefaultCellStyle = dataGridViewCellStyle1;
            this.chPrintTurn.HeaderText = "並び順";
            this.chPrintTurn.Name = "chPrintTurn";
            this.chPrintTurn.ReadOnly = true;
            this.chPrintTurn.Width = 80;
            // 
            // chColumnName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.chColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.chColumnName.HeaderText = "列名";
            this.chColumnName.Name = "chColumnName";
            this.chColumnName.ReadOnly = true;
            this.chColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chColumnName.Width = 200;
            // 
            // cbPrintOrientation
            // 
            this.cbPrintOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrintOrientation.FormattingEnabled = true;
            this.cbPrintOrientation.Location = new System.Drawing.Point(75, 21);
            this.cbPrintOrientation.Name = "cbPrintOrientation";
            this.cbPrintOrientation.Size = new System.Drawing.Size(167, 23);
            this.cbPrintOrientation.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPrintOrientation);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本";
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(211, 21);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(107, 43);
            this.btnDefault.TabIndex = 3;
            this.btnDefault.Text = "デフォルトに\r\n戻す";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "印刷向き";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAllClear);
            this.groupBox2.Controls.Add(this.btnAllSelect);
            this.groupBox2.Controls.Add(this.btnDefault);
            this.groupBox2.Controls.Add(this.dgvPrintColumn);
            this.groupBox2.Location = new System.Drawing.Point(9, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 471);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "印刷項目";
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(6, 21);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(107, 43);
            this.btnAllSelect.TabIndex = 4;
            this.btnAllSelect.Text = "全選択";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            // 
            // btnAllClear
            // 
            this.btnAllClear.Location = new System.Drawing.Point(324, 21);
            this.btnAllClear.Name = "btnAllClear";
            this.btnAllClear.Size = new System.Drawing.Size(107, 43);
            this.btnAllClear.TabIndex = 5;
            this.btnAllClear.Text = "全解除";
            this.btnAllClear.UseVisualStyleBackColor = true;
            // 
            // FormPrintOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrintOption";
            this.Text = "印刷オプション";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintColumn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrintColumn;
        private System.Windows.Forms.ComboBox cbPrintOrientation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPrintTurn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chColumnName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnAllClear;
        private System.Windows.Forms.Button btnAllSelect;
    }
}