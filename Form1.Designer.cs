namespace BorcNot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelNotlar = new Label();
            textBoxIsim = new TextBox();
            numericUpDownMiktar = new NumericUpDown();
            comboBoxTur = new ComboBox();
            dateTimePickerVade = new DateTimePicker();
            textBoxAciklama = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxAra = new TextBox();
            label6 = new Label();
            buttonEkle = new Button();
            buttonSil = new Button();
            buttonOdedi = new Button();
            listBoxNotlar = new ListBox();
            labelBorcToplam = new Label();
            labelAlacakToplam = new Label();
            label7 = new Label();
            comboBoxDoviz = new ComboBox();
            buttonKismiOdeme = new Button();
            label8 = new Label();
            numericUpDownKismiMiktar = new NumericUpDown();
            label9 = new Label();
            textBoxTelefon = new TextBox();
            buttonWhatsApp = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMiktar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKismiMiktar).BeginInit();
            SuspendLayout();
            // 
            // labelNotlar
            // 
            labelNotlar.AutoSize = true;
            labelNotlar.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            labelNotlar.ForeColor = SystemColors.Control;
            labelNotlar.Location = new Point(10, 9);
            labelNotlar.Name = "labelNotlar";
            labelNotlar.Size = new Size(58, 18);
            labelNotlar.TabIndex = 2;
            labelNotlar.Text = "Notlar";
            // 
            // textBoxIsim
            // 
            textBoxIsim.Font = new Font("Zalando Sans Expanded", 9.75F);
            textBoxIsim.Location = new Point(9, 81);
            textBoxIsim.Name = "textBoxIsim";
            textBoxIsim.Size = new Size(242, 23);
            textBoxIsim.TabIndex = 3;
            // 
            // numericUpDownMiktar
            // 
            numericUpDownMiktar.Font = new Font("Zalando Sans Expanded", 9.75F);
            numericUpDownMiktar.Location = new Point(9, 190);
            numericUpDownMiktar.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numericUpDownMiktar.Name = "numericUpDownMiktar";
            numericUpDownMiktar.Size = new Size(242, 23);
            numericUpDownMiktar.TabIndex = 4;
            // 
            // comboBoxTur
            // 
            comboBoxTur.Font = new Font("Zalando Sans Expanded", 9.75F);
            comboBoxTur.FormattingEnabled = true;
            comboBoxTur.Items.AddRange(new object[] { "Borcum Var", "Alacağım Var" });
            comboBoxTur.Location = new Point(10, 246);
            comboBoxTur.Name = "comboBoxTur";
            comboBoxTur.Size = new Size(243, 24);
            comboBoxTur.TabIndex = 5;
            // 
            // dateTimePickerVade
            // 
            dateTimePickerVade.Font = new Font("Zalando Sans Expanded", 9.75F);
            dateTimePickerVade.Location = new Point(9, 133);
            dateTimePickerVade.Name = "dateTimePickerVade";
            dateTimePickerVade.Size = new Size(242, 23);
            dateTimePickerVade.TabIndex = 6;
            // 
            // textBoxAciklama
            // 
            textBoxAciklama.Font = new Font("Zalando Sans Expanded", 9.75F);
            textBoxAciklama.Location = new Point(10, 357);
            textBoxAciklama.Name = "textBoxAciklama";
            textBoxAciklama.Size = new Size(242, 23);
            textBoxAciklama.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(9, 60);
            label1.Name = "label1";
            label1.Size = new Size(74, 18);
            label1.TabIndex = 8;
            label1.Text = "Kisi Isim ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(9, 112);
            label2.Name = "label2";
            label2.Size = new Size(47, 18);
            label2.TabIndex = 9;
            label2.Text = "Tarih";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(10, 336);
            label3.Name = "label3";
            label3.Size = new Size(82, 18);
            label3.TabIndex = 10;
            label3.Text = "Aciklama";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(9, 225);
            label4.Name = "label4";
            label4.Size = new Size(122, 18);
            label4.TabIndex = 11;
            label4.Text = "Borc / Alacak";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(9, 169);
            label5.Name = "label5";
            label5.Size = new Size(59, 18);
            label5.TabIndex = 12;
            label5.Text = "Miktar";
            // 
            // textBoxAra
            // 
            textBoxAra.Font = new Font("Zalando Sans Expanded", 9.75F);
            textBoxAra.Location = new Point(11, 585);
            textBoxAra.Name = "textBoxAra";
            textBoxAra.Size = new Size(242, 23);
            textBoxAra.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(11, 564);
            label6.Name = "label6";
            label6.Size = new Size(37, 18);
            label6.TabIndex = 14;
            label6.Text = "Ara";
            // 
            // buttonEkle
            // 
            buttonEkle.BackColor = Color.White;
            buttonEkle.FlatStyle = FlatStyle.Flat;
            buttonEkle.Font = new Font("Zalando Sans Expanded", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonEkle.Location = new Point(11, 614);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(123, 44);
            buttonEkle.TabIndex = 15;
            buttonEkle.Text = "Ekle";
            buttonEkle.UseVisualStyleBackColor = false;
            // 
            // buttonSil
            // 
            buttonSil.BackColor = Color.White;
            buttonSil.FlatStyle = FlatStyle.Flat;
            buttonSil.Font = new Font("Zalando Sans Expanded", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonSil.Location = new Point(143, 667);
            buttonSil.Name = "buttonSil";
            buttonSil.Size = new Size(123, 44);
            buttonSil.TabIndex = 16;
            buttonSil.Text = "Sil";
            buttonSil.UseVisualStyleBackColor = false;
            // 
            // buttonOdedi
            // 
            buttonOdedi.BackColor = Color.White;
            buttonOdedi.FlatStyle = FlatStyle.Flat;
            buttonOdedi.Font = new Font("Zalando Sans Expanded", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonOdedi.Location = new Point(11, 667);
            buttonOdedi.Name = "buttonOdedi";
            buttonOdedi.Size = new Size(123, 44);
            buttonOdedi.TabIndex = 17;
            buttonOdedi.Text = "Odendi";
            buttonOdedi.UseVisualStyleBackColor = false;
            // 
            // listBoxNotlar
            // 
            listBoxNotlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxNotlar.BackColor = Color.LightGray;
            listBoxNotlar.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxNotlar.Font = new Font("Zalando Sans Expanded", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            listBoxNotlar.FormattingEnabled = true;
            listBoxNotlar.Location = new Point(271, 81);
            listBoxNotlar.Name = "listBoxNotlar";
            listBoxNotlar.Size = new Size(821, 628);
            listBoxNotlar.TabIndex = 18;
            // 
            // labelBorcToplam
            // 
            labelBorcToplam.AutoSize = true;
            labelBorcToplam.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            labelBorcToplam.ForeColor = SystemColors.Control;
            labelBorcToplam.Location = new Point(271, 47);
            labelBorcToplam.Name = "labelBorcToplam";
            labelBorcToplam.Size = new Size(124, 18);
            labelBorcToplam.TabIndex = 19;
            labelBorcToplam.Text = "Toplam Borc : ";
            // 
            // labelAlacakToplam
            // 
            labelAlacakToplam.AutoSize = true;
            labelAlacakToplam.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            labelAlacakToplam.ForeColor = SystemColors.Control;
            labelAlacakToplam.Location = new Point(634, 47);
            labelAlacakToplam.Name = "labelAlacakToplam";
            labelAlacakToplam.Size = new Size(140, 18);
            labelAlacakToplam.TabIndex = 20;
            labelAlacakToplam.Text = "Toplam Alacak : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(9, 281);
            label7.Name = "label7";
            label7.Size = new Size(97, 18);
            label7.TabIndex = 22;
            label7.Text = "Doviz Kuru";
            // 
            // comboBoxDoviz
            // 
            comboBoxDoviz.Font = new Font("Zalando Sans Expanded", 9.75F);
            comboBoxDoviz.FormattingEnabled = true;
            comboBoxDoviz.Items.AddRange(new object[] { "TL", "USD", "EUR" });
            comboBoxDoviz.Location = new Point(10, 302);
            comboBoxDoviz.Name = "comboBoxDoviz";
            comboBoxDoviz.Size = new Size(243, 24);
            comboBoxDoviz.TabIndex = 21;
            // 
            // buttonKismiOdeme
            // 
            buttonKismiOdeme.BackColor = Color.White;
            buttonKismiOdeme.FlatStyle = FlatStyle.Flat;
            buttonKismiOdeme.Font = new Font("Zalando Sans Expanded", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonKismiOdeme.Location = new Point(10, 439);
            buttonKismiOdeme.Name = "buttonKismiOdeme";
            buttonKismiOdeme.Size = new Size(111, 44);
            buttonKismiOdeme.TabIndex = 23;
            buttonKismiOdeme.Text = "Kismi Odeme";
            buttonKismiOdeme.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(9, 389);
            label8.Name = "label8";
            label8.Size = new Size(174, 18);
            label8.TabIndex = 25;
            label8.Text = "Kismi Odeme Miktari";
            // 
            // numericUpDownKismiMiktar
            // 
            numericUpDownKismiMiktar.Font = new Font("Zalando Sans Expanded", 9.75F);
            numericUpDownKismiMiktar.Location = new Point(11, 410);
            numericUpDownKismiMiktar.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numericUpDownKismiMiktar.Name = "numericUpDownKismiMiktar";
            numericUpDownKismiMiktar.Size = new Size(242, 23);
            numericUpDownKismiMiktar.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Zalando Sans Expanded", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(9, 487);
            label9.Name = "label9";
            label9.Size = new Size(103, 18);
            label9.TabIndex = 27;
            label9.Text = "Telefen No ";
            label9.Click += label9_Click;
            // 
            // textBoxTelefon
            // 
            textBoxTelefon.Font = new Font("Zalando Sans Expanded", 9.75F);
            textBoxTelefon.Location = new Point(9, 508);
            textBoxTelefon.Name = "textBoxTelefon";
            textBoxTelefon.Size = new Size(242, 23);
            textBoxTelefon.TabIndex = 26;
            // 
            // buttonWhatsApp
            // 
            buttonWhatsApp.BackColor = Color.White;
            buttonWhatsApp.FlatStyle = FlatStyle.Flat;
            buttonWhatsApp.Font = new Font("Zalando Sans Expanded", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            buttonWhatsApp.Location = new Point(9, 537);
            buttonWhatsApp.Name = "buttonWhatsApp";
            buttonWhatsApp.Size = new Size(174, 24);
            buttonWhatsApp.TabIndex = 28;
            buttonWhatsApp.Text = "WhatsApp'tan Bildir";
            buttonWhatsApp.UseVisualStyleBackColor = false;
            buttonWhatsApp.Click += buttonWhatsApp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 5, 62);
            ClientSize = new Size(1101, 721);
            Controls.Add(buttonWhatsApp);
            Controls.Add(label9);
            Controls.Add(textBoxTelefon);
            Controls.Add(label8);
            Controls.Add(numericUpDownKismiMiktar);
            Controls.Add(buttonKismiOdeme);
            Controls.Add(label7);
            Controls.Add(comboBoxDoviz);
            Controls.Add(labelAlacakToplam);
            Controls.Add(labelBorcToplam);
            Controls.Add(listBoxNotlar);
            Controls.Add(buttonOdedi);
            Controls.Add(buttonSil);
            Controls.Add(buttonEkle);
            Controls.Add(label6);
            Controls.Add(textBoxAra);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxAciklama);
            Controls.Add(dateTimePickerVade);
            Controls.Add(comboBoxTur);
            Controls.Add(numericUpDownMiktar);
            Controls.Add(textBoxIsim);
            Controls.Add(labelNotlar);
            Name = "Form1";
            Text = "Notlar";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownMiktar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKismiMiktar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelNotlar;
        private TextBox textBoxIsim;
        private NumericUpDown numericUpDownMiktar;
        private ComboBox comboBoxTur;
        private DateTimePicker dateTimePickerVade;
        private TextBox textBoxAciklama;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxAra;
        private Label label6;
        private Button buttonEkle;
        private Button buttonSil;
        private Button buttonOdedi;
        private ListBox listBoxNotlar;
        private Label labelBorcToplam;
        private Label labelAlacakToplam;
        private Label label7;
        private ComboBox comboBoxDoviz;
        private Button buttonKismiOdeme;
        private Label label8;
        private NumericUpDown numericUpDownKismiMiktar;
        private Label label9;
        private TextBox textBoxTelefon;
        private Button buttonWhatsApp;
    }
}
