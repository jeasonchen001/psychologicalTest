﻿namespace HuaShiMicroApp
{
    partial class ImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageForm));
            this.informationText = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageBox1 = new System.Windows.Forms.PictureBox();
            this.timer3Focus = new System.Windows.Forms.Timer(this.components);
            this.imageBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // informationText
            // 
            this.informationText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.informationText.Enabled = false;
            this.informationText.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.informationText.Location = new System.Drawing.Point(188, 25);
            this.informationText.Multiline = true;
            this.informationText.Name = "informationText";
            this.informationText.Size = new System.Drawing.Size(1000, 300);
            this.informationText.TabIndex = 2;
            this.informationText.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(349, -36);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(400, 275);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 3;
            this.imageBox1.TabStop = false;
            this.imageBox1.Visible = false;
            // 
            // timer3Focus
            // 
            this.timer3Focus.Interval = 500;
            this.timer3Focus.Tick += new System.EventHandler(this.timer3Focus_Tick);
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(788, 61);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(400, 275);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox2.TabIndex = 6;
            this.imageBox2.TabStop = false;
            this.imageBox2.Visible = false;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.informationText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "心理学小实验";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox informationText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox imageBox1;
        private System.Windows.Forms.Timer timer3Focus;
        private System.Windows.Forms.PictureBox imageBox2;
    }
}