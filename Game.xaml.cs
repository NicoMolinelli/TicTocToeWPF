using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace TicTocToeWPF
{
    /// <summary>
    /// Logica di interazione per Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public int PunteggioX { get; set; }
        public int PunteggioO { get; set; }
        public string moveSymbol = "X";
        public Dowel[,] dowels;
        public int moves = 0;
        public MediaPlayer MediaPlayer;
       
        public Game(int punteggioX, int punteggioO)
        {
            InitializeComponent();
            this.PunteggioX = punteggioX;
            this.PunteggioO = punteggioO; 
            SetField();
            MediaPlayer = new MediaPlayer();
            MediaPlayer.Open(new Uri("D:\\Musica\\Remix scialli\\N.A.S.A. - Gifted (Masuka Remix).mp3"));
            MediaPlayer.Play();
        }


        private void SetField()
        {
            dowels = new Dowel[3, 3];
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    dowels[y, x] = new Dowel("null", y, x);
        }

        

        private void ChangeMove()
        {
            moveSymbol = moveSymbol.Equals("X") ? "O" : "X";
        }


        

        private void Btn00_Click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;

            b.Content = moveSymbol;
            
            b.Background = (moveSymbol == "X") ? Brushes.Blue : Brushes.Red;

            moves++;
            

            
            dowels[int.Parse(b.Name.Substring(3, 1)), int.Parse(b.Name.Substring(4, 1))] = new Dowel(moveSymbol, int.Parse(b.Name.Substring(3, 1)), int.Parse(b.Name.Substring(4, 1)));
            //Debug.WriteLine(CheckWin().ToString());
            if (CheckWin())
            {
                MediaPlayer.Pause();
                SystemSounds.Exclamation.Play();
                MessageBoxResult messageBoxResult = MessageBox.Show("Player " + moveSymbol + " ha vinto!\n Continuare a giocare?", "Vittoria", MessageBoxButton.YesNo);



                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    MediaPlayer.Play();
                    SetField();
                    ResetButtons();
                    moves = 0;
                    if (moveSymbol.Equals("X"))
                    {
                        this.PunteggioX++;
                        tbScoreP1.Text = this.PunteggioX.ToString();
                    }
                    else
                    {
                        this.PunteggioO++;
                        tbScoreP2.Text = this.PunteggioO.ToString();
                    }

                }
                else
                {
                    this.Close();
                }
            }
            else if (moves == 9)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Avete Pareggiato! Buono\n Continuare a Giocare?", "Pareggio", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    SetField();
                    ResetButtons();
                    moves = 0;
                }
            }
            ChangeMove();
        }

        public void ResetButtons()
        {
            btn00.Content = "";
            btn00.IsEnabled = true;
            btn00.Background = Brushes.White;
            btn01.Content = "";
            btn01.IsEnabled = true;
            btn01.Background = Brushes.White;
            btn10.Content = "";
            btn10.IsEnabled = true;
            btn10.Background = Brushes.White;
            btn20.Content = "";
            btn20.IsEnabled = true;
            btn20.Background = Brushes.White;
            btn02.Content = "";
            btn02.IsEnabled = true;
            btn02.Background = Brushes.White;
            btn12.Content = "";
            btn12.IsEnabled = true;
            btn12.Background = Brushes.White;
            btn21.Content = "";
            btn21.IsEnabled = true;
            btn21.Background = Brushes.White;
            btn11.Content = "";
            btn11.IsEnabled = true;
            btn11.Background = Brushes.White;
            btn22.Content = "";
            btn22.IsEnabled = true;
            btn22.Background = Brushes.White;
        }

        public bool CheckWin()
        {
            bool win = false;


            //Horizontal Lines
            for (int x = 0; x < 3; x++)
            {
                string temp = dowels[0, x].Content;
                Debug.WriteLine(temp);
                if (temp.Equals("null"))
                    continue;
                    
                for (int y = 1; y < 3; y++)
                {
                   // Debug.WriteLine(dowels[x, y].Content);
                    if ((y == 2) && (dowels[y, x].Content.Equals(temp)))
                    
                        return true;
                        
                    else if (dowels[y, x].Content.Equals(temp))
                    
                        continue;
                    
                    else

                        break;
                }
            }
            //Vertical Lines
            for (int y = 0; y < 3; y++)
            {
                string temp = dowels[y, 0].Content;
                Debug.WriteLine(temp);
                if (temp.Equals("null"))
                    continue;

                for (int x = 1; x < 3; x++)
                {
                    // Debug.WriteLine(dowels[x, y].Content);
                    if ((x == 2) && (dowels[y, x].Content.Equals(temp)))

                        return true;

                    else if (dowels[y, x].Content.Equals(temp))

                        continue;

                    else

                        break;
                }
            }

            //Diagonal Lines
            string dowel00 = !dowels[0, 0].Content.Equals("null") ? dowels[0, 0].Content : "";
            if (dowels[1, 1].Content.Equals(dowel00))
                if (dowels[2, 2].Content.Equals(dowel00))
                    return true;
            string dowel20 = !dowels[2, 0].Content.Equals("null") ? dowels[2, 0].Content : "";
            if (dowels[1, 1].Content.Equals(dowel20))
                if (dowels[0, 2].Content.Equals(dowel20))
                    return true;


            return win;
         }
    }
 }
