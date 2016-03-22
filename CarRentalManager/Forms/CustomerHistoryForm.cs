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
    public partial class CustomerHistoryForm : Form
    {
        private readonly ICustomerRepository _customerRepository;
        public DataGridView dgvTable { get; set; }

        public CustomerHistoryForm()
        {
            _customerRepository = new SqlCustomerRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string firstName = (tbFirstName == null) ? "" : tbFirstName.Text.ToString();
            string lastName = (tbLastName == null) ? "" : tbLastName.Text.ToString();
            string licenseNum = (tbLicenseNum == null) ? "" : tbLicenseNum.Text.ToString();
            
            List<Order> ordersList = _customerRepository.GetCustomerHistory(firstName, lastName, licenseNum);

            dgvTable.DataSource = null;
            dgvTable.Refresh();
            dgvTable.DataSource = ordersList;
            dgvTable.Columns.Remove("CustomerId");
            dgvTable.Columns.Remove("CarId");
            dgvTable.Columns.Remove("Income");
            dgvTable.Columns.Remove("LicenseNum");
            dgvTable.Columns.Remove("Penalty");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
