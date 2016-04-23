using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using System.ComponentModel;

namespace OxyPlotSample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string title;
        private IList<DataPoint> points;

        public MainViewModel()
        {
            this.Title = "OxyPlotSample";
            this.Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15),
                new DataPoint(30, 16),
                new DataPoint(40, 12),
                new DataPoint(50, 12)
            };
        }

        public string Title {
            get
            {
                return title;
            }

            set
            {
                title = value;
                this.NotifyPropertyChanged("Title");
            }
        }

        public IList<DataPoint> Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
                this.NotifyPropertyChanged("Points");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
