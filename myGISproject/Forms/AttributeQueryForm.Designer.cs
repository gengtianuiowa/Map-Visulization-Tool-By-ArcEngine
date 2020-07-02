namespace myGISproject.Forms
{
    partial class AttributeQueryForm
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
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.listBoxField = new System.Windows.Forms.ListBox();
            this.listBoxValue = new System.Windows.Forms.ListBox();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btnpercent = new System.Windows.Forms.Button();
            this.Btnempty = new System.Windows.Forms.Button();
            this.btnnull = new System.Windows.Forms.Button();
            this.Btnunderline = new System.Windows.Forms.Button();
            this.Btnspace = new System.Windows.Forms.Button();
            this.Btnor = new System.Windows.Forms.Button();
            this.Btnmore = new System.Windows.Forms.Button();
            this.Btnin = new System.Windows.Forms.Button();
            this.Btnloe = new System.Windows.Forms.Button();
            this.Btnlike = new System.Windows.Forms.Button();
            this.Btnbetween = new System.Windows.Forms.Button();
            this.btnand = new System.Windows.Forms.Button();
            this.Btnmoe = new System.Windows.Forms.Button();
            this.Btncharacter = new System.Windows.Forms.Button();
            this.Btnis = new System.Windows.Forms.Button();
            this.Btnnot = new System.Windows.Forms.Button();
            this.Btnless = new System.Windows.Forms.Button();
            this.Btnunequal = new System.Windows.Forms.Button();
            this.Btnequal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboLayer
            // 
            this.cboLayer.FormattingEnabled = true;
            this.cboLayer.Location = new System.Drawing.Point(139, 21);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(349, 20);
            this.cboLayer.TabIndex = 0;
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            // 
            // listBoxField
            // 
            this.listBoxField.FormattingEnabled = true;
            this.listBoxField.ItemHeight = 12;
            this.listBoxField.Location = new System.Drawing.Point(34, 81);
            this.listBoxField.Name = "listBoxField";
            this.listBoxField.Size = new System.Drawing.Size(205, 124);
            this.listBoxField.TabIndex = 1;
            this.listBoxField.SelectedIndexChanged += new System.EventHandler(this.listBoxField_SelectedIndexChanged);
            this.listBoxField.DoubleClick += new System.EventHandler(this.listBoxField_DoubleClick);
            // 
            // listBoxValue
            // 
            this.listBoxValue.FormattingEnabled = true;
            this.listBoxValue.ItemHeight = 12;
            this.listBoxValue.Location = new System.Drawing.Point(283, 81);
            this.listBoxValue.Name = "listBoxValue";
            this.listBoxValue.Size = new System.Drawing.Size(203, 124);
            this.listBoxValue.TabIndex = 2;
            this.listBoxValue.DoubleClick += new System.EventHandler(this.listBoxValue_DoubleClick);
            // 
            // textBoxSql
            // 
            this.textBoxSql.Location = new System.Drawing.Point(34, 397);
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.Size = new System.Drawing.Size(447, 113);
            this.textBoxSql.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btnpercent);
            this.groupBox1.Controls.Add(this.Btnempty);
            this.groupBox1.Controls.Add(this.btnnull);
            this.groupBox1.Controls.Add(this.Btnunderline);
            this.groupBox1.Controls.Add(this.Btnspace);
            this.groupBox1.Controls.Add(this.Btnor);
            this.groupBox1.Controls.Add(this.Btnmore);
            this.groupBox1.Controls.Add(this.Btnin);
            this.groupBox1.Controls.Add(this.Btnloe);
            this.groupBox1.Controls.Add(this.Btnlike);
            this.groupBox1.Controls.Add(this.Btnbetween);
            this.groupBox1.Controls.Add(this.btnand);
            this.groupBox1.Controls.Add(this.Btnmoe);
            this.groupBox1.Controls.Add(this.Btncharacter);
            this.groupBox1.Controls.Add(this.Btnis);
            this.groupBox1.Controls.Add(this.Btnnot);
            this.groupBox1.Controls.Add(this.Btnless);
            this.groupBox1.Controls.Add(this.Btnunequal);
            this.groupBox1.Controls.Add(this.Btnequal);
            this.groupBox1.Location = new System.Drawing.Point(34, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表达式";
            // 
            // Btnpercent
            // 
            this.Btnpercent.Location = new System.Drawing.Point(330, 81);
            this.Btnpercent.Name = "Btnpercent";
            this.Btnpercent.Size = new System.Drawing.Size(75, 23);
            this.Btnpercent.TabIndex = 0;
            this.Btnpercent.Text = "%";
            this.Btnpercent.UseVisualStyleBackColor = true;
            this.Btnpercent.Click += new System.EventHandler(this.Btnpercent_Click);
            // 
            // Btnempty
            // 
            this.Btnempty.Location = new System.Drawing.Point(303, 107);
            this.Btnempty.Name = "Btnempty";
            this.Btnempty.Size = new System.Drawing.Size(89, 23);
            this.Btnempty.TabIndex = 0;
            this.Btnempty.Text = "清空";
            this.Btnempty.UseVisualStyleBackColor = true;
            this.Btnempty.Click += new System.EventHandler(this.Btnempty_Click);
            // 
            // btnnull
            // 
            this.btnnull.Location = new System.Drawing.Point(330, 49);
            this.btnnull.Name = "btnnull";
            this.btnnull.Size = new System.Drawing.Size(75, 23);
            this.btnnull.TabIndex = 0;
            this.btnnull.Text = "Null";
            this.btnnull.UseVisualStyleBackColor = true;
            this.btnnull.Click += new System.EventHandler(this.btnnull_Click);
            // 
            // Btnunderline
            // 
            this.Btnunderline.Location = new System.Drawing.Point(249, 81);
            this.Btnunderline.Name = "Btnunderline";
            this.Btnunderline.Size = new System.Drawing.Size(75, 23);
            this.Btnunderline.TabIndex = 0;
            this.Btnunderline.Text = "_";
            this.Btnunderline.UseVisualStyleBackColor = true;
            this.Btnunderline.Click += new System.EventHandler(this.Btnunderline_Click);
            // 
            // Btnspace
            // 
            this.Btnspace.Location = new System.Drawing.Point(206, 107);
            this.Btnspace.Name = "Btnspace";
            this.Btnspace.Size = new System.Drawing.Size(91, 23);
            this.Btnspace.TabIndex = 0;
            this.Btnspace.Text = "空格";
            this.Btnspace.UseVisualStyleBackColor = true;
            this.Btnspace.Click += new System.EventHandler(this.Btnspace_Click);
            // 
            // Btnor
            // 
            this.Btnor.Location = new System.Drawing.Point(249, 49);
            this.Btnor.Name = "Btnor";
            this.Btnor.Size = new System.Drawing.Size(75, 23);
            this.Btnor.TabIndex = 0;
            this.Btnor.Text = "Or";
            this.Btnor.UseVisualStyleBackColor = true;
            this.Btnor.Click += new System.EventHandler(this.Btnor_Click);
            // 
            // Btnmore
            // 
            this.Btnmore.Location = new System.Drawing.Point(330, 20);
            this.Btnmore.Name = "Btnmore";
            this.Btnmore.Size = new System.Drawing.Size(75, 23);
            this.Btnmore.TabIndex = 0;
            this.Btnmore.Text = ">";
            this.Btnmore.UseVisualStyleBackColor = true;
            this.Btnmore.Click += new System.EventHandler(this.Btnmore_Click);
            // 
            // Btnin
            // 
            this.Btnin.Location = new System.Drawing.Point(168, 78);
            this.Btnin.Name = "Btnin";
            this.Btnin.Size = new System.Drawing.Size(75, 23);
            this.Btnin.TabIndex = 0;
            this.Btnin.Text = "In";
            this.Btnin.UseVisualStyleBackColor = true;
            this.Btnin.Click += new System.EventHandler(this.Btnin_Click);
            // 
            // Btnloe
            // 
            this.Btnloe.Location = new System.Drawing.Point(168, 49);
            this.Btnloe.Name = "Btnloe";
            this.Btnloe.Size = new System.Drawing.Size(75, 23);
            this.Btnloe.TabIndex = 0;
            this.Btnloe.Text = "<=";
            this.Btnloe.UseVisualStyleBackColor = true;
            this.Btnloe.Click += new System.EventHandler(this.Btnloe_Click);
            // 
            // Btnlike
            // 
            this.Btnlike.Location = new System.Drawing.Point(249, 20);
            this.Btnlike.Name = "Btnlike";
            this.Btnlike.Size = new System.Drawing.Size(75, 23);
            this.Btnlike.TabIndex = 0;
            this.Btnlike.Text = "like";
            this.Btnlike.UseVisualStyleBackColor = true;
            this.Btnlike.Click += new System.EventHandler(this.Btnlike_Click);
            // 
            // Btnbetween
            // 
            this.Btnbetween.Location = new System.Drawing.Point(105, 107);
            this.Btnbetween.Name = "Btnbetween";
            this.Btnbetween.Size = new System.Drawing.Size(95, 23);
            this.Btnbetween.TabIndex = 0;
            this.Btnbetween.Text = "Between";
            this.Btnbetween.UseVisualStyleBackColor = true;
            this.Btnbetween.Click += new System.EventHandler(this.Btnbetween_Click);
            // 
            // btnand
            // 
            this.btnand.Location = new System.Drawing.Point(87, 78);
            this.btnand.Name = "btnand";
            this.btnand.Size = new System.Drawing.Size(75, 23);
            this.btnand.TabIndex = 0;
            this.btnand.Text = "And";
            this.btnand.UseVisualStyleBackColor = true;
            this.btnand.Click += new System.EventHandler(this.btnand_Click);
            // 
            // Btnmoe
            // 
            this.Btnmoe.Location = new System.Drawing.Point(87, 49);
            this.Btnmoe.Name = "Btnmoe";
            this.Btnmoe.Size = new System.Drawing.Size(75, 23);
            this.Btnmoe.TabIndex = 0;
            this.Btnmoe.Text = ">=";
            this.Btnmoe.UseVisualStyleBackColor = true;
            this.Btnmoe.Click += new System.EventHandler(this.Btnmoe_Click);
            // 
            // Btncharacter
            // 
            this.Btncharacter.Location = new System.Drawing.Point(6, 107);
            this.Btncharacter.Name = "Btncharacter";
            this.Btncharacter.Size = new System.Drawing.Size(95, 23);
            this.Btncharacter.TabIndex = 0;
            this.Btncharacter.Text = "\' \'";
            this.Btncharacter.UseVisualStyleBackColor = true;
            this.Btncharacter.Click += new System.EventHandler(this.Btncharacter_Click);
            // 
            // Btnis
            // 
            this.Btnis.Location = new System.Drawing.Point(168, 20);
            this.Btnis.Name = "Btnis";
            this.Btnis.Size = new System.Drawing.Size(75, 23);
            this.Btnis.TabIndex = 0;
            this.Btnis.Text = "is";
            this.Btnis.UseVisualStyleBackColor = true;
            this.Btnis.Click += new System.EventHandler(this.Btnis_Click);
            // 
            // Btnnot
            // 
            this.Btnnot.Location = new System.Drawing.Point(6, 78);
            this.Btnnot.Name = "Btnnot";
            this.Btnnot.Size = new System.Drawing.Size(75, 23);
            this.Btnnot.TabIndex = 0;
            this.Btnnot.Text = "Not";
            this.Btnnot.UseVisualStyleBackColor = true;
            this.Btnnot.Click += new System.EventHandler(this.Btnnot_Click);
            // 
            // Btnless
            // 
            this.Btnless.Location = new System.Drawing.Point(6, 49);
            this.Btnless.Name = "Btnless";
            this.Btnless.Size = new System.Drawing.Size(75, 23);
            this.Btnless.TabIndex = 0;
            this.Btnless.Text = "<";
            this.Btnless.UseVisualStyleBackColor = true;
            this.Btnless.Click += new System.EventHandler(this.Btnless_Click);
            // 
            // Btnunequal
            // 
            this.Btnunequal.Location = new System.Drawing.Point(87, 20);
            this.Btnunequal.Name = "Btnunequal";
            this.Btnunequal.Size = new System.Drawing.Size(75, 23);
            this.Btnunequal.TabIndex = 0;
            this.Btnunequal.Text = "!=";
            this.Btnunequal.UseVisualStyleBackColor = true;
            this.Btnunequal.Click += new System.EventHandler(this.Btnunequal_Click);
            // 
            // Btnequal
            // 
            this.Btnequal.Location = new System.Drawing.Point(6, 20);
            this.Btnequal.Name = "Btnequal";
            this.Btnequal.Size = new System.Drawing.Size(75, 23);
            this.Btnequal.TabIndex = 0;
            this.Btnequal.Text = "=";
            this.Btnequal.UseVisualStyleBackColor = true;
            this.Btnequal.Click += new System.EventHandler(this.Btnequal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "字段：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "取值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Select * From Table Where";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(82, 531);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "查找";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(327, 531);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AttributeQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 571);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxSql);
            this.Controls.Add(this.listBoxValue);
            this.Controls.Add(this.listBoxField);
            this.Controls.Add(this.cboLayer);
            this.Name = "AttributeQueryForm";
            this.Text = "属性查询";
            this.Load += new System.EventHandler(this.AttributeQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.ListBox listBoxField;
        private System.Windows.Forms.ListBox listBoxValue;
        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btnempty;
        private System.Windows.Forms.Button btnnull;
        private System.Windows.Forms.Button Btnspace;
        private System.Windows.Forms.Button Btnor;
        private System.Windows.Forms.Button Btnmore;
        private System.Windows.Forms.Button Btnin;
        private System.Windows.Forms.Button Btnloe;
        private System.Windows.Forms.Button Btnlike;
        private System.Windows.Forms.Button btnand;
        private System.Windows.Forms.Button Btnmoe;
        private System.Windows.Forms.Button Btnis;
        private System.Windows.Forms.Button Btnnot;
        private System.Windows.Forms.Button Btnless;
        private System.Windows.Forms.Button Btnunequal;
        private System.Windows.Forms.Button Btnequal;
        private System.Windows.Forms.Button Btnpercent;
        private System.Windows.Forms.Button Btnunderline;
        private System.Windows.Forms.Button Btnbetween;
        private System.Windows.Forms.Button Btncharacter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}