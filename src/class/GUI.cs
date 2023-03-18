using System;
using System.Windows.Forms;

namespace GUI
{
    public class MyForm : Form
    {
        private Button myButton;

        public MyForm()
        {
            // Set up the form
            this.Text = "My Form";
            this.ClientSize = new System.Drawing.Size(200, 100);

            // Set up the button
            this.myButton = new Button();
            this.myButton.Text = "Click Me!";
            this.myButton.Location = new System.Drawing.Point(50, 25);
            this.myButton.Click += new EventHandler(this.Button_Click);

            // Add the button to the form
            this.Controls.Add(this.myButton);
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Hello, World!");
        }
    }
}