using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryTesting;

namespace InventorySimulation
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private Button browseButton, displayButton, returnButton, showResult;
        Interaction interaction = new Interaction();
        public Form1()
        {
            InitializeComponent();

            InitializeButton();
            InitializeButton2();
            InitializeButton3();
            InitializeButton4();
            InitializeOpenFileDialog();
            //this.dataGridView1.Visible = false;
            showResult.Visible = false;
        }
        private void InitializeButton()
        {
            // Create a button
            browseButton = new Button();
            browseButton.Text = "Navigate";
            browseButton.Location = new System.Drawing.Point(400, 550);

            // Attach a click event handler to the button
            browseButton.Click += BrowseButtonClick;

            // Add the button to the form
            Controls.Add(browseButton);

        }

        private void InitializeButton2()
        {
            // Create a button
            displayButton = new Button();
            displayButton.Text = "Display";
            displayButton.Location = new System.Drawing.Point(1100, 550);

            // Attach a click event handler to the button
            displayButton.Click += display_click;

            // Add the button to the form
            Controls.Add(displayButton);

        }
        private void InitializeButton3()
        {
            // Create a button
            returnButton = new Button();
            returnButton.Text = "Home";
            returnButton.Location = new System.Drawing.Point(1350, 700);

            // Attach a click event handler to the button
            returnButton.Click += home_click;

            // Add the button to the form
            Controls.Add(returnButton);
            returnButton.Visible = false;
        }

        private void InitializeButton4()
        {
            // Create a button
            showResult = new Button();
            showResult.Text = "Testing Results";
            showResult.Location = new System.Drawing.Point(750, 700);

            // Attach a click event handler to the button
            showResult.Click += showTestResults;

            // Add the button to the form
            Controls.Add(showResult);

        }
        private void showTestResults(object sender, EventArgs e)
        {
            this.interaction.show_testing_results();
        }
        private void display_click(object sender, EventArgs e)
        {
            displayButton.Visible = false;
            showResult.Visible = true;
            browseButton.Visible = false;
            returnButton.Visible = true;

            // Initialize table then show it
            dataGridView1.Rows.Add(); // array of strings
            dataGridView1.Visible = true;

            for (int i = 0; i < this.interaction.mySystem.NumberOfDays; i++)
            {
                dataGridView1.Rows.Add(this.interaction.getRow(i));
            }

            this.interaction.showPerformanceData();
        }
        private void home_click(object sender, EventArgs e)
        {
            displayButton.Visible = true;
            browseButton.Visible = true;
            showResult.Visible = false;
            returnButton.Visible = false;
            dataGridView1.Visible = false;
        }

        private void BrowseButtonClick(object sender, EventArgs e)
        {
            // Show the OpenFileDialog and get the result
            DialogResult result = openFileDialog.ShowDialog();

            // Check if the user selected a file
            if (result == DialogResult.OK)
            {
                // Read the contents of the selected file
                string filePath = openFileDialog.FileName;
                try
                {
                    //MessageBox.Show(filePath);
                    this.interaction.filePath = filePath;
                    dataGridView1.Rows.Clear();
                    string fileContent = File.ReadAllText(filePath);
                    this.interaction.content = fileContent;
                    this.interaction.init();
                    //MessageBox.Show("hi");

                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error reading the file: {ex.Message}");
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeOpenFileDialog()
        {
            // Create an OpenFileDialog instance
            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "All Files (*.*)|*.*";

            // Set the default directory (optional)
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
