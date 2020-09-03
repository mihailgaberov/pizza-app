import Vue from 'vue'
import axios from 'axios'

const client = axios.create({
    baseURL: 'https://localhost:5001/api/pizzavotes',
    json: true
})

export default {
    async execute(method, resource, data) {
        const accessToken = await Vue.prototype.$auth.getAccessToken()
        return client({
            method,
            url: resource,
            data,
            headers: {
                Authorization: `Bearer ${accessToken}`
            }
        }).then(req => {
            return req.data
        })
    },
    getAll() {
        return this.execute('get', '/')
    },
    getById(id) {
        return this.execute('get', `/${id}`)
    },
    update(id, data) {
        console.log('from the service:', id, data);
        return this.execute('put', `/${id}`, data)
    },
}
