namespace NewUser
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.add_group_btn = new System.Windows.Forms.Button();
            this.rmv_group_btn = new System.Windows.Forms.Button();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 277);
            this.listBox1.TabIndex = 0;
            // 
            // add_group_btn
            // 
            this.add_group_btn.Location = new System.Drawing.Point(239, 13);
            this.add_group_btn.Name = "add_group_btn";
            this.add_group_btn.Size = new System.Drawing.Size(102, 23);
            this.add_group_btn.TabIndex = 1;
            this.add_group_btn.Text = "Add Group";
            this.add_group_btn.UseVisualStyleBackColor = true;
            // 
            // rmv_group_btn
            // 
            this.rmv_group_btn.Location = new System.Drawing.Point(239, 42);
            this.rmv_group_btn.Name = "rmv_group_btn";
            this.rmv_group_btn.Size = new System.Drawing.Size(102, 23);
            this.rmv_group_btn.TabIndex = 2;
            this.rmv_group_btn.Text = "Remove Group";
            this.rmv_group_btn.UseVisualStyleBackColor = true;
            // 
            // confirm_btn
            // 
            this.confirm_btn.Location = new System.Drawing.Point(239, 267);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(75, 23);
            this.confirm_btn.TabIndex = 3;
            this.confirm_btn.Text = "Confirm";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.confirm_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(320, 267);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(75, 23);
            this.close_btn.TabIndex = 4;
            this.close_btn.Text = "Cancel";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 310);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.rmv_group_btn);
            this.Controls.Add(this.add_group_btn);
            this.Controls.Add(this.listBox1);
            this.Name = "Form3";
            this.Text = "Assign K: Drive Groups";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button add_group_btn;
        private System.Windows.Forms.Button rmv_group_btn;
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.Button close_btn;
    }
}