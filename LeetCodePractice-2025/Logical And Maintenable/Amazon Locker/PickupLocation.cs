using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.Logical_And_Maintenable.Design_Amazon_Locker
{
    public enum Size
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }

    public class PickupLocation
    {
        private Dictionary<Size, Queue<Locker>> availableLockers { get; set; }
        private Dictionary<string, Locker> packageLoc { get; set; }

        public PickupLocation(Dictionary<Size, int> lockerSizes)
        {
            availableLockers = new Dictionary<Size, Queue<Locker>>();
            packageLoc = new Dictionary<string, Locker>();

            foreach (var (key, value) in lockerSizes)
            {
                var lockerQ = new Queue<Locker>();
                for (int i = 0; i < value; i++)
                    lockerQ.Enqueue(new Locker(key));
                
                availableLockers.Add(key, lockerQ);
            }
        }

        public Locker AssignPackage(Package package)
        {
            foreach (var (size,locker) in availableLockers)
            {
                if (size < package.PackageSize)
                    continue;

                var assignedLocker = AssignLocker(package, size);

                if (assignedLocker != null)
                    return assignedLocker;
            }

            return null;
        }

        public Locker AssignLocker(Package package, Size size)
        {
            if (this.availableLockers[size].Count() == 0)
                return null;

            var lockerToAssign = this.availableLockers[size].Dequeue();
            lockerToAssign.AssignPackage(package);
            packageLoc[package.PackageId] = lockerToAssign;

            return lockerToAssign;            
        }

        public Package GetPackage(string packageId)
        {
            if (!packageLoc.ContainsKey(packageId)) return null;

            var locker = packageLoc[packageId];
            var package = locker.EmptyLocker();
            availableLockers[locker.LockerSize].Enqueue(locker);
            return package;
        }
    }
}
