
namespace ImageCRUDtest
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
            this.pnlADD = new System.Windows.Forms.Panel();
            this.pnlUpdate = new System.Windows.Forms.Panel();
            this.pnlDelete = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlADD.SuspendLayout();
            this.pnlUpdate.SuspendLayout();
            this.pnlDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlADD
            // 
            this.pnlADD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlADD.Controls.Add(this.label1);
            this.pnlADD.Location = new System.Drawing.Point(35, 181);
            this.pnlADD.Name = "pnlADD";
            this.pnlADD.Size = new System.Drawing.Size(200, 100);
            this.pnlADD.TabIndex = 0;
            this.pnlADD.Click += new System.EventHandler(this.pnlADD_Click);
            // 
            // pnlUpdate
            // 
            this.pnlUpdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlUpdate.Controls.Add(this.label2);
            this.pnlUpdate.Location = new System.Drawing.Point(309, 181);
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(200, 100);
            this.pnlUpdate.TabIndex = 1;
            this.pnlUpdate.Click += new System.EventHandler(this.pnlUpdate_Click);
            // 
            // pnlDelete
            // 
            this.pnlDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlDelete.Controls.Add(this.label3);
            this.pnlDelete.Location = new System.Drawing.Point(583, 181);
            this.pnlDelete.Name = "pnlDelete";
            this.pnlDelete.Size = new System.Drawing.Size(200, 100);
            this.pnlDelete.TabIndex = 1;
            this.pnlDelete.Click += new System.EventHandler(this.pnlDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADD ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "UPDATE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DELETE ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(844, 541);
            this.Controls.Add(this.pnlDelete);
            this.Controls.Add(this.pnlUpdate);
            this.Controls.Add(this.pnlADD);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlADD.ResumeLayout(false);
            this.pnlADD.PerformLayout();
            this.pnlUpdate.ResumeLayout(false);
            this.pnlUpdate.PerformLayout();
            this.pnlDelete.ResumeLayout(false);
            this.pnlDelete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlADD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDelete;
        private System.Windows.Forms.Label label3;
    }
}

