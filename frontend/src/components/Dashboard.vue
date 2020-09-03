<template>
  <div id="dashboard">
    <h1 class="h1">Love Pizza, Vote for Pizza</h1>
    <b-alert :show="error.length > 0" variant="danger">{{ error }}</b-alert>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-btn v-show="!loading" type="submit" variant="success" @click.prevent="addVote('mihail.gaberov@gmail.com', 1)">
      Like +
    </b-btn>
    <img src="../assets/pizza.png" alt="Love Pizza, Vote for Pizza"/>
    <b-btn v-show="!loading" type="submit" variant="danger">Dislike -</b-btn>
  </div>
</template>

<script>
import api from '@/PizzaVotesApiService';

export default {
  data() {
    return {
      loading: false,
      records: [],
      error: "",
    };
  },
  async created() {
    const userRecords = await this.getById('mihail.gaberov@gmail.com')
    console.log('user records', userRecords);
  },
  methods: {
    async getById(id) {
      this.loading = true

      try {
        // this.records = await api.getById(id)
        return await api.getById(id)
      } catch (error) {
        if (error.response.status === 401) {
          this.error = "Please login in order to be able to vote."
        } else {
          this.error = error.message;
        }
      } finally {
        this.loading = false
      }
    },
    async addVote(id, dir) {
      const data = {
        id,
        dir,
        dateTime: new Date(Date.now())
      };
      try {
        await api.create(data)
        // Fetch all records again to have latest data
        await this.getById(id)
      } catch (error) {
        if (error.response.status === 401) {
          this.error = "Please login in order to be able to vote."
        } else {
          this.error = error.message;
        }
      }
    }
  }
}
</script>

