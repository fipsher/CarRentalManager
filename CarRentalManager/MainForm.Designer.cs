namespace CarRentalManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnPriceList = new System.Windows.Forms.Button();
            this.btnAvailableCars = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnCloseOrder = new System.Windows.Forms.Button();
            this.btnClientHistory = new System.Windows.Forms.Button();
            this.btnIncome = new System.Windows.Forms.Button();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.btnDelayedCars = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPriceList
            // 
            this.btnPriceList.Location = new System.Drawing.Point(24, 51);
            this.btnPriceList.Name = "btnPriceList";
            this.btnPriceList.Size = new System.Drawing.Size(130, 40);
            this.btnPriceList.TabIndex = 0;
            this.btnPriceList.Text = "Price List";
            this.btnPriceList.UseVisualStyleBackColor = true;
            this.btnPriceList.Click += new System.EventHandler(this.btnPriceList_Click);
            // 
            // btnAvailableCars
            // 
            this.btnAvailableCars.Location = new System.Drawing.Point(24, 106);
            this.btnAvailableCars.Name = "btnAvailableCars";
            this.btnAvailableCars.Size = new System.Drawing.Size(130, 40);
            this.btnAvailableCars.TabIndex = 1;
            this.btnAvailableCars.Text = "Available Cars";
            this.btnAvailableCars.UseVisualStyleBackColor = true;
            this.btnAvailableCars.Click += new System.EventHandler(this.btnAvailableCars_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(24, 219);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(130, 40);
            this.btnCreateOrder.TabIndex = 2;
            this.btnCreateOrder.Tag = "Create ";
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnCloseOrder
            // 
            this.btnCloseOrder.Location = new System.Drawing.Point(24, 277);
            this.btnCloseOrder.Name = "btnCloseOrder";
            this.btnCloseOrder.Size = new System.Drawing.Size(130, 40);
            this.btnCloseOrder.TabIndex = 3;
            this.btnCloseOrder.Tag = "Close Order";
            this.btnCloseOrder.Text = "Close Order";
            this.btnCloseOrder.UseVisualStyleBackColor = true;
            this.btnCloseOrder.Click += new System.EventHandler(this.btnCloseOrder_Click);
            // 
            // btnClientHistory
            // 
            this.btnClientHistory.Location = new System.Drawing.Point(24, 335);
            this.btnClientHistory.Name = "btnClientHistory";
            this.btnClientHistory.Size = new System.Drawing.Size(130, 40);
            this.btnClientHistory.TabIndex = 4;
            this.btnClientHistory.Tag = "Client History";
            this.btnClientHistory.Text = "Client History";
            this.btnClientHistory.UseVisualStyleBackColor = true;
            this.btnClientHistory.Click += new System.EventHandler(this.btnClientHistory_Click);
            // 
            // btnIncome
            // 
            this.btnIncome.Location = new System.Drawing.Point(24, 393);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(130, 40);
            this.btnIncome.TabIndex = 5;
            this.btnIncome.Text = "Income";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTable.Location = new System.Drawing.Point(234, 51);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.Size = new System.Drawing.Size(953, 475);
            this.dgvTable.TabIndex = 6;
            // 
            // btnDelayedCars
            // 
            this.btnDelayedCars.Location = new System.Drawing.Point(24, 162);
            this.btnDelayedCars.Name = "btnDelayedCars";
            this.btnDelayedCars.Size = new System.Drawing.Size(130, 40);
            this.btnDelayedCars.TabIndex = 7;
            this.btnDelayedCars.Text = "Delayed Cars";
            this.btnDelayedCars.UseVisualStyleBackColor = true;
            this.btnDelayedCars.Click += new System.EventHandler(this.btnDelayedCars_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(24, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 47);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 538);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelayedCars);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.btnClientHistory);
            this.Controls.Add(this.btnCloseOrder);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnAvailableCars);
            this.Controls.Add(this.btnPriceList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Rental Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPriceList;
        private System.Windows.Forms.Button btnAvailableCars;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnCloseOrder;
        private System.Windows.Forms.Button btnClientHistory;
        private System.Windows.Forms.Button btnIncome;
        public System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Button btnDelayedCars;
        private System.Windows.Forms.Button btnClose;
    }
}

