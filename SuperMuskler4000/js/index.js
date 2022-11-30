console.log("Test")
const baseURL = "https://api.api-ninjas.com/v1/exercises"



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
            search_muscle: "Choose your Muscle Group"
            
            
        }
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
        }
    }
}).mount("#app")