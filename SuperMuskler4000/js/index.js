console.log("Test")
const baseURL = "https://api.api-ninjas.com/v1/exercises"


const gifURL = "https://supermuskler4000.azurewebsites.net/api/Videos/"
const ExerciseURL = "https://supermuskler4000.azurewebsites.net/api/ExercisePlans/"



Vue.createApp({
    data() {
        return {
            name: "",
            type: "",
            muscle: "",
            equipment: "",
            difficulty: "",
            instructions: "",
            exercise_list: [],
            yourRecordings: [],
            YourExerciseList: [],
            statuscode: null,
            search_muscle: "Choose your Muscle Group",
            exerciseToShow: -1,
        }
    },

    mount: {

        
    },

    computed: {

    },

    methods: {
        //accesses our 3rd part api through api key to pull different exercise types down for the user to sort through
        GetAllExercises(search_muscle) {

            uri = baseURL + "?muscle=" + search_muscle
            axios.get(uri, {headers: {'X-Api-Key': 'BrKZG9qvMdQ2c8s1vUce8Q==O3S6L9vlhJ2wNmrJ'}})
            .then(response => {
                
                this.exercise_list = response.data
                
            })
        },
        //gets videos from our database to show in our profile.html
        GetVideos() {
            uri = gifURL
            axios.get(uri)
            .then(response => {
    
                this.yourRecordings = response.data
            })
        },
        //Posts exercises with the given values name, type, muscle, equipment, difficulty, instructions. sends the data into our database for further use in our getall
        PostExercises(name, type, muscleType, equipment, difficulty, instructions) {
            uri =ExerciseURL
            axios({
                method: 'post',
                url: uri,
                data: {
                    Name: name,
                    Type: type,
                    MuscleType: muscleType,
                    Equipment: equipment,
                    Difficulty: difficulty,
                    Instructions: instructions
                }

            })
        },
        // Makes a call to our api and gets all exercises in the exerciseplan table
        GetPersonalList() {
            uri = ExerciseURL
            axios.get(uri) 
            .then(response => {
                console.log("før data")
                this.YourExerciseList = response.data
                console.log(this.YourExerciseList)
            })
        },



    }
}).mount("#app")