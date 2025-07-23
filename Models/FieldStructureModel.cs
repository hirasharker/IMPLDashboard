using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPLDashboard.Models
{
    public class FieldStructureModel
    {
    }
    public class Route
    {
        public int ROUTE_ID { get; set; }
        public string ROUTE_NAME { get; set; }
        public int OUTLET_COUNT { get; set; }
    }
    public class Dealer
    {
        public int DEALER_ID { get; set; }
        public string DEALER_NAME { get; set; }
        public int OUTLET_COUNT { get; set; }
        public List<Route> ROUTES { get; set; } = new List<Route>();
    }

    public class Town
    {
        public int TOWN_ID { get; set; }
        public string TOWN_NAME { get; set; }
        public int OUTLET_COUNT { get; set; }
        public List<Dealer> DEALERS { get; set; } = new List<Dealer>();
    }

    public class Teritorry
    {
        public int TERITORRY_ID { get; set; }
        public string TERITORRY_NAME { get; set; }
        public int OUTLET_COUNT { get; set; }
        public List<Town> TOWNS { get; set; } = new List<Town>();
    }

    public class Area
    {
        public int AREA_ID { get; set; }
        public string AREA_NAME { get; set; }
        public int OUTLET_COUNT { get; set; }
        public List<Teritorry> TERITORIES { get; set; } = new List<Teritorry>();
    }

    public class NationWiseKpiRegion
    {
        public int REGION_ID { get; set; }
        public string REGION_NAME { get; set; }
        public int OUTLET_COUNT { get; set; }
        public List<Area> AREAS { get; set; } = new List<Area>();
    }


}