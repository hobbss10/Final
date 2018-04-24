namespace GroupProject
{
    partial class CreateEvent
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
            this.EventName = new System.Windows.Forms.Label();
            this.tb_eventName = new System.Windows.Forms.TextBox();
            this.tb_desc = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_10 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_date = new System.Windows.Forms.TextBox();
            this.rb_11 = new System.Windows.Forms.RadioButton();
            this.rb_12 = new System.Windows.Forms.RadioButton();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_3 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // EventName
            // 
            this.EventName.AutoSize = true;
            this.EventName.Location = new System.Drawing.Point(45, 29);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(69, 13);
            this.EventName.TabIndex = 0;
            this.EventName.Text = "Event Name:";
            // 
            // tb_eventName
            // 
            this.tb_eventName.Location = new System.Drawing.Point(142, 29);
            this.tb_eventName.Name = "tb_eventName";
            this.tb_eventName.Size = new System.Drawing.Size(198, 20);
            this.tb_eventName.TabIndex = 2;
            // 
            // tb_desc
            // 
            this.tb_desc.Location = new System.Drawing.Point(142, 216);
            this.tb_desc.Multiline = true;
            this.tb_desc.Name = "tb_desc";
            this.tb_desc.Size = new System.Drawing.Size(198, 20);
            this.tb_desc.TabIndex = 4;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(45, 216);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(63, 13);
            this.Description.TabIndex = 3;
            this.Description.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time:";
            // 
            // rb_10
            // 
            this.rb_10.AutoSize = true;
            this.rb_10.Location = new System.Drawing.Point(142, 108);
            this.rb_10.Name = "rb_10";
            this.rb_10.Size = new System.Drawing.Size(69, 17);
            this.rb_10.TabIndex = 7;
            this.rb_10.TabStop = true;
            this.rb_10.Text = "10:00 am";
            this.rb_10.UseVisualStyleBackColor = true;
            this.rb_10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 21);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save Event";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_date
            // 
            this.tb_date.Location = new System.Drawing.Point(142, 69);
            this.tb_date.Name = "tb_date";
            this.tb_date.Size = new System.Drawing.Size(198, 20);
            this.tb_date.TabIndex = 9;
            // 
            // rb_11
            // 
            this.rb_11.AutoSize = true;
            this.rb_11.Location = new System.Drawing.Point(142, 147);
            this.rb_11.Name = "rb_11";
            this.rb_11.Size = new System.Drawing.Size(69, 17);
            this.rb_11.TabIndex = 10;
            this.rb_11.TabStop = true;
            this.rb_11.Text = "11:00 am";
            this.rb_11.UseVisualStyleBackColor = true;
            this.rb_11.CheckedChanged += new System.EventHandler(this.radioButton11_CheckedChanged);
            // 
            // rb_12
            // 
            this.rb_12.AutoSize = true;
            this.rb_12.Location = new System.Drawing.Point(142, 181);
            this.rb_12.Name = "rb_12";
            this.rb_12.Size = new System.Drawing.Size(69, 17);
            this.rb_12.TabIndex = 11;
            this.rb_12.TabStop = true;
            this.rb_12.Text = "12:00 pm";
            this.rb_12.UseVisualStyleBackColor = true;
            this.rb_12.CheckedChanged += new System.EventHandler(this.radioButton12_CheckedChanged);
            // 
            // rb_1
            // 
            this.rb_1.AutoSize = true;
            this.rb_1.Location = new System.Drawing.Point(277, 110);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(63, 17);
            this.rb_1.TabIndex = 12;
            this.rb_1.TabStop = true;
            this.rb_1.Text = "1:00 pm";
            this.rb_1.UseVisualStyleBackColor = true;
            this.rb_1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rb_2
            // 
            this.rb_2.AutoSize = true;
            this.rb_2.Location = new System.Drawing.Point(277, 147);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(63, 17);
            this.rb_2.TabIndex = 13;
            this.rb_2.TabStop = true;
            this.rb_2.Text = "2:00 pm";
            this.rb_2.UseVisualStyleBackColor = true;
            this.rb_2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rb_3
            // 
            this.rb_3.AutoSize = true;
            this.rb_3.Location = new System.Drawing.Point(277, 181);
            this.rb_3.Name = "rb_3";
            this.rb_3.Size = new System.Drawing.Size(63, 17);
            this.rb_3.TabIndex = 14;
            this.rb_3.TabStop = true;
            this.rb_3.Text = "3:00 pm";
            this.rb_3.UseVisualStyleBackColor = true;
            this.rb_3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // CreateEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 323);
            this.Controls.Add(this.rb_3);
            this.Controls.Add(this.rb_2);
            this.Controls.Add(this.rb_1);
            this.Controls.Add(this.rb_12);
            this.Controls.Add(this.rb_11);
            this.Controls.Add(this.tb_date);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rb_10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_desc);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.tb_eventName);
            this.Controls.Add(this.EventName);
            this.Name = "CreateEvent";
            this.Text = "Create Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EventName;
        private System.Windows.Forms.TextBox tb_eventName;
        private System.Windows.Forms.TextBox tb_desc;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_date;
        private System.Windows.Forms.RadioButton rb_11;
        private System.Windows.Forms.RadioButton rb_12;
        private System.Windows.Forms.RadioButton rb_1;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.RadioButton rb_3;
    }
}