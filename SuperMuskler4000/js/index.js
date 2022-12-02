console.log("Test")
const baseURL = "https://api.api-ninjas.com/v1/exercises"


const waifuURL = "https://api.waifu.im/search/?included_tags=maid"


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

        GetGifs() {
            console.log("Knap trykt på")
            axios.get(waifuURL)
            .then(response => {
                (this.info = response.data)
                console.log(this.info)
                this.src = this.info
                console.log(this.src)
                  //this.setImgSrc({Waifus: response.data.message})
            })
            console.log("GetGifs success")
        },
        
        

    }
}).mount("#app")