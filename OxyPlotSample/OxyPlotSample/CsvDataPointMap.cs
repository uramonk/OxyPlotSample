using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlotSample
{
    class CsvDataPointMap : CsvClassMap<CsvDataPoint>
    {
        public CsvDataPointMap()
        {
            Map(m => m.X).Index(0);
            Map(m => m.Y).Index(1);
        }
    }
}
