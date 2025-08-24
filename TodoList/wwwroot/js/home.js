const { createApp } = Vue

createApp({
    data() {
        return {
            todos: [],
            showSinner: true
        }
    },
    mounted() {
        setTimeout(() => {
            axios({
                method: 'get',
                url: '/todo/today'
            }).then((res) => {
                this.todos = res.data
                this.showSinner = false
            })
        }, 500)
    }
}).mount('#app')