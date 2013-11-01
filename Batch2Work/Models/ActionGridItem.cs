using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Batch2Work.Models
{
    public class ActionGridItem
    {
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Area { get; set; }
        public string Item { get; set; }
        public string ProductType { get; set; }
        public string AsbestosType { get; set; }
        public string Quantity { get; set; }
        public string InspFreq { get; set; }
        public int MaScore { get; set; }
        public int PaScore { get; set; }
        public int RiskScore { get; set; }
        public string RiskCategory { get; set; }
        public string RecAction { get; set; }

        public string Key
        {
            get
            {
                return Building + "," + Floor + "," + Area + "," + Item;
            }
        }
    }
}