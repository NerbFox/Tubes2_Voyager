using System;
using System.Windows.Forms;
using Algorithm;
using inputHandler;
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
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MyForm());
    }
  }
}