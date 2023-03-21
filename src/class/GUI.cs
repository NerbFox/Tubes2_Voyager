using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

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
        }

        private void InputFile(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFilePath = openFileDialog.FileName;
                SelectedFileName = Path.GetFileName(SelectedFilePath);
                InputFileButton.Text = SelectedFileName;
            }
        }

        private void StartVisualize(object? sender, EventArgs e)
        {

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