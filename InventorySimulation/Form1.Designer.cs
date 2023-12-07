namespace InventorySimulation
{
    partial class Form1
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

        //#region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day_within_cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginning_inventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.random_digit_for_dm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ending_inventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortage_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.random_digit_for_lead_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lead_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.Cycle,
            this.day_within_cycle,
            this.beginning_inventory,
            this.random_digit_for_dm,
            this.demand,
            this.ending_inventory,
            this.shortage_quantity,
            this.order_quantity,
            this.random_digit_for_lead_time,
            this.lead_time});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1438, 713);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.MinimumWidth = 6;
            this.Day.Name = "Day";
            this.Day.Width = 125;
            // 
            // Cycle
            // 
            this.Cycle.HeaderText = "Cycle";
            this.Cycle.MinimumWidth = 6;
            this.Cycle.Name = "Cycle";
            this.Cycle.Width = 125;
            // 
            // day_within_cycle
            // 
            this.day_within_cycle.HeaderText = "Day within cycle";
            this.day_within_cycle.MinimumWidth = 6;
            this.day_within_cycle.Name = "day_within_cycle";
            this.day_within_cycle.Width = 125;
            // 
            // beginning_inventory
            // 
            this.beginning_inventory.HeaderText = "Beginning Inventory";
            this.beginning_inventory.MinimumWidth = 6;
            this.beginning_inventory.Name = "beginning_inventory";
            this.beginning_inventory.Width = 125;
            // 
            // random_digit_for_dm
            // 
            this.random_digit_for_dm.HeaderText = "Random Digit Demand";
            this.random_digit_for_dm.MinimumWidth = 6;
            this.random_digit_for_dm.Name = "random_digit_for_dm";
            this.random_digit_for_dm.Width = 125;
            // 
            // demand
            // 
            this.demand.HeaderText = "Demand";
            this.demand.MinimumWidth = 6;
            this.demand.Name = "demand";
            this.demand.Width = 125;
            // 
            // ending_inventory
            // 
            this.ending_inventory.HeaderText = "Ending Inventory";
            this.ending_inventory.MinimumWidth = 6;
            this.ending_inventory.Name = "ending_inventory";
            this.ending_inventory.Width = 125;
            // 
            // shortage_quantity
            // 
            this.shortage_quantity.HeaderText = "Shortage_quantity";
            this.shortage_quantity.MinimumWidth = 6;
            this.shortage_quantity.Name = "shortage_quantity";
            this.shortage_quantity.Width = 125;
            // 
            // order_quantity
            // 
            this.order_quantity.HeaderText = "Order Quantity";
            this.order_quantity.MinimumWidth = 6;
            this.order_quantity.Name = "order_quantity";
            this.order_quantity.Width = 125;
            // 
            // random_digit_for_lead_time
            // 
            this.random_digit_for_lead_time.HeaderText = "Random Lead Time";
            this.random_digit_for_lead_time.MinimumWidth = 6;
            this.random_digit_for_lead_time.Name = "random_digit_for_lead_time";
            this.random_digit_for_lead_time.Width = 125;
            // 
            // lead_time
            // 
            this.lead_time.HeaderText = "Lead Time";
            this.lead_time.MinimumWidth = 6;
            this.lead_time.Name = "lead_time";
            this.lead_time.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 652);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        //#endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn day_within_cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginning_inventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn random_digit_for_dm;
        private System.Windows.Forms.DataGridViewTextBoxColumn demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ending_inventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortage_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn random_digit_for_lead_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn lead_time;
    }
}