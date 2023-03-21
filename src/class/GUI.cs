using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using InputHandler;
using Map;

namespace GUI
{
    public class MyGUI : Form
    {
        // Atribute
        private string SelectedFilePath = "";
        private string SelectedFileName = "";
        private Button VisualizeButton;
        private Button InputFileButton;
        private RadioButton BFSButton;
        private RadioButton DFSButton;
        private RadioButton TSPButton;
        private DataGridView MapDataGrid;

        public MyGUI()
        {
            /*
                Setup Window
            */
            // Set up the form
            this.Name = "VoyagerGUI";
            this.Text = "Voyager";
            this.MaximizeBox = false;
            this.ClientSize = new System.Drawing.Size(1920, 1000);
            
            // Set the background image of the form
            this.BackgroundImage = Image.FromFile(@"UI\Background.png");

            // Set the window icon
            this.Icon = new Icon(@"UI\Icon.ico");
            
            // Make sure the background image is scaled to fit the size of the form
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Set the form to non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Set the form to be in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            /*
                Setup Buttons
            */
            // Create the button
            VisualizeButton = new Button();
            InputFileButton = new Button();

            // Set the button text
            VisualizeButton.Text = "Visualize";
            InputFileButton.Text = "Input txt File";

            // Set the button font
            VisualizeButton.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            InputFileButton.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);

            // Set the button font color
            VisualizeButton.ForeColor = System.Drawing.Color.SaddleBrown;
            InputFileButton.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the button size
            VisualizeButton.Size = new Size(150, 50);
            InputFileButton.Size = new Size(300, 50);

            // Set the button location
            VisualizeButton.Location = new Point(240, 485);
            InputFileButton.Location = new Point(172, 200);

            // Add color to the button
            VisualizeButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            InputFileButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;

            // Remove the border of the button
            VisualizeButton.FlatAppearance.BorderSize = 0;
            InputFileButton.FlatAppearance.BorderSize = 0;

            // Set flat style to the button
            VisualizeButton.FlatStyle = FlatStyle.Standard;
            InputFileButton.FlatStyle = FlatStyle.Standard;

            // Add a hover effect to the button
            VisualizeButton.UseVisualStyleBackColor = false;
            InputFileButton.UseVisualStyleBackColor = false;

            // Button click event
            VisualizeButton.Click += new EventHandler(StartVisualize);
            InputFileButton.Click += new EventHandler(InputFile);

            // Add the button to the form
            this.Controls.Add(VisualizeButton);
            this.Controls.Add(InputFileButton);

            /*
                Setup 3 Radio Buttons
            */
            // Create the radio buttons
            BFSButton = new RadioButton();
            DFSButton = new RadioButton();
            TSPButton = new RadioButton();

            // Set the radio button text
            BFSButton.Text = "BFS";
            DFSButton.Text = "DFS";
            TSPButton.Text = "TSP";

            // Set the radio button font
            BFSButton.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            DFSButton.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            TSPButton.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);

            // Set the radio button font color
            BFSButton.ForeColor = System.Drawing.Color.SaddleBrown;
            DFSButton.ForeColor = System.Drawing.Color.SaddleBrown;
            TSPButton.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the radio button size
            BFSButton.Size = new Size(150, 50);
            DFSButton.Size = new Size(150, 50);
            TSPButton.Size = new Size(150, 50);

            // Set the radio button location
            BFSButton.Location = new Point(270, 350);
            DFSButton.Location = new Point(270, 390);
            TSPButton.Location = new Point(270, 430);

            // Set radio button color to transparent
            BFSButton.BackColor = System.Drawing.Color.Transparent;
            DFSButton.BackColor = System.Drawing.Color.Transparent;
            TSPButton.BackColor = System.Drawing.Color.Transparent;

            // Set the radio button to checked
            BFSButton.CheckedChanged += new System.EventHandler(UseBFS);
            DFSButton.CheckedChanged += new System.EventHandler(UseDFS);
            TSPButton.CheckedChanged += new System.EventHandler(UseTSP);

            // Add the radio buttons to the form
            this.Controls.Add(BFSButton);
            this.Controls.Add(DFSButton);
            this.Controls.Add(TSPButton);

            /*
                Setup Data Grid View
            */
            // Create the data grid view
            MapDataGrid = new DataGridView();

