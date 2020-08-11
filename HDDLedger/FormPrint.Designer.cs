namespace HDDLedger
{
    partial class FormPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrintCondition = new System.Windows.Forms.ComboBox();
            this.cbBarcode = new System.Windows.Forms.CheckBox();
            this.btnPrintStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBarcode);
            this.groupBox1.Controls.Add(this.cbPrintCondition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出力条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "絞込条件";
            // 
            // cbPrintCondition
            // 
            this.cbPrintCondition.FormattingEnabled = true;
            this.cbPrintCondition.Location = new System.Drawing.Point(79, 21);
            this.cbPrintCondition.Name = "cbPrintCondition";
            this.cbPrintCondition.Size = new System.Drawing.Size(200, 23);
            this.cbPrintCondition.TabIndex = 0;
            // 
            // cbBarcode
            // 
            this.cbBarcode.AutoSize = true;
            this.cbBarcode.Location = new System.Drawing.Point(9, 50);
            this.cbBarcode.Name = "cbBarcode";
            this.cbBarcode.Size = new System.Drawing.Size(179, 19);
            this.cbBarcode.TabIndex = 1;
            this.cbBarcode.Text = "連番バーコードを表示する";
            this.cbBarcode.UseVisualStyleBackColor = true;
            // 
            // btnPrintStart
            // 
            this.btnPrintStart.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrintStart.Location = new System.Drawing.Point(9, 89);
            this.btnPrintStart.Name = "btnPrintStart";
            this.btnPrintStart.Size = new System.Drawing.Size(139, 92);
            this.btnPrintStart.TabIndex = 0;
            this.btnPrintStart.Text = "印刷";
            this.btnPrintStart.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(155, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 92);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormPrint
            // 
            this.AcceptButton = this.btnPrintStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(302, 187);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrintStart);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrint";
            this.Text = "台帳出力";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbBarcode;
        private System.Windows.Forms.ComboBox cbPrintCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintStart;
        private System.Windows.Forms.Button btnCancel;
    }
}