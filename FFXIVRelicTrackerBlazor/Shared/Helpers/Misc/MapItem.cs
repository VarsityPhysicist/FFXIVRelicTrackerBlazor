using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.Misc
{
    public class MapItem
    {
        public string DisplayName { get; set; }
        public MapType MapType { get; set; }
        public PointF PointF{ get; set; }
        public ArrMapNames ArrMapName { get; set; }
        public string LeveType { get; set; }
        public string LevePerson { get; set; }

        public double PointX => PointF.X/41*200;
        public double PointY => PointF.Y/41*200;
        public bool Hide { get; set; }

    }
    public enum MapType
    {
        Creature,
        FATE,
        Leve
    }
}
