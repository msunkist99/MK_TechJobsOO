﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechJobs.Models
{
    public class CoreCompetency : JobField
    {
        // No additional members yet. See JobField.cs
        private static int nextId = 0;

        public CoreCompetency()
        {
            ID = nextId;
            nextId++;
        }
    }
}
