namespace Picturea
{
    partial class ColorOverlayForm
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
            this.opacity_trackBar = new System.Windows.Forms.TrackBar();
            this.panelColor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.opacity_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // opacity_trackBar
            // 
            this.opacity_trackBar.Location = new System.Drawing.Point(142, 42);
            this.opacity_trackBar.Maximum = 0;
            this.opacity_trackBar.Minimum = -100;
            this.opacity_trackBar.Name = "opacity_trackBar";
            this.opacity_trackBar.Size = new System.Drawing.Size(196, 45);
            this.opacity_trackBar.TabIndex = 0;
            this.opacity_trackBar.Value = -50;
            this.opacity_trackBar.ValueChanged += new System.EventHandler(this.opacity_trackBar_ValueChanged);
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Black;
            this.panelColor.Location = new System.Drawing.Point(25, 42);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(89, 28);
            this.panelColor.TabIndex = 1;
            this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Цвет:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Прозрачность:";
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(242, 96);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 27;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(161, 96);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 26;
            this.button_OK.Text = "Применить";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // ColorOverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 131);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.opacity_trackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColorOverlayForm";
            this.Text = "Наложение цвета";
            ((System.ComponentModel.ISupportInitialize)(this.opacity_trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar opacity_trackBar;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
    }
}