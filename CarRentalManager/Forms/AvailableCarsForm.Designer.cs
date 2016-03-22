namespace CarRentalManager.Forms
{
    partial class AvailableCarsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableCarsForm));
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDay = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCarClass = new System.Windows.Forms.Label();
            this.cbCarClass = new System.Windows.Forms.ComboBox();
            this.lblPassengerNum = new System.Windows.Forms.Label();
            this.tbPassengerNum = new System.Windows.Forms.TextBox();
            this.tbFuelConsuption = new System.Windows.Forms.TextBox();
            this.lblFuelConsuption = new System.Windows.Forms.Label();
            this.lblCarPrice = new System.Windows.Forms.Label();
            this.tbCarPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-mm-dd";
            this.dtpStart.Location = new System.Drawing.Point(12, 35);
            this.dtpStart.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 0;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(74, 15);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(72, 17);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblEndDay
            // 
            this.lblEndDay.AutoSize = true;
            this.lblEndDay.Location = new System.Drawing.Point(351, 15);
            this.lblEndDay.Name = "lblEndDay";
            this.lblEndDay.Size = new System.Drawing.Size(67, 17);
            this.lblEndDay.TabIndex = 2;
            this.lblEndDay.Text = "End Date";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-mm-dd";
            this.dtpEnd.Location = new System.Drawing.Point(287, 35);
            this.dtpEnd.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpEnd.TabIndex = 3;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(87, 267);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(115, 42);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(278, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 42);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCarClass
            // 
            this.lblCarClass.AutoSize = true;
            this.lblCarClass.Location = new System.Drawing.Point(84, 85);
            this.lblCarClass.Name = "lblCarClass";
            this.lblCarClass.Size = new System.Drawing.Size(68, 17);
            this.lblCarClass.TabIndex = 6;
            this.lblCarClass.Text = "Car Class";
            // 
            // cbCarClass
            // 
            this.cbCarClass.FormattingEnabled = true;
            this.cbCarClass.Items.AddRange(new object[] {
            "Mini",
            "Economy",
            "Compact",
            "Mid-Size",
            "Family-Size",
            "Minivan"});
            this.cbCarClass.Location = new System.Drawing.Point(14, 120);
            this.cbCarClass.Name = "cbCarClass";
            this.cbCarClass.Size = new System.Drawing.Size(200, 24);
            this.cbCarClass.TabIndex = 7;
            // 
            // lblPassengerNum
            // 
            this.lblPassengerNum.AutoSize = true;
            this.lblPassengerNum.Location = new System.Drawing.Point(41, 173);
            this.lblPassengerNum.Name = "lblPassengerNum";
            this.lblPassengerNum.Size = new System.Drawing.Size(130, 17);
            this.lblPassengerNum.TabIndex = 8;
            this.lblPassengerNum.Text = "Passenger Number";
            // 
            // tbPassengerNum
            // 
            this.tbPassengerNum.Location = new System.Drawing.Point(57, 201);
            this.tbPassengerNum.Name = "tbPassengerNum";
            this.tbPassengerNum.Size = new System.Drawing.Size(100, 22);
            this.tbPassengerNum.TabIndex = 9;
            this.tbPassengerNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFuelConsuption
            // 
            this.tbFuelConsuption.Location = new System.Drawing.Point(333, 201);
            this.tbFuelConsuption.Name = "tbFuelConsuption";
            this.tbFuelConsuption.Size = new System.Drawing.Size(100, 22);
            this.tbFuelConsuption.TabIndex = 11;
            this.tbFuelConsuption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFuelConsuption
            // 
            this.lblFuelConsuption.AutoSize = true;
            this.lblFuelConsuption.Location = new System.Drawing.Point(330, 173);
            this.lblFuelConsuption.Name = "lblFuelConsuption";
            this.lblFuelConsuption.Size = new System.Drawing.Size(110, 17);
            this.lblFuelConsuption.TabIndex = 10;
            this.lblFuelConsuption.Text = "Fuel Consuption";
            // 
            // lblCarPrice
            // 
            this.lblCarPrice.AutoSize = true;
            this.lblCarPrice.Location = new System.Drawing.Point(319, 85);
            this.lblCarPrice.Name = "lblCarPrice";
            this.lblCarPrice.Size = new System.Drawing.Size(128, 17);
            this.lblCarPrice.TabIndex = 12;
            this.lblCarPrice.Text = "Car Price (per day)";
            // 
            // tbCarPrice
            // 
            this.tbCarPrice.Location = new System.Drawing.Point(333, 120);
            this.tbCarPrice.Name = "tbCarPrice";
            this.tbCarPrice.Size = new System.Drawing.Size(100, 22);
            this.tbCarPrice.TabIndex = 13;
            this.tbCarPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AvailableCarsForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 332);
            this.Controls.Add(this.tbCarPrice);
            this.Controls.Add(this.lblCarPrice);
            this.Controls.Add(this.tbFuelConsuption);
            this.Controls.Add(this.lblFuelConsuption);
            this.Controls.Add(this.tbPassengerNum);
            this.Controls.Add(this.lblPassengerNum);
            this.Controls.Add(this.cbCarClass);
            this.Controls.Add(this.lblCarClass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEndDay);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AvailableCarsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AvailableCarsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDay;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblCarClass;
        private System.Windows.Forms.ComboBox cbCarClass;
        private System.Windows.Forms.Label lblPassengerNum;
        private System.Windows.Forms.TextBox tbPassengerNum;
        private System.Windows.Forms.TextBox tbFuelConsuption;
        private System.Windows.Forms.Label lblFuelConsuption;
        private System.Windows.Forms.Label lblCarPrice;
        private System.Windows.Forms.TextBox tbCarPrice;
    }
}