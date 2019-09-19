namespace chast1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetVersh = new System.Windows.Forms.CheckBox();
            this.btnSetLink = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.FindAllPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FordBelman = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 419);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // btnSetVersh
            // 
            this.btnSetVersh.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSetVersh.AutoSize = true;
            this.btnSetVersh.Checked = true;
            this.btnSetVersh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnSetVersh.Location = new System.Drawing.Point(577, 24);
            this.btnSetVersh.Name = "btnSetVersh";
            this.btnSetVersh.Size = new System.Drawing.Size(126, 23);
            this.btnSetVersh.TabIndex = 1;
            this.btnSetVersh.Text = "Установить вершины";
            this.btnSetVersh.UseVisualStyleBackColor = true;
            this.btnSetVersh.CheckedChanged += new System.EventHandler(this.btnSetVersh_CheckedChanged);
            // 
            // btnSetLink
            // 
            this.btnSetLink.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSetLink.AutoSize = true;
            this.btnSetLink.Location = new System.Drawing.Point(577, 53);
            this.btnSetLink.Name = "btnSetLink";
            this.btnSetLink.Size = new System.Drawing.Size(128, 23);
            this.btnSetLink.TabIndex = 2;
            this.btnSetLink.Text = "    Установить связи  ";
            this.btnSetLink.UseVisualStyleBackColor = true;
            this.btnSetLink.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(577, 82);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(126, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FindAllPath
            // 
            this.FindAllPath.Location = new System.Drawing.Point(577, 324);
            this.FindAllPath.Name = "FindAllPath";
            this.FindAllPath.Size = new System.Drawing.Size(126, 23);
            this.FindAllPath.TabIndex = 4;
            this.FindAllPath.Text = " Поиск всех путей";
            this.FindAllPath.UseVisualStyleBackColor = true;
            this.FindAllPath.Click += new System.EventHandler(this.FindAllPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // FordBelman
            // 
            this.FordBelman.Location = new System.Drawing.Point(577, 353);
            this.FordBelman.Name = "FordBelman";
            this.FordBelman.Size = new System.Drawing.Size(126, 39);
            this.FordBelman.TabIndex = 4;
            this.FordBelman.Text = "Поиск всех\r\nкратчайших путей";
            this.FordBelman.UseVisualStyleBackColor = true;
            this.FordBelman.Click += new System.EventHandler(this.FordBelman_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 448);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FordBelman);
            this.Controls.Add(this.FindAllPath);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSetLink);
            this.Controls.Add(this.btnSetVersh);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Курсовая работа. Часть 2, задание 1. Спиряев А.Ю.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox btnSetVersh;
        private System.Windows.Forms.CheckBox btnSetLink;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button FindAllPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FordBelman;
    }
}

