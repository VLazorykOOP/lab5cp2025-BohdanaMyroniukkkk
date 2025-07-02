
namespace FractalsAndHermite
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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


        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHermite = new System.Windows.Forms.TabPage();
            this.btnHermiteStart = new System.Windows.Forms.Button();
            this.pictureBoxHermite = new System.Windows.Forms.PictureBox();
            this.tabFern = new System.Windows.Forms.TabPage(); 
            this.lblK = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label(); 
            this.txtA = new System.Windows.Forms.TextBox(); 
            this.txtK = new System.Windows.Forms.TextBox();
            this.btnDrawFern = new System.Windows.Forms.Button(); 
            this.pictureBoxFern = new System.Windows.Forms.PictureBox(); 
            this.tabControl.SuspendLayout();
            this.tabHermite.SuspendLayout();
            this.tabFern.SuspendLayout(); 
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHermite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFern)).BeginInit(); 
            this.SuspendLayout();
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabHermite);
            this.tabControl.Controls.Add(this.tabFern); 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(820, 720);
            this.tabControl.TabIndex = 0;
            //
            // tabHermite
            //
            this.tabHermite.Controls.Add(this.btnHermiteStart);
            this.tabHermite.Controls.Add(this.pictureBoxHermite);
            this.tabHermite.Location = new System.Drawing.Point(4, 24);
            this.tabHermite.Name = "tabHermite";
            this.tabHermite.Padding = new System.Windows.Forms.Padding(3);
            this.tabHermite.Size = new System.Drawing.Size(812, 692);
            this.tabHermite.TabIndex = 0;
            this.tabHermite.Text = "Крива Ерміта";
            this.tabHermite.UseVisualStyleBackColor = true;
            //
            // pictureBoxHermite
            //
            this.pictureBoxHermite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHermite.BackColor = System.Drawing.Color.White;
            this.pictureBoxHermite.Location = new System.Drawing.Point(10, 60);
            this.pictureBoxHermite.Name = "pictureBoxHermite";
            this.pictureBoxHermite.Size = new System.Drawing.Size(790, 620);
            this.pictureBoxHermite.TabIndex = 0;
            this.pictureBoxHermite.TabStop = false;
            this.pictureBoxHermite.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxHermite_Paint);
            //
            // btnHermiteStart
            //
            this.btnHermiteStart.Location = new System.Drawing.Point(10, 20);
            this.btnHermiteStart.Name = "btnHermiteStart";
            this.btnHermiteStart.Size = new System.Drawing.Size(200, 30);
            this.btnHermiteStart.TabIndex = 1;
            this.btnHermiteStart.Text = "Почати малювання";
            this.btnHermiteStart.UseVisualStyleBackColor = true;
            this.btnHermiteStart.Click += new System.EventHandler(this.btnHermiteStart_Click);
            //
            // tabFern
            //
            this.tabFern.Controls.Add(this.lblK);
            this.tabFern.Controls.Add(this.lblA); 
            this.tabFern.Controls.Add(this.txtA); 
            this.tabFern.Controls.Add(this.txtK);
            this.tabFern.Controls.Add(this.btnDrawFern); 
            this.tabFern.Controls.Add(this.pictureBoxFern); 
            this.tabFern.Location = new System.Drawing.Point(4, 24);
            this.tabFern.Name = "tabFern"; 
            this.tabFern.Padding = new System.Windows.Forms.Padding(3);
            this.tabFern.Size = new System.Drawing.Size(812, 692);
            this.tabFern.TabIndex = 1;
            this.tabFern.Text = "Фрактал Папороть"; 
            this.tabFern.UseVisualStyleBackColor = true;
            //
            // lblK
            //
            this.lblK.AutoSize = true;
            this.lblK.Location = new System.Drawing.Point(120, 50);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(130, 16); 
            this.lblK.TabIndex = 5;
            this.lblK.Text = "Кількість ітерацій (K):"; 
            //
            // lblA
            //
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(10, 50);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(126, 16); 
            this.lblA.TabIndex = 4;
            this.lblA.Text = "Кількість пучків (A):"; 
            //
            // txtA
            //
            this.txtA.Location = new System.Drawing.Point(10, 20);
            this.txtA.Name = "txtA"; 
            this.txtA.Size = new System.Drawing.Size(100, 23);
            this.txtA.TabIndex = 1;
            this.txtA.Text = "3"; 
            //
            // txtK
            //
            this.txtK.Location = new System.Drawing.Point(120, 20);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(100, 23);
            this.txtK.TabIndex = 2;
            this.txtK.Text = "50000"; 
            //
            // btnDrawFern
            //
            this.btnDrawFern.Location = new System.Drawing.Point(230, 20);
            this.btnDrawFern.Name = "btnDrawFern"; 
            this.btnDrawFern.Size = new System.Drawing.Size(120, 30);
            this.btnDrawFern.TabIndex = 3;
            this.btnDrawFern.Text = "Побудувати фрактал";
            this.btnDrawFern.UseVisualStyleBackColor = true;
            this.btnDrawFern.Click += new System.EventHandler(this.btnDrawFern_Click); 
            //
            // pictureBoxFern
            //
            this.pictureBoxFern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFern.BackColor = System.Drawing.Color.White;
            this.pictureBoxFern.Location = new System.Drawing.Point(10, 80);
            this.pictureBoxFern.Name = "pictureBoxFern"; 
            this.pictureBoxFern.Size = new System.Drawing.Size(790, 600);
            this.pictureBoxFern.TabIndex = 0;
            this.pictureBoxFern.TabStop = false;
            this.pictureBoxFern.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFern_Paint); 
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 720);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Крива Ерміта та Фрактали";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabHermite.ResumeLayout(false);
            this.tabFern.ResumeLayout(false); 
            this.tabFern.PerformLayout(); 
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHermite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFern)).EndInit(); 
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHermite;
        private System.Windows.Forms.TabPage tabFern; 
        private System.Windows.Forms.PictureBox pictureBoxHermite;
        private System.Windows.Forms.Button btnHermiteStart;
        private System.Windows.Forms.PictureBox pictureBoxFern; 
        private System.Windows.Forms.TextBox txtA; 
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.Button btnDrawFern; 
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.Label lblA; 
    }
}
