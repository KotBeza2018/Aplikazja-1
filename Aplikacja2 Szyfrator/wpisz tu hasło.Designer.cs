namespace Aplikacja2_Szyfrator
{
    partial class wpisz_tu_hasło
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
            this.pastword = new System.Windows.Forms.TextBox();
            this.zaloguj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(202, 51);
            // 
            this.pastword.ForeColor = System.Drawing.Color.Navy;
            this.pastword.Location = new System.Drawing.Point(224, 99);
            this.pastword.MaxLength = 16;
            this.pastword.Name = "pastword";
            this.pastword.Size = new System.Drawing.Size(100, 20);
            this.pastword.TabIndex = 1;
            this.pastword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pastword.UseSystemPasswordChar = true;
            this.pastword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "podaj hasło";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pastword
            // 
            // zaloguj
            // 
            this.zaloguj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zaloguj.Font = new System.Drawing.Font("Rockwell", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zaloguj.ForeColor = System.Drawing.Color.Teal;
            this.zaloguj.Location = new System.Drawing.Point(224, 146);
            this.zaloguj.Name = "zaloguj";
            this.zaloguj.Size = new System.Drawing.Size(100, 29);
            this.zaloguj.TabIndex = 2;
            this.zaloguj.Text = "zaloguj";
            this.zaloguj.UseVisualStyleBackColor = true;
            this.zaloguj.Click += new System.EventHandler(this.zaloguj_Click);
            // 
            // wpisz_tu_hasło
            // 
            this.AcceptButton = this.zaloguj;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(412, 211);
            this.Controls.Add(this.zaloguj);
            this.Controls.Add(this.pastword);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "wpisz_tu_hasło";
            this.Text = "wpisz_tu_hasło";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pastword;
        private System.Windows.Forms.Button zaloguj;
    }
}