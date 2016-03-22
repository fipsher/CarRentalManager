using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalManager.Forms;
using CarRentalManager.Repositories;
using CarRentalManager.Entities;
using System.Configuration;

namespace CarRentalManager
{
    public partial class MainForm : Form
    {
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public MainForm()
        {
            _carRepository = new SqlCarRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            _customerRepository = new SqlCustomerRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            _orderRepository = new SqlOrderRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);

            InitializeComponent();
        }

        private void btnPriceList_Click(object sender, EventArgs e)
        {           
            List<Car> priceList = _carRepository.GetPriceList();

            dgvTable.DataSource = null;
            dgvTable.Refresh();
            dgvTable.DataSource = priceList;
            dgvTable.Columns.Remove("RegNum");
            dgvTable.Columns.Remove("isOperating");            

        }

        private void btnAvailableCars_Click(object sender, EventArgs e)
        {
            AvailableCarsForm frmAvailableCars = new AvailableCarsForm();
                       
            frmAvailableCars.dgvTable = dgvTable;
            frmAvailableCars.ShowDialog();
        }

        private void btnDelayedCars_Click(object sender, EventArgs e)
        {
            List<DelayedCar> carsList = _carRepository.GetDelayedCars();
            
            dgvTable.Refresh();
            dgvTable.DataSource = carsList;
        }

        private void btnClientHistory_Click(object sender, EventArgs e)
        {
            CustomerHistoryForm frmCustomerHistory = new CustomerHistoryForm();
            
            frmCustomerHistory.dgvTable = dgvTable;
            frmCustomerHistory.ShowDialog();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            IncomeForm frmIncome = new IncomeForm();

            frmIncome.dgvTable = dgvTable;
            frmIncome.ShowDialog();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            CreateOrderForm frmCreateOrder = new CreateOrderForm();

            frmCreateOrder.dgvTable = dgvTable;
            frmCreateOrder.ShowDialog();

        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            CloseOrderForm frmCloseOrder = new CloseOrderForm();

            frmCloseOrder.dgvTable = dgvTable;
            frmCloseOrder.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
