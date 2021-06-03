
namespace BatchString
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_pinyin = new System.Windows.Forms.CheckBox();
            this.bt_excute = new System.Windows.Forms.Button();
            this.groupBox_Output = new System.Windows.Forms.GroupBox();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.groupBox_Var = new System.Windows.Forms.GroupBox();
            this.tb_var = new System.Windows.Forms.TextBox();
            this.groupBox_SQL = new System.Windows.Forms.GroupBox();
            this.cbb_template = new System.Windows.Forms.ComboBox();
            this.bt_selfAdapt = new System.Windows.Forms.Button();
            this.tb_format = new System.Windows.Forms.TextBox();
            this.groupBox_Output.SuspendLayout();
            this.groupBox_Var.SuspendLayout();
            this.groupBox_SQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_pinyin
            // 
            this.cb_pinyin.AutoSize = true;
            this.cb_pinyin.Location = new System.Drawing.Point(494, 34);
            this.cb_pinyin.Name = "cb_pinyin";
            this.cb_pinyin.Size = new System.Drawing.Size(48, 16);
            this.cb_pinyin.TabIndex = 16;
            this.cb_pinyin.Text = "拼音";
            this.cb_pinyin.UseVisualStyleBackColor = true;
            // 
            // bt_excute
            // 
            this.bt_excute.Location = new System.Drawing.Point(494, 56);
            this.bt_excute.Name = "bt_excute";
            this.bt_excute.Size = new System.Drawing.Size(46, 382);
            this.bt_excute.TabIndex = 15;
            this.bt_excute.Text = "走你";
            this.bt_excute.UseVisualStyleBackColor = true;
            // 
            // groupBox_Output
            // 
            this.groupBox_Output.Controls.Add(this.tb_output);
            this.groupBox_Output.Location = new System.Drawing.Point(546, 12);
            this.groupBox_Output.Name = "groupBox_Output";
            this.groupBox_Output.Size = new System.Drawing.Size(279, 432);
            this.groupBox_Output.TabIndex = 14;
            this.groupBox_Output.TabStop = false;
            this.groupBox_Output.Text = "输出结果";
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(6, 20);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_output.Size = new System.Drawing.Size(267, 406);
            this.tb_output.TabIndex = 0;
            // 
            // groupBox_Var
            // 
            this.groupBox_Var.Controls.Add(this.tb_var);
            this.groupBox_Var.Location = new System.Drawing.Point(271, 12);
            this.groupBox_Var.Name = "groupBox_Var";
            this.groupBox_Var.Size = new System.Drawing.Size(217, 432);
            this.groupBox_Var.TabIndex = 13;
            this.groupBox_Var.TabStop = false;
            this.groupBox_Var.Text = "占位字符串，分号分隔";
            // 
            // tb_var
            // 
            this.tb_var.Location = new System.Drawing.Point(6, 20);
            this.tb_var.Multiline = true;
            this.tb_var.Name = "tb_var";
            this.tb_var.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_var.Size = new System.Drawing.Size(205, 406);
            this.tb_var.TabIndex = 0;
            // 
            // groupBox_SQL
            // 
            this.groupBox_SQL.Controls.Add(this.cbb_template);
            this.groupBox_SQL.Controls.Add(this.bt_selfAdapt);
            this.groupBox_SQL.Controls.Add(this.tb_format);
            this.groupBox_SQL.Location = new System.Drawing.Point(12, 12);
            this.groupBox_SQL.Name = "groupBox_SQL";
            this.groupBox_SQL.Size = new System.Drawing.Size(258, 432);
            this.groupBox_SQL.TabIndex = 12;
            this.groupBox_SQL.TabStop = false;
            this.groupBox_SQL.Text = "格式化字符串（{序号从0开始}）";
            // 
            // cbb_template
            // 
            this.cbb_template.FormattingEnabled = true;
            this.cbb_template.Location = new System.Drawing.Point(7, 20);
            this.cbb_template.Name = "cbb_template";
            this.cbb_template.Size = new System.Drawing.Size(164, 20);
            this.cbb_template.TabIndex = 2;
            // 
            // bt_selfAdapt
            // 
            this.bt_selfAdapt.Location = new System.Drawing.Point(177, 18);
            this.bt_selfAdapt.Name = "bt_selfAdapt";
            this.bt_selfAdapt.Size = new System.Drawing.Size(75, 23);
            this.bt_selfAdapt.TabIndex = 1;
            this.bt_selfAdapt.Text = "应用模板";
            this.bt_selfAdapt.UseVisualStyleBackColor = true;
            // 
            // tb_format
            // 
            this.tb_format.Location = new System.Drawing.Point(6, 44);
            this.tb_format.Multiline = true;
            this.tb_format.Name = "tb_format";
            this.tb_format.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_format.Size = new System.Drawing.Size(246, 382);
            this.tb_format.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 454);
            this.Controls.Add(this.cb_pinyin);
            this.Controls.Add(this.bt_excute);
            this.Controls.Add(this.groupBox_Output);
            this.Controls.Add(this.groupBox_Var);
            this.Controls.Add(this.groupBox_SQL);
            this.Name = "MainForm";
            this.Text = "要多少有多少的批量字符串生成器";
            this.groupBox_Output.ResumeLayout(false);
            this.groupBox_Output.PerformLayout();
            this.groupBox_Var.ResumeLayout(false);
            this.groupBox_Var.PerformLayout();
            this.groupBox_SQL.ResumeLayout(false);
            this.groupBox_SQL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_pinyin;
        private System.Windows.Forms.Button bt_excute;
        private System.Windows.Forms.GroupBox groupBox_Output;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.GroupBox groupBox_Var;
        private System.Windows.Forms.TextBox tb_var;
        private System.Windows.Forms.GroupBox groupBox_SQL;
        private System.Windows.Forms.ComboBox cbb_template;
        private System.Windows.Forms.Button bt_selfAdapt;
        private System.Windows.Forms.TextBox tb_format;
    }
}

