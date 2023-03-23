using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using InputHandler;
using Map;
using Algo;
using System.Collections.Generic;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

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
        private TextBox StringInputBox;
        private MyAlgo Algo;
        private Timer timer;
        private int currentIndex;
        private List<List<bool>> visited;
        public MyGUI()
        {
            currentIndex = 0;
            timer = new Timer();
            Algo = new MyAlgo();
            visited = new List<List<bool>>();
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
            VisualizeButton.Text = "Search!";
            InputFileButton.Text = "Input File";

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

            // Set the data grid view cell font color
            MapDataGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.SaddleBrown;

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

            /*
                Setup string input box
            */
            // Create the string input box
            StringInputBox = new TextBox();

            // Set the string input box size
            StringInputBox.Size = new Size(295, 50);

            // Set the string input box location
            StringInputBox.Location = new Point(175, 260);

            // Set the string input box font
            StringInputBox.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            // Set the string input box font color
            StringInputBox.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the string input box border style
            StringInputBox.BorderStyle = BorderStyle.None;

            // Set the string input box background color
            StringInputBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;

            // Set the string input box text then clear it when clicked
            StringInputBox.Text = "Enter Delay Time (ms)";
            StringInputBox.KeyPress += new KeyPressEventHandler(CheckInputBox);
            StringInputBox.Click += new EventHandler(ClearStringInputBox);

            // Set the string input box text alignment
            StringInputBox.TextAlign = HorizontalAlignment.Center;

            // Set the string input box to not multi line
            StringInputBox.Multiline = false;

            // Set the string input box to not scrollable
            StringInputBox.ScrollBars = ScrollBars.None;

            // Set the string input box to not word wrap
            StringInputBox.WordWrap = false;

            // Set the string input box to not accept tab
            StringInputBox.AcceptsTab = false;

            // Add the string input box to the form
            this.Controls.Add(StringInputBox);
        }

        private void InputFile(object? sender, EventArgs e)
        {
            reset();
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
                InputHandlerFile file = new InputHandlerFile();
                file.readFile(SelectedFilePath);
                if (file.isValidFile() == false)
                {
                    InputFileButton.Text = "Invalid Input File!";
                    MessageBox.Show("Invalid Input File!");
                }
                else
                {
                    InputFileButton.Text = SelectedFileName;
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
                                MapDataGrid.Rows[i].Cells[j].Style.SelectionBackColor = Color.LightGoldenrodYellow;
                                MapDataGrid.Rows[i].Cells[j].Style.BackColor = Color.LightGoldenrodYellow;
                                MapDataGrid.Rows[i].Cells[j].Value = map.getMapData()[i, j];
                            }
                            else
                            {
                                MapDataGrid.Rows[i].Cells[j].Style.SelectionBackColor = Color.SaddleBrown;
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
                        // initialize MyAlgo class with map data and start point
                        Algo = new MyAlgo(map);
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
            if (SelectedFilePath != "" && SelectedFileName != "" && StringInputBox.Text != "" && StringInputBox.Text != "Enter Delay Time (ms)" && (BFSButton.Checked || DFSButton.Checked || TSPButton.Checked))
            {
                // jika memilih BFS
                if (BFSButton.Checked)
                {
                    // reset Algo
                    Algo.reset();
                    // jalankan BFS
                    Algo.BFSAlgorithmStrategies();
                    Algo.setResult();
                    StartAnimation();
                }
                // jika memilih DFS
                else if (DFSButton.Checked)
                {
                    // reset Algo
                    Algo.reset();
                    // jalankan DFS
                    // if want to use DFS 

                    // if want to use DFS with backtracking
                    Algo.dfsbacktrack();
                    Algo.setResult();
                    // change the color of the path to green
                    // foreach (var i in Algo.getPath())
                    // {
                    //     MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.Green;
                    //     // 
                    // }
                    // change the color of the path to green
                    StartAnimation();

                    // change the color of the visited nodes to red
                }
                // jika memilih TSP
                else if (TSPButton.Checked)
                {
                    // jalankan TSP
                }
            }
            else
            {
                if (SelectedFilePath == "" && SelectedFileName == "" && (StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)") && !(BFSButton.Checked || DFSButton.Checked || TSPButton.Checked))
                    MessageBox.Show("Please select the file, algorithm, and delay time!");
                else if ((StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)") && !(BFSButton.Checked || DFSButton.Checked || TSPButton.Checked))
                    MessageBox.Show("Please select the algorithm and delay time!");
                else if (SelectedFilePath == "" && SelectedFileName == "" && (StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)"))
                    MessageBox.Show("Please select the file and delay time!");
                else if (SelectedFilePath == "" && SelectedFileName == "" && !(BFSButton.Checked || DFSButton.Checked || TSPButton.Checked))
                    MessageBox.Show("Please select the file and algorithm!");
                else if (SelectedFilePath == "" && SelectedFileName == "")
                    MessageBox.Show("Please select the file!");
                else if ((StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)"))
                    MessageBox.Show("Please select the delay time!");
                else if (!(BFSButton.Checked || DFSButton.Checked || TSPButton.Checked))
                    MessageBox.Show("Please select the algorithm!");
            }
        }

        private void UseBFS(object? sender, EventArgs e)
        {
            Console.WriteLine("BFS");

        }

        private void UseDFS(object? sender, EventArgs e)
        {
            Console.WriteLine("DFS");

        }

        private void UseTSP(object? sender, EventArgs e)
        {
            // if (SelectedFilePath != "" && SelectedFileName != "")
            // {
                // Console.WriteLine("TSP");
            // }
            // else
            //     MessageBox.Show("Please select the file first!");
                // Reset radio button
                // TSPButton.Checked = false;
        }
        
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (this.currentIndex < Algo.getPath().Count)
            {
                var i = Algo.getPath()[currentIndex];

                // jika sudah pernah dikunjungi sebelumnya ubah warna menjadi orange,
                if (visited[i.Item1][i.Item2])
                {
                    // Console.WriteLine("visited");
                    MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.Orange;
                    MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.Orange;
                }
                // jika belum pernah dikunjungi sebelumnya ubah warna menjadi kuning
                else
                {
                    // Console.WriteLine("not visited");
                    MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.Yellow;
                    MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.Yellow;
                    // set visited attribute to true
                    visited[i.Item1][i.Item2] = true;
                }
                this.currentIndex++;
            }
            else
            {
                timer.Stop();
            }
        }
        private void StartAnimation()
        {
            resetColor();
            this.currentIndex = 0;
            var map = Algo.getMap();
            // clear visited list
            this.visited.Clear();
            // set to false all elements in visited list
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                List<bool> row = new List<bool>();
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    row.Add(false);
                }
                this.visited.Add(row);
            }

            timer = new Timer();
            int interval = Int32.Parse(StringInputBox.Text);
            if (interval <= 0)
            {
                timer.Interval = 1;
                timer.Tick += Timer_Tick;
            }
            else
            {
                timer.Interval = interval;
                timer.Tick += Timer_Tick;
            }
            timer.Start();
        }

        private void ClearStringInputBox(object? sender, EventArgs e)
        {
            StringInputBox.Text = "";
        }

        private void CheckInputBox(object? sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a digit or not
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // If not a digit, discard the key event and play a beep sound
                e.Handled = true;
                Console.Beep();
            }
        }

        private void reset(){
            // reset all radio buttons to unchecked
            BFSButton.Checked = false;
            DFSButton.Checked = false;
            TSPButton.Checked = false;
            // reset all text boxes to empty
            StringInputBox.Text = "Enter Delay Time (ms)";
            // // reset visited attribute
            // for (int i = 0; i < Algo.getPath().Count; i++)
            // {
            //     visited.Add(false);
            // }
        }
        
        private void resetColor(){
            var map = Algo.getMap();
            // reset all color to default color (lightgoldenrodyellow)
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    if (map.getMapData()[i, j] != 'X')
                    {
                        MapDataGrid.Rows[i].Cells[j].Style.SelectionBackColor = Color.LightGoldenrodYellow;
                        MapDataGrid.Rows[i].Cells[j].Style.BackColor = Color.LightGoldenrodYellow;
                    }
                    else
                    {
                        MapDataGrid.Rows[i].Cells[j].Style.SelectionBackColor = Color.SaddleBrown;
                        MapDataGrid.Rows[i].Cells[j].Style.BackColor = Color.SaddleBrown;
                    }
                }
            }
        }
    }
}