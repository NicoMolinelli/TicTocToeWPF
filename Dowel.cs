using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToeWPF
{
    public class Dowel
    {
        
        public string Content { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsCentrum { get; set; }
        public bool IsVerticalMiddle { get; set; }
        public bool IsHorizontalMiddle { get; set; }


        public Dowel(string content, int column, int row)
            {
            this.Content = content;
            this.Column = column;
            this.Row = row;
            this.IsCentrum = (column == 1 && row == 1) ? true : false;
            this.IsHorizontalMiddle = (column == 1 && row == 0) || (column == 1 && row == 2) ? true : false;
            this.IsVerticalMiddle = (column == 0 && row == 1) || (column == 2 && row == 1) ? true : false;
        }
        public Dowel(string content)
        {
            this.Content = content;
        }


    }
}
