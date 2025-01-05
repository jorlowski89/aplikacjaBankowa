namespace Aplikacja_Bankowa
{
    partial class HomePage
    {

        private System.ComponentModel.IContainer components = null;


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
            this.userName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saldoKonta = new System.Windows.Forms.Label();
            this.przelewy = new System.Windows.Forms.Button();
            this.historia = new System.Windows.Forms.Button();
            this.bankomat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(559, 19);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(29, 13);
            this.userName.TabIndex = 0;
            this.userName.Text = "User";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wyloguj";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(39, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Saldo:";
            // 
            // saldoKonta
            // 
            this.saldoKonta.AutoSize = true;
            this.saldoKonta.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saldoKonta.Location = new System.Drawing.Point(37, 171);
            this.saldoKonta.Name = "saldoKonta";
            this.saldoKonta.Size = new System.Drawing.Size(87, 39);
            this.saldoKonta.TabIndex = 3;
            this.saldoKonta.Text = "0,00";
            // 
            // przelewy
            // 
            this.przelewy.Location = new System.Drawing.Point(16, 14);
            this.przelewy.Name = "przelewy";
            this.przelewy.Size = new System.Drawing.Size(138, 38);
            this.przelewy.TabIndex = 4;
            this.przelewy.Text = "NOWY PRZELEW";
            this.przelewy.UseVisualStyleBackColor = true;
            this.przelewy.Click += new System.EventHandler(this.button2_Click);
            // 
            // historia
            // 
            this.historia.Location = new System.Drawing.Point(190, 14);
            this.historia.Name = "historia";
            this.historia.Size = new System.Drawing.Size(138, 38);
            this.historia.TabIndex = 5;
            this.historia.Text = "HISTORIA";
            this.historia.UseVisualStyleBackColor = true;
            // 
            // bankomat
            // 
            this.bankomat.Location = new System.Drawing.Point(488, 14);
            this.bankomat.Name = "bankomat";
            this.bankomat.Size = new System.Drawing.Size(138, 38);
            this.bankomat.TabIndex = 6;
            this.bankomat.Text = "BANKOMAT";
            this.bankomat.UseVisualStyleBackColor = true;
            this.bankomat.Click += new System.EventHandler(this.bankomat_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.przelewy);
            this.panel1.Controls.Add(this.bankomat);
            this.panel1.Controls.Add(this.historia);
            this.panel1.Location = new System.Drawing.Point(28, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 69);
            this.panel1.TabIndex = 7;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 439);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saldoKonta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label saldoKonta;
        private System.Windows.Forms.Button przelewy;
        private System.Windows.Forms.Button historia;
        private System.Windows.Forms.Button bankomat;
        private System.Windows.Forms.Panel panel1;
    }
}