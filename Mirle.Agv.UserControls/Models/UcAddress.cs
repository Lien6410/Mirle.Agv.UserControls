using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Agv.UserControls
{
    public class UcAddress
    {
        public string Id { get; set; } = "";
        public UcPosition Position { get; set; } = new UcPosition();
        public bool IsWorkStation { get; set; } = false;
        public bool IsCharger { get; set; } = false;
        public bool IsSegmentPoint { get; set; } = true;
    }

}

