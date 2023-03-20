using System;
using System.Drawing;
using System.Windows.Forms;


namespace GUI
{
    public class MyGUI : Form
    {
        int window_width = 1920;
        int window_height = 1080;
        // Atribute
        private Button VisualizeButton;
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
            this.ClientSize = new System.Drawing.Size(window_width, window_height);
            
            // Set the background image of the form
            this.BackgroundImage = Image.FromFile(@"UI\Background.png");

            // Set the window icon
            this.Icon = new Icon(@"UI\Icon.ico");
            
            // Make sure the background image is scaled to fit the size of the form
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Set the form to non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            /*
                Setup Button
            */
            // Create the button
            VisualizeButton = new Button();

            // Set the button text
            VisualizeButton.Text = "Visualize";

            // Set the button font
            VisualizeButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            // Set the button font color
            VisualizeButton.ForeColor = System.Drawing.Color.White;

            // Set the button size
            VisualizeButton.Size = new Size(125, 35);

            // Set the button location
            VisualizeButton.Location = new Point(150, 475);

            // Add color to the button
            VisualizeButton.BackColor = System.Drawing.Color.MediumSlateBlue;

            // Remove the border of the button
            VisualizeButton.FlatAppearance.BorderSize = 0;

            // Set flat style to the button
            VisualizeButton.FlatStyle = FlatStyle.Flat;

            // Add a hover effect to the button
            VisualizeButton.UseVisualStyleBackColor = false;

            // Button click event
            VisualizeButton.Click += new EventHandler(StartVisualize);

            // Add the button to the form
            this.Controls.Add(VisualizeButton);

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
            BFSButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            DFSButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            TSPButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            // Set the radio button font color
            BFSButton.ForeColor = System.Drawing.Color.White;
            DFSButton.ForeColor = System.Drawing.Color.White;
            TSPButton.ForeColor = System.Drawing.Color.White;

            // Set the radio button size
            BFSButton.Size = new Size(125, 35);
            DFSButton.Size = new Size(125, 35);
            TSPButton.Size = new Size(125, 35);

            // Set the radio button location
            BFSButton.Location = new Point(175, 350);
            DFSButton.Location = new Point(175, 375);
            TSPButton.Location = new Point(175, 400);

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