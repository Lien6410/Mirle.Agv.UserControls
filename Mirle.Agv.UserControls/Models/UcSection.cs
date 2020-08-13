using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Agv.UserControls
{   
    public class UcSection
    {      
        public string Id { get; set; } = "";
        public UcAddress HeadAddress { get; set; } = new UcAddress();
        public UcAddress TailAddress { get; set; } = new UcAddress();       
        public EnumUcSectionType SectionType { get; set; } = EnumUcSectionType.None;
    }

}
