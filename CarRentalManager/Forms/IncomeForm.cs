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

namespace CarRentalManager.Forms
{
    public partial class IncomeForm : Form
    {
        private readonly IOrderRepository _orderRepository;
        public DataGridView dgvTable { get; set; }

        public IncomeForm()
        {
            _orderRepository = new SqlOrderRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string startDate = dtpStart.Value.ToString("yyyy-MM-dd");
            string endDate = dtpEnd.Value.ToString("yyy-MM-dd");

            List<Order> orderList = _orderRepository.GetIncome(startDate, endDate);

            dgvTable.DataSource = null;
            dgvTable.Refresh();
            dgvTable.DataSource = orderList;
            dgvTable.Columns.Remove("Id");
            dgvTable.Columns.Remove("CustomerId");
            dgvTable.Columns.Remove("CarId");
            dgvTable.Columns.Remove("FirstName");
            dgvTable.Columns.Remove("LastName");
            dgvTable.Columns.Remove("LicenseNum");
            dgvTable.Columns.Remove("CarName");
            dgvTable.Columns.Remove("Cost");
            dgvTable.Columns.Remove("Penalty");
            dgvTable.Columns.Remove("isActive");
            dgvTable.Columns.Remove("isDelayed");
            dgvTable.Columns.Remove("UserId");

        }
    }
}
