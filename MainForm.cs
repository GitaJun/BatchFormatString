using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BatchString.Classess;

namespace BatchString
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 自适应按钮状态
        /// </summary>
        private enum SelfAdaptBTState
        {
            应用模板, 新增模板, 修改模板, 删除模板
        }
        /// <summary>
        /// 当前状态
        /// </summary>
        private SelfAdaptBTState state;

#if DEBUG
        private static readonly string jsonPath = @"D:\Template\Template.json";
#else
        private static readonly string jsonPath = @".\Template\Template.json";
#endif

        public MainForm()
        {
            InitializeComponent();

            cbb_template.DropDown +=
                (object sender, EventArgs e) =>
                {
                    cbb_template.DataSource = TemplateManager.Instance.LoadTemplates(jsonPath);  //显示到下拉单选框;
                    tb_format.Clear();
                };

            cbb_template.TextChanged +=
                (object sender, EventArgs e) =>
                {
                    if (TemplateManager.Instance.ContainsTemplate(cbb_template.Text))
                    {
                        if (tb_format.Text == string.Empty)
                            SetState(SelfAdaptBTState.应用模板);  //存在模板 && 格式化文本框为空 - 应用
                        else
                            SetState(SelfAdaptBTState.修改模板);  //存在模板 && 格式化文本框不为空 - 修改
                    }
                    else
                    {
                        if (cbb_template.Text.Length > 3)
                        {
                            int divide = cbb_template.Text.Length - 3;
                            string prefix = cbb_template.Text.Substring(0, divide);
                            string suffix = cbb_template.Text.Substring(divide);
                            if (TemplateManager.Instance.ContainsTemplate(prefix) && suffix == "-rm")
                                SetState(SelfAdaptBTState.删除模板);  //存在模板名称 && 存在'-rm'后缀 - 删除 
                        }
                        else
                        {
                            SetState(SelfAdaptBTState.新增模板);  //不存在模板 - 新增
                        }
                    }
                };

            tb_format.TextChanged +=
                (object sender, EventArgs e) =>
                {
                    if (cbb_template.Text != string.Empty && TemplateManager.Instance.ContainsTemplate(cbb_template.Text))
                        SetState(SelfAdaptBTState.修改模板);
                };

            bt_selfAdapt.Click +=
                 (object sender, EventArgs e) =>
                 {
                     switch (state)
                     {
                         case SelfAdaptBTState.应用模板:
                             string tempName = cbb_template.Text;
                             if (TemplateManager.Instance.GetTemplate(tempName, out string template))
                             {
                                 tb_format.Text = template;
                                 if (tempName == "示例模板")
                                 {
                                     tb_var.Text = "1\r\n2\r\n3\r\n" +
                                     ";\r\n" +
                                     "在这个文本框中输入格式化字符中的占位符，一行代表重复一次。\r\n" +
                                     "如果存在多个占位符，用单独的一行分号分割。\r\n" +
                                     "现在点击右边的'走你'按钮试试看吧！";
                                 }
                             }
                             else
                                 MessageBox.Show("模板应用失败");
                             break;

                         case SelfAdaptBTState.新增模板:
                             if (TemplateManager.Instance.AddTemplate(cbb_template.Text, tb_format.Text, jsonPath))
                                 MessageBox.Show("成功新增一条模板");
                             else
                                 MessageBox.Show("模板新增失败");
                             break;

                         case SelfAdaptBTState.修改模板:
                             if (TemplateManager.Instance.ModifyTemplate(cbb_template.Text, tb_format.Text, jsonPath))
                                 MessageBox.Show("成功修改一条模板");
                             else
                                 MessageBox.Show("模板修改失败");
                             break;

                         case SelfAdaptBTState.删除模板:
                             if (TemplateManager.Instance.RemoveTemplate(cbb_template.Text.Substring(0, cbb_template.Text.Length - 3), jsonPath))
                                 MessageBox.Show("成功删除一条模板");
                             else
                                 MessageBox.Show("删除模板失败");
                             break;

                         default: break;
                     }
                 };

            bt_excute.Click +=
                (object sender, EventArgs e) =>
                {
                        tb_output.Text = Factory_BatchString.Instance.GetString(tb_format.Text, tb_var.Text, cb_pinyin.Checked);  //批量生成
                };

        }

        /// <summary>
        /// 设置模板状态
        /// </summary>
        /// <param name="state"></param>
        private void SetState(SelfAdaptBTState state)
        {
            this.state = state;
            bt_selfAdapt.Text = state.ToString();
        }
    }
}
