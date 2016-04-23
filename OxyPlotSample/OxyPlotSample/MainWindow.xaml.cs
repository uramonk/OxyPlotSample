using CsvHelper;
using Microsoft.Win32;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace OxyPlotSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "CSVファイル(.csv)|*.csv";
            if (ofd.ShowDialog() == true)
            {
                String[] names = ofd.FileName.Split('\\');
                this.mainViewModel.Title = names[names.Length - 1];

                loadCsv(ofd.FileName);
            }
        }

        private void loadCsv(string path)
        {
            CsvParser parser = new CsvParser(new StreamReader(path, Encoding.GetEncoding("utf-8")));
            parser.Configuration.HasHeaderRecord = true;
            parser.Configuration.RegisterClassMap<CsvDataPointMap>();

            CsvReader reader = new CsvReader(parser);
            List<CsvDataPoint> csvDataPoints = reader.GetRecords<CsvDataPoint>().ToList();
            string[] headers = reader.FieldHeaders;

            IList<DataPoint> points = new List<DataPoint>();
            for(int i = 0; i < csvDataPoints.Count; i++)
            {
                CsvDataPoint csvDataPoint = csvDataPoints[i];
                points.Add(new DataPoint(csvDataPoint.X, csvDataPoint.Y));
                Console.WriteLine(csvDataPoint.X + ", " + csvDataPoint.Y);
            }

            this.mainViewModel.Points = points;
        }
    }
}
