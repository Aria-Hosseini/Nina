namespace InstalledPrograms
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
            this.listViewPrograms = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btncloseapp = new System.Windows.Forms.Button();
            this.btnminapp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewPrograms
            // 
            this.listViewPrograms.HideSelection = false;
            this.listViewPrograms.Location = new System.Drawing.Point(12, 67);
            this.listViewPrograms.Name = "listViewPrograms";
            this.listViewPrograms.Size = new System.Drawing.Size(618, 394);
            this.listViewPrograms.TabIndex = 0;
            this.listViewPrograms.UseCompatibleStateImageBehavior = false;
            this.listViewPrograms.View = System.Windows.Forms.View.Details;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(406, -3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btncloseapp
            // 
            this.btncloseapp.BackColor = System.Drawing.Color.Red;
            this.btncloseapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncloseapp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncloseapp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncloseapp.Location = new System.Drawing.Point(572, -1);
            this.btncloseapp.Name = "btncloseapp";
            this.btncloseapp.Size = new System.Drawing.Size(58, 26);
            this.btncloseapp.TabIndex = 4;
            this.btncloseapp.Text = "close";
            this.btncloseapp.UseVisualStyleBackColor = false;
            this.btncloseapp.Click += new System.EventHandler(this.btncloseapp_Click);
            // 
            // btnminapp
            // 
            this.btnminapp.BackColor = System.Drawing.Color.LightGray;
            this.btnminapp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnminapp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminapp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnminapp.Location = new System.Drawing.Point(487, -1);
            this.btnminapp.Name = "btnminapp";
            this.btnminapp.Size = new System.Drawing.Size(79, 26);
            this.btnminapp.TabIndex = 5;
            this.btnminapp.Text = "minimize";
            this.btnminapp.UseVisualStyleBackColor = false;
            this.btnminapp.Click += new System.EventHandler(this.btnminapp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 473);
            this.ControlBox = false;
            this.Controls.Add(this.btnminapp);
            this.Controls.Add(this.btncloseapp);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.listViewPrograms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewPrograms;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btncloseapp;
        private System.Windows.Forms.Button btnminapp;
    }
}