namespace Aplikacja_Bankowa
{
    partial class BankomatView
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
            this.kwotaLabel = new System.Windows.Forms.Label();
            this.kwotaValue = new System.Windows.Forms.NumericUpDown();
            this.saldoLabel = new System.Windows.Forms.Label();
            this.saldoKontaValue = new System.Windows.Forms.Label();
            this.wplataNaKonto = new System.Windows.Forms.Button();
            this.wyplataZKonta = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kwotaValue)).BeginInit();
            this.SuspendLayout();
            // 
            // kwotaLabel
            // 
            this.kwotaLabel.AutoSize = true;
            this.kwotaLabel.Location = new System.Drawing.Point(68, 53);
            this.kwotaLabel.Name = "kwotaLabel";
            this.kwotaLabel.Size = new System.Drawing.Size(40, 13);
            this.kwotaLabel.TabIndex = 0;
            this.kwotaLabel.Text = "Kwota:";
            // 
            // kwotaValue
            // 
            this.kwotaValue.DecimalPlaces = 2;
            this.kwotaValue.Location = new System.Drawing.Point(71, 69);
            this.kwotaValue.Name = "kwotaValue";
            this.kwotaValue.Size = new System.Drawing.Size(120, 20);
            this.kwotaValue.TabIndex = 1;
            // 
            // saldoLabel
            // 
            this.saldoLabel.AutoSize = true;
            this.saldoLabel.Location = new System.Drawing.Point(261, 53);
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Size = new System.Drawing.Size(67, 13);
            this.saldoLabel.TabIndex = 2;
            this.saldoLabel.Text = "Saldo konta:";
            // 
            // saldoKontaValue
            // 
            this.saldoKontaValue.AutoSize = true;
            this.saldoKontaValue.Location = new System.Drawing.Point(261, 71);
            this.saldoKontaValue.Name = "saldoKontaValue";
            this.saldoKontaValue.Size = new System.Drawing.Size(28, 13);
            this.saldoKontaValue.TabIndex = 3;
            this.saldoKontaValue.Text = "0,00";
            // 
            // wplataNaKonto
            // 
            this.wplataNaKonto.Location = new System.Drawing.Point(71, 139);
            this.wplataNaKonto.Name = "wplataNaKonto";
            this.wplataNaKonto.Size = new System.Drawing.Size(133, 43);
            this.wplataNaKonto.TabIndex = 4;
            this.wplataNaKonto.Text = "Wpłata na konto";
            this.wplataNaKonto.UseVisualStyleBackColor = true;
            this.wplataNaKonto.Click += new System.EventHandler(this.wplataNaKonto_Click);
            // 
            // wyplataZKonta
            // 
            this.wyplataZKonta.Location = new System.Drawing.Point(264, 139);
            this.wyplataZKonta.Name = "wyplataZKonta";
            this.wyplataZKonta.Size = new System.Drawing.Size(133, 43);
            this.wyplataZKonta.TabIndex = 5;
            this.wyplataZKonta.Text = "Wypłata z konta";
            this.wyplataZKonta.UseVisualStyleBackColor = true;
            this.wyplataZKonta.Click += new System.EventHandler(this.wyplataZKonta_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(355, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 6;
            this.back.Text = "Powrót";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // BankomatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 258);
            this.Controls.Add(this.back);
            this.Controls.Add(this.wyplataZKonta);
            this.Controls.Add(this.wplataNaKonto);
            this.Controls.Add(this.saldoKontaValue);
            this.Controls.Add(this.saldoLabel);
            this.Controls.Add(this.kwotaValue);
            this.Controls.Add(this.kwotaLabel);
            this.Name = "BankomatView";
            this.Text = "BankomatView";
            ((System.ComponentModel.ISupportInitialize)(this.kwotaValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label kwotaLabel;
        private System.Windows.Forms.NumericUpDown kwotaValue;
        private System.Windows.Forms.Label saldoLabel;
        private System.Windows.Forms.Label saldoKontaValue;
        private System.Windows.Forms.Button wplataNaKonto;
        private System.Windows.Forms.Button wyplataZKonta;
        private System.Windows.Forms.Button back;
    }
}