namespace Picturea
{
    partial class TransformationForm
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
            this.value_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.rotate_trackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_X = new System.Windows.Forms.TrackBar();
            this.trackBar_Y = new System.Windows.Forms.TrackBar();
            this.trackBar_H = new System.Windows.Forms.TrackBar();
            this.trackBar_W = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.changes_checkBox = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.rotate_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_W)).BeginInit();
            this.SuspendLayout();
            // 
            // value_textBox
            // 
            this.value_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.value_textBox.Location = new System.Drawing.Point(53, 176);
            this.value_textBox.Name = "value_textBox";
            this.value_textBox.ReadOnly = true;
            this.value_textBox.Size = new System.Drawing.Size(42, 20);
            this.value_textBox.TabIndex = 32;
            this.value_textBox.Text = "0";
            this.value_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Угол:";
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(307, 254);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 30;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(226, 254);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 29;
            this.button_OK.Text = "Применить";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // rotate_trackBar
            // 
            this.rotate_trackBar.BackColor = System.Drawing.SystemColors.Control;
            this.rotate_trackBar.Location = new System.Drawing.Point(101, 172);
            this.rotate_trackBar.Maximum = 360;
            this.rotate_trackBar.Name = "rotate_trackBar";
            this.rotate_trackBar.Size = new System.Drawing.Size(281, 45);
            this.rotate_trackBar.TabIndex = 28;
            this.rotate_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rotate_trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Y:";
            // 
            // trackBar_X
            // 
            this.trackBar_X.Location = new System.Drawing.Point(32, 12);
            this.trackBar_X.Maximum = 1000;
            this.trackBar_X.Minimum = -1000;
            this.trackBar_X.Name = "trackBar_X";
            this.trackBar_X.Size = new System.Drawing.Size(350, 45);
            this.trackBar_X.TabIndex = 39;
            this.trackBar_X.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackBar_Y
            // 
            this.trackBar_Y.Location = new System.Drawing.Point(32, 55);
            this.trackBar_Y.Maximum = 500;
            this.trackBar_Y.Minimum = -500;
            this.trackBar_Y.Name = "trackBar_Y";
            this.trackBar_Y.Size = new System.Drawing.Size(350, 45);
            this.trackBar_Y.TabIndex = 38;
            this.trackBar_Y.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackBar_H
            // 
            this.trackBar_H.Location = new System.Drawing.Point(32, 130);
            this.trackBar_H.Maximum = 1000;
            this.trackBar_H.Minimum = 10;
            this.trackBar_H.Name = "trackBar_H";
            this.trackBar_H.Size = new System.Drawing.Size(350, 45);
            this.trackBar_H.TabIndex = 41;
            this.trackBar_H.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_H.Value = 450;
            // 
            // trackBar_W
            // 
            this.trackBar_W.Location = new System.Drawing.Point(32, 95);
            this.trackBar_W.Maximum = 1000;
            this.trackBar_W.Minimum = 10;
            this.trackBar_W.Name = "trackBar_W";
            this.trackBar_W.Size = new System.Drawing.Size(350, 45);
            this.trackBar_W.TabIndex = 40;
            this.trackBar_W.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_W.Value = 600;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "H:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "W:";
            // 
            // changes_checkBox
            // 
            this.changes_checkBox.AutoSize = true;
            this.changes_checkBox.Checked = true;
            this.changes_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changes_checkBox.Location = new System.Drawing.Point(15, 254);
            this.changes_checkBox.Name = "changes_checkBox";
            this.changes_checkBox.Size = new System.Drawing.Size(189, 17);
            this.changes_checkBox.TabIndex = 47;
            this.changes_checkBox.Text = "Свободное трансформирование";
            this.changes_checkBox.UseVisualStyleBackColor = true;
            this.changes_checkBox.CheckedChanged += new System.EventHandler(this.changes_checkBox_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 223);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 17);
            this.radioButton1.TabIndex = 48;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "К ближайшему";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(121, 223);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 49;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Линейная";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(202, 223);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(86, 17);
            this.radioButton3.TabIndex = 50;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Билинейная";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // TransformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 289);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.changes_checkBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar_H);
            this.Controls.Add(this.trackBar_W);
            this.Controls.Add(this.trackBar_X);
            this.Controls.Add(this.trackBar_Y);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.value_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rotate_trackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TransformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Трансформации";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.rotate_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_W)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox value_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TrackBar rotate_trackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_X;
        private System.Windows.Forms.TrackBar trackBar_Y;
        private System.Windows.Forms.TrackBar trackBar_H;
        private System.Windows.Forms.TrackBar trackBar_W;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox changes_checkBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}