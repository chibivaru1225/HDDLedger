namespace HDDLedger
{
    partial class FormAddRow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddRow));
            this.txtHDDName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbContinuousScan = new System.Windows.Forms.CheckBox();
            this.cbOpenExcel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtHDDName
            // 
            this.txtHDDName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtHDDName.Location = new System.Drawing.Point(70, 12);
            this.txtHDDName.Name = "txtHDDName";
            this.txtHDDName.Size = new System.Drawing.Size(250, 22);
            this.txtHDDName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "HDD名";
            // 
            // btnRegist
            // 
            this.btnRegist.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRegist.Location = new System.Drawing.Point(12, 91);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(150, 81);
            this.btnRegist.TabIndex = 1;
            this.btnRegist.Text = "登録";
            this.btnRegist.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(168, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 81);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbContinuousScan
            // 
            this.cbContinuousScan.AutoSize = true;
            this.cbContinuousScan.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbContinuousScan.Location = new System.Drawing.Point(15, 40);
            this.cbContinuousScan.Name = "cbContinuousScan";
            this.cbContinuousScan.Size = new System.Drawing.Size(100, 19);
            this.cbContinuousScan.TabIndex = 3;
            this.cbContinuousScan.Text = "連続スキャン";
            this.cbContinuousScan.UseVisualStyleBackColor = true;
            // 
            // cbOpenExcel
            // 
            this.cbOpenExcel.AutoSize = true;
            this.cbOpenExcel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbOpenExcel.Location = new System.Drawing.Point(15, 66);
            this.cbOpenExcel.Name = "cbOpenExcel";
            this.cbOpenExcel.Size = new System.Drawing.Size(162, 19);
            this.cbOpenExcel.TabIndex = 4;
            this.cbOpenExcel.Text = "登録時にエクセルを開く";
            this.cbOpenExcel.UseVisualStyleBackColor = true;
            // 
            // FormAddRow
            // 
            this.AcceptButton = this.btnRegist;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(333, 184);
            this.Controls.Add(this.cbOpenExcel);
            this.Controls.Add(this.cbContinuousScan);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHDDName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddRow";
            this.Text = "HDD登録";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHDDName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbContinuousScan;
        private System.Windows.Forms.CheckBox cbOpenExcel;
    }
}