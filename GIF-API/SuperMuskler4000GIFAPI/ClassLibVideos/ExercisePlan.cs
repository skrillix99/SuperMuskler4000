using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibVideos
{   
    /// <summary>
    /// This is the model class for an ExercisePlan object
    /// </summary>
    public class ExercisePlan
    {
        /// <summary>
        /// This is the default constructor for the ExercisePlan class
        /// </summary>
        public ExercisePlan() : this("kage", "Cheesecake", "belly", "Spatel", "svær", "Lav den over 5 timer")
        {

        }

        /// <summary>
        /// This constructer takes six parameters as arguments to construct an ExercisePlan object 
        /// </summary>
        /// <param name="name">Name of the exercise. Type string</param>
        /// <param name="type">The exercise type. Type string</param>
        /// <param name="muscleType">The muscle type of the exercise. Type string</param>
        /// <param name="equipment">The equipment used to do the exercise. Type string</param>
        /// <param name="difficulty">The difficulty of the exercise. Type string</param>
        /// <param name="instructions">The exercise instructions. Type string</param>
        public ExercisePlan(string name, string type, string muscleType, string equipment, string difficulty, string instructions)
        {
            Name = name;
            Type = type;
            MuscleType = muscleType;
            Equipment = equipment;
            Difficulty = difficulty;
            Instructions = instructions;
        }

        /// <summary>
        /// The Name of the exercise
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The exercise type.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The muscle type of the exercise.
        /// </summary>
        public string MuscleType { get; set; }
        /// <summary>
        /// The equipment used to do the exercise.
        /// </summary>
        public string Equipment { get; set; }
        /// <summary>
        /// The difficulty of the exercise.
        /// </summary>
        public string Difficulty { get; set; }
        /// <summary>
        /// The exercise instructions.
        /// </summary>
        public string Instructions { get; set; }
    }
}
