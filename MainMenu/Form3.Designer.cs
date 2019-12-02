namespace MainMenu
{
    partial class Form3
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
            this.GraphExample = new System.Windows.Forms.Button();
            this.Efficiency = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GraphExample
            // 
            this.GraphExample.Location = new System.Drawing.Point(192, 139);
            this.GraphExample.Name = "GraphExample";
            this.GraphExample.Size = new System.Drawing.Size(127, 28);
            this.GraphExample.TabIndex = 0;
            this.GraphExample.Text = "Graph Example";
            this.GraphExample.UseVisualStyleBackColor = true;
            this.GraphExample.Click += new System.EventHandler(this.GraphBtn_Click);
            // 
            // Efficiency
            // 
            this.Efficiency.Location = new System.Drawing.Point(192, 221);
            this.Efficiency.Name = "Efficiency";
            this.Efficiency.Size = new System.Drawing.Size(127, 25);
            this.Efficiency.TabIndex = 1;
            this.Efficiency.Text = "Efficiency Test";
            this.Efficiency.UseVisualStyleBackColor = true;
            this.Efficiency.Click += new System.EventHandler(this.Efficiency_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 417);
            this.Controls.Add(this.Efficiency);
            this.Controls.Add(this.GraphExample);
            this.Name = "Form3";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GraphExample;
        private System.Windows.Forms.Button Efficiency;
    }
}

