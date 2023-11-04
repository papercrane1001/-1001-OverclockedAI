using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;
using RimWorld;

namespace _1001_OverclockedAI
{
    public class CompProperties_AdjustableFacility : CompProperties_Facility
    {
        public int step = 1;
        private float stepX { get { return 40 + 2 * step; } }
        public float powerReq()
        {
            return (float)Math.Exp(.09 * stepX);
        }
        public float efficiency()
        {
            return (float)(25 * Math.Pow(1.1, step - 1));
        }

        public float energyPerSecond
        {
            get
            {
                return step * 12f;
            }
        }


        public CompProperties_AdjustableFacility()
        {
            this.compClass = typeof(CompFacility);
            this.maxDistance = 16f;
            //if(this.statOffsets.Contains())
            //if(this.statOffsets.Where(x => x.stat == StatDefOf.WorkTableWorkSpeedFactor)
            StatModifier s = new StatModifier();
            s.stat = StatDefOf.WorkTableWorkSpeedFactor;
            this.statOffsets.Add(s);
        }

        public void AdjustWorkSpeedFactor(float newVal)
        {
            StatModifier s = new StatModifier();
            s.stat = StatDefOf.WorkTableWorkSpeedFactor;
            var ls = statOffsets.Where(x => x.stat == s.stat);

            if(ls.Count() > 0)
            {
                statOffsets.Remove(ls.FirstOrDefault());
                ls.FirstOrDefault().value = newVal;
                statOffsets.Add(ls.FirstOrDefault());
            }            
            
        }
    }

    //public class CompProperties_
}
