namespace GardenGroupUI
{
    partial class ForgotPassForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_forgotEmail = new System.Windows.Forms.TextBox();
            this.btn_resetLink = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forgot Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username/Email ID";
            // 
            // tb_forgotEmail
            // 
            this.tb_forgotEmail.Location = new System.Drawing.Point(143, 74);
            this.tb_forgotEmail.Name = "tb_forgotEmail";
            this.tb_forgotEmail.Size = new System.Drawing.Size(262, 20);
            this.tb_forgotEmail.TabIndex = 2;
            // 
            // btn_resetLink
            // 
            this.btn_resetLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resetLink.Location = new System.Drawing.Point(27, 122);
            this.btn_resetLink.Name = "btn_resetLink";
            this.btn_resetLink.Size = new System.Drawing.Size(121, 28);
            this.btn_resetLink.TabIndex = 3;
            this.btn_resetLink.Text = "Get Reset Link";
            this.btn_resetLink.UseVisualStyleBackColor = true;
            this.btn_resetLink.Click += new System.EventHandler(this.btn_resetLink_Click);
            // 
            // ForgotPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 204);
            this.Controls.Add(this.btn_resetLink);
            this.Controls.Add(this.tb_forgotEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ForgotPassForm";
            this.Text = "ForgotPassForm";
            this.Load += new System.EventHandler(this.ForgotPassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_forgotEmail;
        private System.Windows.Forms.Button btn_resetLink;
    }
}