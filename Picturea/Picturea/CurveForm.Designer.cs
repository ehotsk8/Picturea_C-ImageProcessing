namespace Picturea
{
    partial class CurveForm
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
            this.whiteP_button = new System.Windows.Forms.Button();
            this.blackP_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.add_button = new System.Windows.Forms.Button();
            this.remove_button = new System.Windows.Forms.Button();
            this.apply_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // whiteP_button
            // 
            this.whiteP_button.Location = new System.Drawing.Point(10, 315);
            this.whiteP_button.Name = "whiteP_button";
            this.whiteP_button.Size = new System.Drawing.Size(26, 23);
            this.whiteP_button.TabIndex = 1;
            this.whiteP_button.Text = "W";
            this.whiteP_button.UseVisualStyleBackColor = true;
            this.whiteP_button.Click += new System.EventHandler(this.whiteP_button_Click);
            // 
            // blackP_button
            // 
            this.blackP_button.Location = new System.Drawing.Point(42, 315);
            this.blackP_button.Name = "blackP_button";
            this.blackP_button.Size = new System.Drawing.Size(27, 23);
            this.blackP_button.TabIndex = 2;
            this.blackP_button.Text = "B";
            this.blackP_button.UseVisualStyleBackColor = true;
            this.blackP_button.Click += new System.EventHandler(this.blackP_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnX,
            this.ColumnY});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(10, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(245, 247);
            this.dataGridView1.TabIndex = 3;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(10, 265);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 4;
            this.add_button.Text = "Добавить";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // remove_button
            // 
            this.remove_button.Location = new System.Drawing.Point(91, 265);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(75, 23);
            this.remove_button.TabIndex = 5;
            this.remove_button.Text = "Удалить";
            this.remove_button.UseVisualStyleBackColor = true;
            this.remove_button.Click += new System.EventHandler(this.remove_button_Click);
            // 
            // apply_button
            // 
            this.apply_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.apply_button.Location = new System.Drawing.Point(114, 315);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(75, 23);
            this.apply_button.TabIndex = 6;
            this.apply_button.Text = "Применить";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.apply_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(195, 315);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(60, 23);
            this.cancel_button.TabIndex = 7;
            this.cancel_button.Text = "Отмена";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            // 
            // ColumnY
            // 
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            // 
            // CurveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 350);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.apply_button);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.blackP_button);
            this.Controls.Add(this.whiteP_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CurveForm";
            this.Text = "Кривые";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button whiteP_button;
        private System.Windows.Forms.Button blackP_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button remove_button;
        private System.Windows.Forms.Button apply_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
    }
}