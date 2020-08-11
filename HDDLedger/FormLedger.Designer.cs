namespace HDDLedger
{
    partial class FormLedger
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLedger));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRowDelete = new System.Windows.Forms.Button();
            this.btnStateChange = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvHDD = new System.Windows.Forms.DataGridView();
            this.chChoose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chRenban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chRegisterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnDetail);
            this.groupBox1.Controls.Add(this.btnRowDelete);
            this.groupBox1.Controls.Add(this.btnStateChange);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(892, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "メニュー";
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.BackColor = System.Drawing.Color.Red;
            this.btnRowDelete.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRowDelete.ForeColor = System.Drawing.Color.Yellow;
            this.btnRowDelete.Location = new System.Drawing.Point(779, 18);
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.Size = new System.Drawing.Size(107, 43);
            this.btnRowDelete.TabIndex = 3;
            this.btnRowDelete.Text = "選択行削除";
            this.btnRowDelete.UseVisualStyleBackColor = false;
            // 
            // btnStateChange
            // 
            this.btnStateChange.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStateChange.Location = new System.Drawing.Point(119, 18);
            this.btnStateChange.Name = "btnStateChange";
            this.btnStateChange.Size = new System.Drawing.Size(107, 43);
            this.btnStateChange.TabIndex = 2;
            this.btnStateChange.Text = "状態変更";
            this.btnStateChange.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAdd.Location = new System.Drawing.Point(6, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 43);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "HDD追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvHDD
            // 
            this.dgvHDD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chChoose,
            this.chRenban,
            this.chName,
            this.chState,
            this.chRegisterTime,
            this.chUpdateTime});
            this.dgvHDD.Location = new System.Drawing.Point(9, 82);
            this.dgvHDD.Name = "dgvHDD";
            this.dgvHDD.RowTemplate.Height = 21;
            this.dgvHDD.Size = new System.Drawing.Size(889, 376);
            this.dgvHDD.TabIndex = 1;
            // 
            // chChoose
            // 
            this.chChoose.FalseValue = "false";
            this.chChoose.HeaderText = "選択";
            this.chChoose.Name = "chChoose";
            this.chChoose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chChoose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chChoose.TrueValue = "true";
            this.chChoose.Width = 80;
            // 
            // chRenban
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.chRenban.DefaultCellStyle = dataGridViewCellStyle1;
            this.chRenban.HeaderText = "連番";
            this.chRenban.Name = "chRenban";
            this.chRenban.ReadOnly = true;
            this.chRenban.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chRenban.Width = 80;
            // 
            // chName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.chName.DefaultCellStyle = dataGridViewCellStyle2;
            this.chName.HeaderText = "名前";
            this.chName.Name = "chName";
            this.chName.ReadOnly = true;
            this.chName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chName.Width = 200;
            // 
            // chState
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.chState.DefaultCellStyle = dataGridViewCellStyle3;
            this.chState.HeaderText = "状態";
            this.chState.Name = "chState";
            this.chState.ReadOnly = true;
            this.chState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // chRegisterTime
            // 
            this.chRegisterTime.HeaderText = "作成日時";
            this.chRegisterTime.Name = "chRegisterTime";
            this.chRegisterTime.ReadOnly = true;
            this.chRegisterTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chRegisterTime.Width = 150;
            // 
            // chUpdateTime
            // 
            this.chUpdateTime.HeaderText = "更新日時";
            this.chUpdateTime.Name = "chUpdateTime";
            this.chUpdateTime.ReadOnly = true;
            this.chUpdateTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.chUpdateTime.Width = 150;
            // 
            // btnDetail
            // 
            this.btnDetail.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDetail.Location = new System.Drawing.Point(232, 18);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(107, 43);
            this.btnDetail.TabIndex = 4;
            this.btnDetail.Text = "詳細表示";
            this.btnDetail.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(666, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(107, 43);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "台帳印刷";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // FormLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 470);
            this.Controls.Add(this.dgvHDD);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLedger";
            this.Text = "HDD台帳";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvHDD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chChoose;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRenban;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chState;
        private System.Windows.Forms.DataGridViewTextBoxColumn chRegisterTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUpdateTime;
        private System.Windows.Forms.Button btnStateChange;
        private System.Windows.Forms.Button btnRowDelete;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnPrint;
    }
}

