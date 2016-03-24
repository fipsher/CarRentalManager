using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalManager.Entities;
using CarRentalManager.Repositories;


namespace CarRentalManager.Forms
{
    public partial class AvailableCarsForm : Form
    {
        private readonly ICarRepository _carRepository;
        public DataGridView dgvTable { get; set; }

        public AvailableCarsForm()
        {
            _carRepository = new SqlCarRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
             //Rewiew AZ: can we remove logic outside Form calss? (Recoment to create additional class library with business logic (it will helps you with Unit Tests + exeption handling))
            //you can even add some exeption hangling and base logging
            string dateStart = dtpStart.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpEnd.Value.ToString("yyy-MM-dd");
            string carClass = (cbCarClass.SelectedItem == null)? "": cbCarClass.SelectedItem.ToString();
            int passengerNum = tbPassengerNum.Text.ToString() == "" ? 0 : int.Parse(tbPassengerNum.Text.ToString());
            decimal fuelConsumption = tbFuelConsuption.Text.ToString() == ""? 90: decimal.Parse(tbFuelConsuption.Text.ToString());
            decimal carPrice = tbCarPrice.Text.ToString() == ""? 10000: decimal.Parse(tbCarPrice.Text.ToString());

            List<Car> carsList = _carRepository.GetAvailableCars(dateStart, dateEnd, carClass, 
                                                                   passengerNum, fuelConsumption, carPrice);

            dgvTable.DataSource = null;
            dgvTable.Refresh();
            dgvTable.DataSource = carsList;
            dgvTable.Columns.Remove("RegNum");
            dgvTable.Columns.Remove("isOperating");


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
