using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using InputHandler;
using Map;
using Algo;
using System.Collections.Generic;
using System.Linq;
using Timer = System.Timers.Timer;

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
        private CheckBox TSPToggle;
        private DataGridView MapDataGrid;
        private TextBox StringInputBox;
        private TextBox RouteBox;
        private Label ExecutionTimeLabel; 
        private Label StepsLabel;
        private Label NodesLabel;
        private Solver Algo;
        private Timer timer;
        private int currentIndex;
        private int afterIndex;
        private int totalNodes;
        private int totalSteps;
        private string route;
        private List<List<bool>> visited;
        public MyGUI()
        {
            currentIndex = 0;
            afterIndex = 0;
            totalNodes = 0;
            totalSteps = 0;
            route = "";
            timer = new Timer();
            Algo = new Solver();
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

            // Set the radio button text
            BFSButton.Text = "BFS";
            DFSButton.Text = "DFS";

            // Set the radio button font
            BFSButton.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            DFSButton.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);

            // Set the radio button font color
            BFSButton.ForeColor = System.Drawing.Color.SaddleBrown;
            DFSButton.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the radio button size
            BFSButton.Size = new Size(150, 50);
            DFSButton.Size = new Size(150, 50);

            // Set the radio button location
            BFSButton.Location = new Point(270, 350);
            DFSButton.Location = new Point(270, 390);

            // Set radio button color to transparent
            BFSButton.BackColor = System.Drawing.Color.Transparent;
            DFSButton.BackColor = System.Drawing.Color.Transparent;

            // Add the radio buttons to the form
            this.Controls.Add(BFSButton);
            this.Controls.Add(DFSButton);

            /*
                Setup toggle button
            */
            // Create the toggle button
            TSPToggle = new CheckBox();

            // Set the toggle button text
            TSPToggle.Text = "TSP";

            // Set the toggle button font
            TSPToggle.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);

            // Set the toggle button font color
            TSPToggle.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the toggle button size
            TSPToggle.Size = new Size(150, 50);

            // Set the toggle button location
            TSPToggle.Location = new Point(270, 430);

            // Set the toggle button color to transparent
            TSPToggle.BackColor = System.Drawing.Color.Transparent;

            // Add the toggle button to the form
            this.Controls.Add(TSPToggle);

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
                Setup text box
            */
            // Create the text box
            StringInputBox = new TextBox();
            RouteBox = new TextBox();

            // Set the text box size
            StringInputBox.Size = new Size(295, 50);
            RouteBox.Size = new Size(390, 65);

            // Set the text box location
            StringInputBox.Location = new Point(175, 260);
            RouteBox.Location = new Point(185, 600);

            // Set the text box font
            StringInputBox.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            RouteBox.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);

            // Add gap between the text and the border
            RouteBox.Margin = new Padding(100, 100, 100, 100);

            // Set the text box font color
            StringInputBox.ForeColor = System.Drawing.Color.SaddleBrown;
            RouteBox.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the text box border style
            StringInputBox.BorderStyle = BorderStyle.None;
            RouteBox.BorderStyle = BorderStyle.None;

            // Set the text box background color
            StringInputBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            RouteBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;

            // Set the text box text then clear it when clicked
            StringInputBox.Text = "Enter Delay Time (ms)";
            StringInputBox.KeyPress += new KeyPressEventHandler(CheckInputBox);
            StringInputBox.Click += new EventHandler(ClearStringInputBox);

            // Set the text box text alignment
            StringInputBox.TextAlign = HorizontalAlignment.Center;
            RouteBox.TextAlign = HorizontalAlignment.Center;

            // Set the text box to read only
            RouteBox.ReadOnly = true;

            // Set the text box to not multi line
            StringInputBox.Multiline = false;
            RouteBox.Multiline = true;

            // Set the text box to not scrollable
            StringInputBox.ScrollBars = ScrollBars.None;
            RouteBox.ScrollBars = ScrollBars.Vertical;

            // Set the text box to not word wrap
            StringInputBox.WordWrap = false;
            RouteBox.WordWrap = true;

            // Set the text box to not accept tab
            StringInputBox.AcceptsTab = false;
            RouteBox.AcceptsTab = false;

            // Add the text box to the form
            this.Controls.Add(StringInputBox);
            this.Controls.Add(RouteBox);

            /*
                Execution time label
            */
            // Create the execution time label
            ExecutionTimeLabel = new Label();
            StepsLabel = new Label();
            NodesLabel = new Label();

            // Set the execution time label size
            ExecutionTimeLabel.Size = new Size(150, 20);
            StepsLabel.Size = new Size(150, 20);
            NodesLabel.Size = new Size(150, 20);

            // Set the execution time label location
            ExecutionTimeLabel.Location = new Point(390, 762);
            StepsLabel.Location = new Point(275, 722);
            NodesLabel.Location = new Point(275, 678);

            // Set the execution time label font
            ExecutionTimeLabel.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            StepsLabel.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            NodesLabel.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);

            // Set the execution time label font color
            ExecutionTimeLabel.ForeColor = System.Drawing.Color.SaddleBrown;
            StepsLabel.ForeColor = System.Drawing.Color.SaddleBrown;
            NodesLabel.ForeColor = System.Drawing.Color.SaddleBrown;

            // Set the execution time label border style
            ExecutionTimeLabel.BorderStyle = BorderStyle.None;
            StepsLabel.BorderStyle = BorderStyle.None;
            NodesLabel.BorderStyle = BorderStyle.None;

            // Set the execution time label background color
            ExecutionTimeLabel.BackColor = System.Drawing.Color.Transparent;
            StepsLabel.BackColor = System.Drawing.Color.Transparent;
            NodesLabel.BackColor = System.Drawing.Color.Transparent;

            // Set the execution time label text alignment
            ExecutionTimeLabel.TextAlign = ContentAlignment.MiddleLeft;
            StepsLabel.TextAlign = ContentAlignment.MiddleLeft;
            NodesLabel.TextAlign = ContentAlignment.MiddleLeft;

            // Add the execution time label to the form
            this.Controls.Add(ExecutionTimeLabel);
            this.Controls.Add(StepsLabel);
            this.Controls.Add(NodesLabel);
        }

        private void InputFile(object? sender, EventArgs e)
        {
            reset();

            // Open the file dialog in the test folder of the project ../test
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test");

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
                        // initialize Solver class with map data and start point
                        Algo = new Solver(map);
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
            // Check if the input file is selected, the string input box is not empty, the string input box is not the default text, and one of the radio buttons is checked
            if (SelectedFilePath != "" && SelectedFileName != "" && StringInputBox.Text != "" && StringInputBox.Text != "Enter Delay Time (ms)" && (BFSButton.Checked || DFSButton.Checked))
            {
                Algo.reset();
                totalNodes = 0;
                totalSteps = 0;
                route = "";
                reset2();

                // Make new stopwatch
                var watch = System.Diagnostics.Stopwatch.StartNew();

                // TSP BFS
                if (TSPToggle.Checked && BFSButton.Checked)
                {
                    Algo.TSPAlgorithmStrategies();
                }
                else if (TSPToggle.Checked && DFSButton.Checked)
                {
                     // using dfs backtrack
                    Algo.DFSTsp();
                }
                // BFS
                else if (BFSButton.Checked)
                {
                    Algo.BFSAlgorithmStrategies();
                }
                // DFS
                else if (DFSButton.Checked) 
                {
                    Algo.dfsbacktrack();
                    // Algo.getPathToTreasureDFS();
                }

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                if (DFSButton.Checked && !TSPToggle.Checked) 
                {
                    // set path to treasure 
                    Algo.setPathToTreasure();                    
                }
        
                // Show the execution time
                ExecutionTimeLabel.Text = elapsedMs + " ms";

                // Set result
                printNodes();
                printSteps();
                printRoute();

                // Start animation
                StartAnimation();
            }
            else
            {
                if (SelectedFilePath == "" && SelectedFileName == "" && (StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)") && !(BFSButton.Checked || DFSButton.Checked))
                    MessageBox.Show("Please select the file, algorithm, and delay time!");
                else if ((StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)") && !(BFSButton.Checked || DFSButton.Checked))
                    MessageBox.Show("Please select the algorithm and delay time!");
                else if (SelectedFilePath == "" && SelectedFileName == "" && (StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)"))
                    MessageBox.Show("Please select the file and delay time!");
                else if (SelectedFilePath == "" && SelectedFileName == "" && !(BFSButton.Checked || DFSButton.Checked))
                    MessageBox.Show("Please select the file and algorithm!");
                else if (SelectedFilePath == "" && SelectedFileName == "")
                    MessageBox.Show("Please select the file!");
                else if ((StringInputBox.Text == "" || StringInputBox.Text == "Enter Delay Time (ms)"))
                    MessageBox.Show("Please select the delay time!");
                else if (!(BFSButton.Checked || DFSButton.Checked))
                    MessageBox.Show("Please select the algorithm!");
            }
        }
        
        private void DataGridViewAnimation(object? sender, EventArgs e)
        {
            if (this.currentIndex < Algo.getScannedPath().Count)
            {
                if (this.afterIndex < Algo.getScannedPath().Count)
                {
                    var after = Algo.getScannedPath()[afterIndex];
                    MapDataGrid.Rows[after.Item1].Cells[after.Item2].Style.SelectionBackColor = Color.SkyBlue;
                    MapDataGrid.Rows[after.Item1].Cells[after.Item2].Style.BackColor = Color.SkyBlue;
                }
                if (this.afterIndex > 0)
                {
                    var i = Algo.getScannedPath()[currentIndex];

                    if (visited[i.Item1][i.Item2])
                    {
                        if (MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor == Color.Orange)
                        {
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.OrangeRed;
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.OrangeRed;
                        }
                        else if (MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor == Color.OrangeRed)
                        {
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.Red;
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.Red;
                        }
                        else if (MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor == Color.Red)
                        {
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.DarkRed;
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.DarkRed;
                        }
                        else
                        {
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.Orange;
                            MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.Orange;
                        }
                    }
                    else
                    {
                        // Set scanning color to yellow
                        MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.Yellow;
                        MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.Yellow;

                        // Set visited attribute to true
                        visited[i.Item1][i.Item2] = true;
                    }
                    this.currentIndex++;
                }
                this.afterIndex++;
            }
            else if (this.currentIndex == Algo.getScannedPath().Count)
            {
                foreach (var i in Algo.getScannedPath())
                {
                    MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.SelectionBackColor = Color.Yellow;
                    MapDataGrid.Rows[i.Item1].Cells[i.Item2].Style.BackColor = Color.Yellow;
                }
                
                var map = Algo.getMap();

                // Clear visited list
                this.visited.Clear();

                // Set to false all elements in visited list
                for (int i = 0; i < map.getMapHeight(); i++)
                {
                    List<bool> row = new List<bool>();
                    for (int j = 0; j < map.getMapWidth(); j++)
                    {
                        row.Add(false);
                    }
                    this.visited.Add(row);
                }

                this.currentIndex++;
            }
            else
            {
                if (this.currentIndex <= (Algo.getPathToTreasure().Count + Algo.getScannedPath().Count))
                {
                    var j = Algo.getPathToTreasure()[currentIndex - Algo.getScannedPath().Count - 1];

                    if (visited[j.Item1][j.Item2])
                    {
                        if (MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.SelectionBackColor == Color.OrangeRed)
                        {
                            MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.SelectionBackColor = Color.Red;
                            MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.BackColor = Color.Red;
                        }
                        else if (MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.SelectionBackColor == Color.Red)
                        {
                            MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.SelectionBackColor = Color.DarkRed;
                            MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.BackColor = Color.DarkRed;
                        }
                        else
                        {
                            MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.SelectionBackColor = Color.OrangeRed;
                            MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.BackColor = Color.OrangeRed;
                        }
                    }
                    else
                    {
                        // Set default final path color to orange
                        MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.SelectionBackColor = Color.Orange;
                        MapDataGrid.Rows[j.Item1].Cells[j.Item2].Style.BackColor = Color.Orange;

                        // Set visited attribute to true
                        visited[j.Item1][j.Item2] = true;
                    }
                    this.currentIndex++;
                }
                else
                {
                    // Stop the timer
                    timer.Stop();
                }
            }
        }
        private void StartAnimation()
        {
            resetColor();
            this.afterIndex = 0;
            this.currentIndex = 0;
            var map = Algo.getMap();

            // Clear visited list
            this.visited.Clear();

            // Set to false all elements in visited list
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                List<bool> row = new List<bool>();
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    row.Add(false);
                }
                this.visited.Add(row);
            }

            int interval = Int32.Parse(StringInputBox.Text);
            if (interval <= 0)
            {
                timer = new Timer(double.Epsilon);
                timer.Elapsed += DataGridViewAnimation;
            }
            else
            {
                timer = new Timer(interval);
                timer.Elapsed += DataGridViewAnimation;
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
            // Reset all radio buttons to unchecked
            BFSButton.Checked = false;
            DFSButton.Checked = false;
            TSPToggle.Checked = false;

            // Reset all text boxes to empty
            StringInputBox.Text = "Enter Delay Time (ms)";

            reset2();
        }

        private void reset2(){
            // Reset all labels to empty
            RouteBox.Text = "";
            ExecutionTimeLabel.Text = "";
            StepsLabel.Text = "";
            NodesLabel.Text = "";
        }
        
        private void resetColor(){
            var map = Algo.getMap();

            // Reset all color to default color (lightgoldenrodyellow)
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

        private void printRoute()
        {
            var path = Algo.getPathToTreasure();
            route = "";
            for (int i = 0; i < path.Count; i++)
            {
                if (i < path.Count - 1)
                {
                    if (path[i].Item1 < path[i + 1].Item1)
                    {
                        route += "D";
                    }
                    else if (path[i].Item1 > path[i + 1].Item1)
                    {
                        route += "U";
                    }
                    else if (path[i].Item2 < path[i + 1].Item2)
                    {
                        route += "R";
                    }
                    else if (path[i].Item2 > path[i + 1].Item2)
                    {
                        route += "L";
                    }
                }

                if (i < path.Count - 2)
                {
                    route += " -> ";
                }
            }
            RouteBox.Text = route;   
        }

        private void printNodes()
        {
            totalNodes = Algo.getScannedPath().Count;
            NodesLabel.Text = totalNodes.ToString();
        }

        private void printSteps()
        {
            totalSteps = Algo.getPathToTreasure().Count - 1;
            StepsLabel.Text = totalSteps.ToString();
        }        
    }
}