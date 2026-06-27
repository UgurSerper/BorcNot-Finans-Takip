namespace BorcNot
{
    partial class LoginForm
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
            buttonGiris = new Button();
            textBoxSifre = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonGiris
            // 
            buttonGiris.Font = new Font("Zalando Sans Expanded", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonGiris.Location = new Point(12, 62);
            buttonGiris.Name = "buttonGiris";
            buttonGiris.Size = new Size(226, 39);
            buttonGiris.TabIndex = 0;
            buttonGiris.Text = "Giris Yap";
            buttonGiris.UseVisualStyleBackColor = true;
            // 
            // textBoxSifre
            // 
            textBoxSifre.Location = new Point(12, 33);
            textBoxSifre.Name = "textBoxSifre";
            textBoxSifre.PasswordChar = '*';
            textBoxSifre.Size = new Size(226, 23);
            textBoxSifre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(46, 18);
            label1.TabIndex = 2;
            label1.Text = "Sifre";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 5, 62);
            ClientSize = new Size(250, 114);
            Controls.Add(label1);
            Controls.Add(textBoxSifre);
            Controls.Add(buttonGiris);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGiris;
        private TextBox textBoxSifre;
        private Label label1;
    }
}