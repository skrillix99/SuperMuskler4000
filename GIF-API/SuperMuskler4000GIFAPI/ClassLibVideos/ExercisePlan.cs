using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibVideos
{
    public class ExercisePlan
    {

        public ExercisePlan() : this("kage", "Cheesecake", "belly", "Spatel", "svær", "Lav den over 5 timer")
        {

        }

        public ExercisePlan(string name, string type, string muscleType, string equipment, string difficulty, string instructions)
        {
            Name = name;
            Type = type;
            MuscleType = muscleType;
            Equipment = equipment;
            Difficulty = difficulty;
            Instructions = instructions;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string MuscleType { get; set; }

        public string Equipment { get; set; }

        public string Difficulty { get; set; }

        public string Instructions { get; set; }
    }
}
