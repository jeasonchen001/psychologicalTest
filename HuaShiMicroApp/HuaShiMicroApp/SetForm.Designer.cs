namespace HuaShiMicroApp
{
    partial class SetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetForm));
            this.label1 = new System.Windows.Forms.Label();
            this.delay1 = new System.Windows.Forms.NumericUpDown();
            this.delay2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.group1Name = new System.Windows.Forms.TextBox();
            this.group2Name = new System.Windows.Forms.TextBox();
            this.informationInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "显示延时：";
            // 
            // delay1
            // 
            this.delay1.BackColor = System.Drawing.SystemColors.Info;
            this.delay1.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delay1.Location = new System.Drawing.Point(313, 20);
            this.delay1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.delay1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.delay1.Name = "delay1";
            this.delay1.Size = new System.Drawing.Size(218, 45);
            this.delay1.TabIndex = 1;
            this.delay1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.delay1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // delay2
            // 
            this.delay2.BackColor = System.Drawing.SystemColors.Info;
            this.delay2.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delay2.Location = new System.Drawing.Point(579, 20);
            this.delay2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.delay2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.delay2.Name = "delay2";
            this.delay2.Size = new System.Drawing.Size(218, 45);
            this.delay2.TabIndex = 2;
            this.delay2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.delay2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(63, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "组名：";
            // 
            // group1Name
            // 
            this.group1Name.BackColor = System.Drawing.SystemColors.Info;
            this.group1Name.Enabled = false;
            this.group1Name.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.group1Name.Location = new System.Drawing.Point(313, 109);
            this.group1Name.Name = "group1Name";
            this.group1Name.Size = new System.Drawing.Size(218, 45);
            this.group1Name.TabIndex = 4;
            this.group1Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // group2Name
            // 
            this.group2Name.BackColor = System.Drawing.SystemColors.Info;
            this.group2Name.Enabled = false;
            this.group2Name.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.group2Name.Location = new System.Drawing.Point(579, 109);
            this.group2Name.Name = "group2Name";
            this.group2Name.Size = new System.Drawing.Size(218, 45);
            this.group2Name.TabIndex = 5;
            this.group2Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // informationInput
            // 
            this.informationInput.BackColor = System.Drawing.SystemColors.Info;
            this.informationInput.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.informationInput.Location = new System.Drawing.Point(69, 269);
            this.informationInput.Multiline = true;
            this.informationInput.Name = "informationInput";
            this.informationInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.informationInput.Size = new System.Drawing.Size(784, 292);
            this.informationInput.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(63, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "必读信息:";
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveBtn.Font = new System.Drawing.Font("宋体", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.Location = new System.Drawing.Point(376, 572);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(147, 46);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(928, 631);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.informationInput);
            this.Controls.Add(this.group2Name);
            this.Controls.Add(this.group1Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delay2);
            this.Controls.Add(this.delay1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "setting";
            this.Load += new System.EventHandler(this.SetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.delay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown delay1;
        private System.Windows.Forms.NumericUpDown delay2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox group1Name;
        private System.Windows.Forms.TextBox group2Name;
        private System.Windows.Forms.TextBox informationInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveBtn;
    }
}