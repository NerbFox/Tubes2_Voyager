using System;
using System.Drawing;
using System.Windows.Forms;
using Algorithm;
using InputHandler;
using Map;
using GUI;

namespace Main
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.Run(new MyGUI());
    }
  }
}