            // Set the data grid view size
            MapDataGrid.Size = new Size(600, 600);

            // Set the data grid view location
            MapDataGrid.Location = new Point(770, 195);

            // Set the data grid view font color
            MapDataGrid.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the data grid view width to fill
            MapDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set the data grid view border style
            MapDataGrid.BorderStyle = BorderStyle.None;

            // Set the data grid to non scrollable
            MapDataGrid.ScrollBars = ScrollBars.None;

            // Set the data grid view border line to saddle brown
            MapDataGrid.GridColor = System.Drawing.Color.SaddleBrown;

            // Set the data grid view row headers visible
            MapDataGrid.RowHeadersVisible = false;

            // Set the data grid view column headers visible
            MapDataGrid.ColumnHeadersVisible = false;

            // Set the data grid view cell read only
            MapDataGrid.ReadOnly = true;

            // User cannot add or delete rows
            MapDataGrid.AllowUserToAddRows = false;
            MapDataGrid.AllowUserToDeleteRows = false;

            // User cannot resize the data grid view
            MapDataGrid.AllowUserToResizeColumns = false;
            MapDataGrid.AllowUserToResizeRows = false;

            // Align text to the center
            MapDataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Add the data grid view to the form
            this.Controls.Add(MapDataGrid);
        }

        private void InputFile(object? sender, EventArgs e)
        {
            // Open the file dialog in the test folder of the project ../test
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            // openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            // openFileDialog.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            
            // openFileDialog.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\test";

            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test");
            // Console.WriteLine(openFileDialog.InitialDirectory);

            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFilePath = openFileDialog.FileName;
                SelectedFileName = Path.GetFileName(SelectedFilePath);
                InputFileButton.Text = SelectedFileName;
                InputHandlerFile file = new InputHandlerFile();
                file.readFile(SelectedFilePath);
                MyMap map = new MyMap(file.getInputData());

                // Clear the data grid view
                MapDataGrid.Rows.Clear();
                MapDataGrid.Columns.Clear();

                MapDataGrid.ColumnCount = map.getMapWidth();
                MapDataGrid.RowCount = map.getMapHeight();

                for (int i = 0; i < map.getMapHeight(); i++)
                {
                    for (int j = 0; j < map.getMapWidth(); j++)
                    {
                        if (map.getMapData()[i, j] != 'X')
                        {
                            MapDataGrid.Rows[i].Cells[j].Style.BackColor = Color.LightGoldenrodYellow;
                            MapDataGrid.Rows[i].Cells[j].Value = map.getMapData()[i, j];
                        }
                        else
                        {
                            MapDataGrid.Rows[i].Cells[j].Style.BackColor = Color.SaddleBrown;
                            MapDataGrid.Rows[i].Cells[j].Value = "";
                        }
                    }
                    // Set the data grid view column width
                    MapDataGrid.Rows[i].Height = 600/map.getMapHeight();
                    if (map.getMapHeight() < map.getMapWidth())
                    {
                        MapDataGrid.Font = new Font("Microsoft Sans Serif", (600/map.getMapWidth())/3, FontStyle.Bold);
                    }
                    else
                    {
                        MapDataGrid.Font = new Font("Microsoft Sans Serif", (600/map.getMapHeight())/3, FontStyle.Bold);
                    }
                }
            }
            else
            {
                SelectedFilePath = "";
                SelectedFileName = "";
                InputFileButton.Text = "Input File";
            }

        }

        private void StartVisualize(object? sender, EventArgs e)
        {
            // jika sudah memilih file dan sudah memilih algoritma
            if (SelectedFilePath != "" && SelectedFileName != "" && (BFSButton.Checked || DFSButton.Checked || TSPButton.Checked))
            {
                // jika memilih BFS
                if (BFSButton.Checked)
                {
                    // jalankan BFS
                }
                // jika memilih DFS
                else if (DFSButton.Checked)
                {
                    // jalankan DFS
                }
                // jika memilih TSP
                else if (TSPButton.Checked)
                {
                    // jalankan TSP
                }
            }
            else
            {
                MessageBox.Show("Please select the file and algorithm first!");
            }
        }

        private void UseBFS(object? sender, EventArgs e)
        {
            
        }

        private void UseDFS(object? sender, EventArgs e)
        {

        }

        private void UseTSP(object? sender, EventArgs e)
        {

        }
    }
}