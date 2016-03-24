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
    public partial class CreateOrderForm : Form
    {
        private readonly IOrderRepository _orderRepository;
        public DataGridView dgvTable { get; set; }

        public CreateOrderForm()
        {
            _orderRepository = new SqlOrderRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
            // IRewiew AZ: think it'll be better not to choose car by Id. Just choose car from carList
            string startDate = dtpStart.Value.ToString("yyyy-MM-dd");
            string endDate = dtpEnd.Value.ToString("yyy-MM-dd");
            string firstName = tbFirstName.Text.ToString();
            string lastName = tbLastName.Text.ToString();
            string licenseNum = tbLicenseNum.Text.ToString();
            int carId = (tbCarId.Text.ToString() == "") ? 0 : int.Parse(tbCarId.Text.ToString());// Rewiew AZ:  parse exception (you dont check correctness of input data)

            List<Order> ordersList = _orderRepository.CreateOrder(startDate, endDate, firstName, 
                                                                    lastName, licenseNum, carId, CurrentUser.Id);

            dgvTable.DataSource = null;
            dgvTable.Refresh();
            dgvTable.DataSource = ordersList;
            dgvTable.Columns.Remove("CustomerId");
            dgvTable.Columns.Remove("Income");
            dgvTable.Columns.Remove("Penalty");

        }
    }
}
