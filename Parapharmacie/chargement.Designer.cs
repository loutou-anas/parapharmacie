
namespace Parapharmacie
{
    partial class chargement
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
            this.components = new System.ComponentModel.Container();
            this.guna2TaskBarProgress1 = new Guna.UI2.WinForms.Guna2TaskBarProgress(this.components);
            this.guna2TaskBarProgress2 = new Guna.UI2.WinForms.Guna2TaskBarProgress(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.pourcentage = new System.Windows.Forms.Label();
            this.guna2CircleProgressBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2TaskBarProgress1
            // 
            this.guna2TaskBarProgress1.TargetForm = null;
            // 
            // guna2TaskBarProgress2
            // 
            this.guna2TaskBarProgress2.TargetForm = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(520, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 28);
            this.label1.TabIndex = 78;
            this.label1.Text = "PARAPHARMACIE";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.BackColor = System.Drawing.Color.Cyan;
            this.guna2CircleProgressBar1.Controls.Add(this.pourcentage);
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(557, 274);
            this.guna2CircleProgressBar1.Minimum = 0;
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.DimGray;
            this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.Cyan;
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(125, 125);
            this.guna2CircleProgressBar1.TabIndex = 80;
            this.guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // pourcentage
            // 
            this.pourcentage.AutoSize = true;
            this.pourcentage.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pourcentage.ForeColor = System.Drawing.Color.DimGray;
            this.pourcentage.Location = new System.Drawing.Point(37, 47);
            this.pourcentage.Name = "pourcentage";
            this.pourcentage.Size = new System.Drawing.Size(32, 28);
            this.pourcentage.TabIndex = 81;
            this.pourcentage.Text = "%";
            this.pourcentage.Click += new System.EventHandler(this.pourcentage_Click);
            // 
            // chargement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(1250, 700);
            this.Controls.Add(this.guna2CircleProgressBar1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "chargement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "chargement";
            this.Load += new System.EventHandler(this.chargement_Load);
            this.guna2CircleProgressBar1.ResumeLayout(false);
            this.guna2CircleProgressBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TaskBarProgress guna2TaskBarProgress1;
        private Guna.UI2.WinForms.Guna2TaskBarProgress guna2TaskBarProgress2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private System.Windows.Forms.Label pourcentage;
    }
}