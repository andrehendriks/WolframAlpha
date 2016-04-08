using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WolframAlphaNET;
using WolframAlphaNET.Enums;
using WolframAlphaNET.Misc;
using WolframAlphaNET.Objects;
using System.Speech;


namespace WpfWolframAlpha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }
        string input = Console.ReadLine();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            WolframAlpha wolfram = new WolframAlpha("PARW2K-U872JW7QTL");
            QueryResult results = wolfram.Query(input);
        }

        
    }
}
