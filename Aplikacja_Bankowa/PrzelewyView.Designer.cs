namespace Aplikacja_Bankowa
{
    partial class PrzelewyView
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

        private System.Windows.Forms.Label stanKontaLabel;
        private System.Windows.Forms.Label stanKontaValue;
        private System.Windows.Forms.TextBox kwotaPrzelewuValue;
        private System.Windows.Forms.Label kwotaPrzelewuLabel;
        private System.Windows.Forms.Label daneObiorcyLabel;
        private System.Windows.Forms.TextBox daneObiorcyValue;
        private System.Windows.Forms.TextBox numerKontaValue;
        private System.Windows.Forms.Label numerKontaLabel;
        private System.Windows.Forms.Label tytulPrzelewuLabel;
        private System.Windows.Forms.TextBox tytulPrzelewuValue;
        private System.Windows.Forms.Button wykonajPrzelew;
        private System.Windows.Forms.Button anulujPrzelew;
    }
}