using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.Logical_And_Maintenable.Design_Amazon_Locker
{
    public class Package
    {
        public string PackageId { get; set;  } 
        public Size PackageSize { get; set; }

        public Package(Size size)
        { 
            this.PackageSize = size;
            this.PackageId = Guid.NewGuid().ToString();
        }
    }
}
