using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwReflectionAtribute
{
    /// <summary>
    /// если урон меньше min - то здоровье не отнимается;  если урон больше max - то здровье = 0
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    class LimitOfDemageAttribute : Attribute
    {
        public int MinValue { get; }
        public int MAxValue { get; }

        public LimitOfDemageAttribute(int min, int max)
        {
            this.MinValue = min;
            this.MAxValue = max;
        }


    }
}
