namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //下拉框设置四个值
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");

            //下拉框默认值为"+"
            comboBox1.SelectedItem = "+";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //点击计算按钮后的Click事件
        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = 0, num2 = 0, result = 0;

            //先将文本框输入的内容转换成double类型，便于运算
            if (!double.TryParse(textBox1.Text, out num1) || !double.TryParse(textBox2.Text, out num2))
            {
                MessageBox.Show("请输入有效数字！");
                return;
            }
            //选择运算
            switch (comboBox1.SelectedItem.ToString())
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                //防止除"0"
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("除数不能为0！");
                        return;
                    }
                    result = num1 / num2;
                    break;
            }

            //输出结果
            MessageBox.Show("计算结果为：" + result.ToString());
        }
    }
}