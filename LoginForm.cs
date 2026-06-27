using System;
using System.Windows.Forms;

namespace BorcNot
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            buttonGiris.Click += buttonGiris_Click;
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            // Şifreyi şimdilik "1234" olarak belirledik, değiştirebilirsin
            if (textBoxSifre.Text == "ZaferAslan5656")
            {
                this.DialogResult = DialogResult.OK; // Şifre doğruysa onay ver
                this.Close(); // Giriş ekranını kapat
            }
            else
            {
                MessageBox.Show("Hatalı Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSifre.Clear();
                textBoxSifre.Focus();
            }
        }
    }
}