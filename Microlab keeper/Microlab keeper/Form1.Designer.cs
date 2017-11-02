namespace Microlab_keeper
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_loadCode = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_addCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code path:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.Location = new System.Drawing.Point(90, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(348, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Choose your code file";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // button_loadCode
            // 
            this.button_loadCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_loadCode.Location = new System.Drawing.Point(15, 50);
            this.button_loadCode.Name = "button_loadCode";
            this.button_loadCode.Size = new System.Drawing.Size(75, 23);
            this.button_loadCode.TabIndex = 3;
            this.button_loadCode.Text = "Load code";
            this.button_loadCode.UseVisualStyleBackColor = true;
            this.button_loadCode.Click += new System.EventHandler(this.button_loadCode_Click);
            // 
            // label_status
            // 
            this.label_status.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_status.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_status.Location = new System.Drawing.Point(388, 52);
            this.label_status.Name = "label_status";
            this.label_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_status.Size = new System.Drawing.Size(50, 18);
            this.label_status.TabIndex = 4;
            this.label_status.Text = " - 0000";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_start
            // 
            this.button_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_start.Location = new System.Drawing.Point(96, 50);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(358, 51);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(32, 21);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(270, 52);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Start adress:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_addCode
            // 
            this.button_addCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addCode.Location = new System.Drawing.Point(177, 50);
            this.button_addCode.Name = "button_addCode";
            this.button_addCode.Size = new System.Drawing.Size(75, 23);
            this.button_addCode.TabIndex = 8;
            this.button_addCode.Text = "Update";
            this.button_addCode.UseVisualStyleBackColor = true;
            this.button_addCode.Click += new System.EventHandler(this.button_addCode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(450, 84);
            this.Controls.Add(this.button_addCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_loadCode);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Microlab keeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_loadCode;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_addCode;
    }
}

