console.log("Test")
const baseURL = "https://api.api-ninjas.com/v1/exercises"


const gifURL = "https://supermuskler4000.azurewebsites.net/api/Videos/"


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
            statuscode: null,
            search_muscle: "Choose your Muscle Group",
            exerciseToShow: -1,
            
            info: null,
            Waifus: [],
            src: null
        }
    },

    mount: {

        
    },

    computed: {

    },

    methods: {
        GetAllExercises(search_muscle) {

            uri = baseURL + "?muscle=" + search_muscle
            axios.get(uri, {headers: {'X-Api-Key': 'BrKZG9qvMdQ2c8s1vUce8Q==O3S6L9vlhJ2wNmrJ'}})
            .then(response => {
                
                this.exercise_list = response.data
                
            })
        },

        GetGifs(search_muscle) {
            console.log("GetGifs trykket")
            console.log(search_muscle)
            uri = gifURL + search_muscle
            console.log(uri)
            axios.get(uri)
            .then(response => {
                
                this.video_list = response.data
                console.log(video_list)
                
            })
        },
        
        

    }
}).mount("#app")