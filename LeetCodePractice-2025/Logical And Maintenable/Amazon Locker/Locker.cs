using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.Logical_And_Maintenable.Design_Amazon_Locker
{
    public class Locker
    {
        public string LockerId { get; set; }
        public Size LockerSize { get; set; }
        public Package PackageInsideLocker { get; set; }

        public Locker(Size size)
        {
            this.LockerSize = size;
            this.LockerId = Guid.NewGuid().ToString();
        }

        public void AssignPackage(Package package) =>
            PackageInsideLocker = package;

        public Package EmptyLocker()
        {
            Package p = PackageInsideLocker;
            PackageInsideLocker = null;
            return p;
        } 
    }
}
