﻿namespace FVA
{
    partial class Setup_Constraints
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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Restriction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reversible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowerBound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpperBound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 705);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(638, 705);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(12, 462);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(400, 462);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Restriction,
            this.Reversible,
            this.LowerBound,
            this.UpperBound});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(463, 444);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Restriction
            // 
            this.Restriction.HeaderText = "Restriction";
            this.Restriction.Name = "Restriction";
            this.Restriction.ReadOnly = true;
            this.Restriction.Width = 220;
            // 
            // Reversible
            // 
            this.Reversible.HeaderText = "Reversible";
            this.Reversible.MaxInputLength = 5;
            this.Reversible.Name = "Reversible";
            this.Reversible.ReadOnly = true;
            this.Reversible.Width = 60;
            // 
            // LowerBound
            // 
            this.LowerBound.HeaderText = "Lower Bound";
            this.LowerBound.MaxInputLength = 6;
            this.LowerBound.Name = "LowerBound";
            this.LowerBound.Width = 70;
            // 
            // UpperBound
            // 
            this.UpperBound.HeaderText = "Upper Bound";
            this.UpperBound.MaxInputLength = 6;
            this.UpperBound.Name = "UpperBound";
            this.UpperBound.Width = 70;
            // 
            // Setup_Constraints
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(487, 497);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Name = "Setup_Constraints";
            this.Text = "Setup_Constraints";
            this.Load += new System.EventHandler(this.Setup_Constraints_Load);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Restriction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reversible;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowerBound;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpperBound;
    }
}