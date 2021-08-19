using System;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IProductRepository _productRepository;

        public Form1(IProductRepository productRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = _productRepository.GetProducts();
                labelTotalRecords.Text = $"Total Records: {dataGridView.RowCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to get the database information. Error Message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
