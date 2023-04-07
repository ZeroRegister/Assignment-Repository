
using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm {
    public partial class FormMain : Form {
        OrderService orderService = new OrderService();

        public event Action<FormEdit> ShowEditForm;
        public String Keyword { get; set; }

        public FormMain() {
            InitializeComponent();
            InitOrders();
            bdsOrders.DataSource = orderService.GetAllOrders();
            cbxField.SelectedIndex = 0;
            txtKeyword.DataBindings.Add("Text", this, "Keyword");
            ShowEditForm += (f => { });
        }

        private void InitOrders() {
            Order order = new Order(1, new Customer("1", "li"), new List<OrderDetail>());
            order.AddItem(new OrderDetail(1, new Goods("1", "apple", 100.0), 10));
            order.AddItem(new OrderDetail(2, new Goods("2", "egg", 50.0), 61));
            orderService.AddOrder(order);
            Order order2 = new Order(2, new Customer("2", "zhang"), new List<OrderDetail>());
            order2.AddItem(new OrderDetail(1, new Goods("2", "egg", 200.0), 10));
            orderService.AddOrder(order2);
        }

        public void QueryAll() {
            bdsOrders.DataSource = orderService.GetAllOrders();
            bdsOrders.ResetBindings(false);
        }


        private void btnQuery_Click(object sender, EventArgs e) {
            try {
                switch (cbxField.SelectedIndex) {
                    case 0://所有订单
                        bdsOrders.DataSource = orderService.GetAllOrders();
                        break;
                    case 1://根据ID查询
                        int id = Convert.ToInt32(Keyword);
                        Order order = orderService.GetOrder(id);
                        List<Order> result = new List<Order>();
                        if (order != null) result.Add(order);
                        bdsOrders.DataSource = result;
                        break;
                    case 2://根据客户查询
                        bdsOrders.DataSource = orderService.QueryOrdersByCustomerName(Keyword);
                        break;
                    case 3://根据货物查询
                        bdsOrders.DataSource = orderService.QueryOrdersByGoodsName(Keyword);
                        break;
                    case 4://根据总价格查询（大于某个总价）
                        float totalPrice = Convert.ToInt32(Keyword);
                        bdsOrders.DataSource =
                               orderService.QueryByTotalAmount(totalPrice);
                        break;
                }
                bdsOrders.ResetBindings(false);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e) {
            FormEdit formEdit = new FormEdit(new Order(), false, orderService);
            ShowEditForm(formEdit);
        }

        private void btnModify_Click(object sender, EventArgs e) {
            EditOrder();
        }

        private void dbvOrders_DoubleClick(object sender, EventArgs e) {
            EditOrder();
        }

        private void EditOrder() {
            Order order = bdsOrders.Current as Order;
            if (order == null) {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            FormEdit form2 = new FormEdit(order, true, orderService);
            ShowEditForm(form2);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            Order order = bdsOrders.Current as Order;
            if (order == null) {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            DialogResult result = MessageBox.Show($"确认要删除Id为{order.OrderId}的订单吗？", "删除", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                orderService.RemoveOrder(order.OrderId);
                QueryAll();
            }
        }


        private void btnExport_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void btnImport_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                QueryAll();
            }
        }

    }
}
