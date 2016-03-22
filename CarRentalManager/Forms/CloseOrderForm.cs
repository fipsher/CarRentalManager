using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalManager.Entities;
using CarRentalManager.Repositories;
using System.Configuration;
using CarRentalManager.Code;

namespace CarRentalManager.Forms
{
    public partial class CloseOrderForm : Form
    {
        private readonly IOrderRepository _orderRepository;
        public DataGridView dgvTable { get; set; }

        public CloseOrderForm()
        {
            _orderRepository = new SqlOrderRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int orderId = (tbOrderId.Text.ToString() == "") ? 0 : int.Parse(tbOrderId.Text.ToString());

            List<Order> ordersList = _orderRepository.CloseOrder(orderId, CurrentUser.Id);

            dgvTable.DataSource = null;
            dgvTable.Refresh();
            dgvTable.DataSource = ordersList;
            dgvTable.Columns.Remove("CustomerId");
            dgvTable.Columns.Remove("Income");
        }
    }
}
