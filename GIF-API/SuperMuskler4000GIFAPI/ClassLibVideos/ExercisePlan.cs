using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibVideos
{
    public class ExercisePlan
    {

        public ExercisePlan() : this("kage")
        {

        }

        public ExercisePlan(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
