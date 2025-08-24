const { createApp } = Vue

createApp({
    data() {
        return {
            query: {
                title: '',
                dueDate: '',
                isCompleted: ''
            },
            todos: [],
            showSinner: true
        }
    },
    methods: {
        fetchData() {
            this.showSinner = true
            setTimeout(() => {
                axios({
                    method: 'get',
                    url: '/todo/search',
                    params: {
                        'title': this.query.title,
                        'dueDate': this.query.dueDate,
                        'isCompleted': this.query.isCompleted
                    }
                }).then((res) => {
                    this.todos = res.data
                    this.showSinner = false
                })
            }, 500)
        }
    },
    mounted() {
        this.fetchData()
    }
}).mount('#app')