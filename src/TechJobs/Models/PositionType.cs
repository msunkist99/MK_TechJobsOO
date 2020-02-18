using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechJobs.Models
{
    public class PositionType : JobField
    {
        // No additional members yet. See JobField.cs
        private static int nextId = 0;

        public PositionType()
        {
            ID = nextId;
            nextId++;
        }
    }
}
