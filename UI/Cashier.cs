using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI
{
    public partial class Cashier : Form
    {
        private BlApi.IBl bl = BlApi.Factory.Get();
        private List<BO.Product> products = new List<BO.Product>();

        private BO.Order currentOrder = new BO.Order
        {
            Products = new List<BO.ProductInOrder>(),
            IsFavorite = false
        };
        public Cashier()
        {
            InitializeComponent();
            LoadProducts();

            dgvCart.DataSource = currentOrder.Products;
            lblTotal.Text = "סה\"כ: 0 ₪";

        }
        private void LoadProducts()
        {
            products = bl.Product.ReadAll()
                                 .Where(p => p != null)
                                 .Select(p => p!)
                                 .ToList();

            comboBox1.DataSource = products;
            comboBox1.DisplayMember = "ProductName";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Cashier_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddByCode_Click(object sender, EventArgs e)
        {
            string input = comboBox1.Text.Trim();

            BO.Product? product = null;

            if (comboBox1.SelectedItem is BO.Product selected)
                product = selected;

            if (product == null && int.TryParse(input, out int id))
                product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                product = products.FirstOrDefault(p =>
                    p.ProductName.Equals(input, StringComparison.OrdinalIgnoreCase));

            if (product == null)
            {
                MessageBox.Show("מוצר לא נמצא");
                return;
            }

            bl.Order.AddProductToOrder(currentOrder, product.Id, 1);
            var item = currentOrder.Products
    .FirstOrDefault(p => p.ProductId == product.Id);

           

            dgvCart.DataSource = null;
            dgvCart.DataSource = currentOrder.Products;

            lblTotal.Text = "סה\"כ: " + currentOrder.TotalPrice.ToString("0.00") + " ₪";

            comboBox1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bl.Order.DoOrder(currentOrder);

            MessageBox.Show("ההזמנה בוצעה בהצלחה");

            currentOrder = new BO.Order
            {
                Products = new List<BO.ProductInOrder>(),
                IsFavorite =true
            };

            dgvCart.DataSource = null;
            dgvCart.DataSource = currentOrder.Products;
            lblTotal.Text = "סה\"כ: 0 ₪";

        }
    }
}
