using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public class Layer
    {
        public string Name { get; set; }
        public double Transparence { get; set; } = 1;
        public Picture Foreground { get; set; }
        public Picture Background { get; set; }

        public Layer(string Name, Picture Foreground, Picture Background)
        {
            this.Name = Name;
            this.Foreground = Foreground;
            this.Background = Background;
        }
    }
}
