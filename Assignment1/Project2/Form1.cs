namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //�����������ĸ�ֵ
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");

            //������Ĭ��ֵΪ"+"
            comboBox1.SelectedItem = "+";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //������㰴ť���Click�¼�
        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = 0, num2 = 0, result = 0;

            //�Ƚ��ı������������ת����double���ͣ���������
            if (!double.TryParse(textBox1.Text, out num1) || !double.TryParse(textBox2.Text, out num2))
            {
                MessageBox.Show("��������Ч���֣�");
                return;
            }
            //ѡ������
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
                //��ֹ��"0"
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("��������Ϊ0��");
                        return;
                    }
                    result = num1 / num2;
                    break;
            }

            //������
            MessageBox.Show("������Ϊ��" + result.ToString());
        }
    }
}