namespace dsp
{
    partial class Form1
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
            this.ofdFileFinder = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSin = new System.Windows.Forms.Label();
            this.lbA = new System.Windows.Forms.Label();
            this.lbB = new System.Windows.Forms.Label();
            this.cbSin = new System.Windows.Forms.CheckBox();
            this.cbA = new System.Windows.Forms.CheckBox();
            this.cbB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(852, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open  bestand";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 327);
            this.panel1.TabIndex = 1;
            // 
            // lbSin
            // 
            this.lbSin.AutoSize = true;
            this.lbSin.Location = new System.Drawing.Point(22, 350);
            this.lbSin.Name = "lbSin";
            this.lbSin.Size = new System.Drawing.Size(22, 13);
            this.lbSin.TabIndex = 2;
            this.lbSin.Text = "Sin";
            // 
            // lbA
            // 
            this.lbA.AutoSize = true;
            this.lbA.Location = new System.Drawing.Point(22, 380);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(14, 13);
            this.lbA.TabIndex = 3;
            this.lbA.Text = "A";
            // 
            // lbB
            // 
            this.lbB.AutoSize = true;
            this.lbB.Location = new System.Drawing.Point(22, 410);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(14, 13);
            this.lbB.TabIndex = 4;
            this.lbB.Text = "B";
            // 
            // cbSin
            // 
            this.cbSin.AutoSize = true;
            this.cbSin.Location = new System.Drawing.Point(70, 350);
            this.cbSin.Name = "cbSin";
            this.cbSin.Size = new System.Drawing.Size(15, 14);
            this.cbSin.TabIndex = 5;
            this.cbSin.UseVisualStyleBackColor = true;
            // 
            // cbA
            // 
            this.cbA.AutoSize = true;
            this.cbA.Location = new System.Drawing.Point(70, 380);
            this.cbA.Name = "cbA";
            this.cbA.Size = new System.Drawing.Size(15, 14);
            this.cbA.TabIndex = 6;
            this.cbA.UseVisualStyleBackColor = true;
            // 
            // cbB
            // 
            this.cbB.AutoSize = true;
            this.cbB.Location = new System.Drawing.Point(70, 410);
            this.cbB.Name = "cbB";
            this.cbB.Size = new System.Drawing.Size(15, 14);
            this.cbB.TabIndex = 7;
            this.cbB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 510);
            this.Controls.Add(this.cbB);
            this.Controls.Add(this.cbA);
            this.Controls.Add(this.cbSin);
            this.Controls.Add(this.lbB);
            this.Controls.Add(this.lbA);
            this.Controls.Add(this.lbSin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdFileFinder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSin;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Label lbB;
        private System.Windows.Forms.CheckBox cbSin;
        private System.Windows.Forms.CheckBox cbA;
        private System.Windows.Forms.CheckBox cbB;
    }
}

