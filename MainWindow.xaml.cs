using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTocToeWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void PLAY_Click(object sender, RoutedEventArgs e)
        {
            //SystemSounds.Hand.Play();
            //SystemSounds.Exclamation.Play();
            // this.Close();
            this.Hide();
            Game game = new Game(0, 0);
            
            game.ShowDialog();
            
            Application.Current.Windows[0].Close();
            
            //this.Visibility = Visibility.Collapsed;

            
            
            
        }

        private void PLAY_MouseEnter(object sender, MouseEventArgs e)
        {
            PLAY.Height = 100;
            
        }
    }
}
