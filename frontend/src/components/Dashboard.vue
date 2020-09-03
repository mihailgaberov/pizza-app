<template>
  <div id="dashboard">
    <h1 class="h1">Love Pizza, Vote for Pizza</h1>
    <b-alert :show="error.length > 0" variant="danger">{{ error }}</b-alert>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-btn v-show="!loading" type="submit" variant="success" @click.prevent="addVote('mihail.gaberov@gmail.com', VOTES.UP)">
      Like +
    </b-btn>
    <img src="../assets/pizza.png" alt="Love Pizza, Vote for Pizza"/>
    <b-btn v-show="!loading" type="submit" variant="danger" @click.prevent="addVote('mihail.gaberov@gmail.com', VOTES.DOWN)">Dislike -</b-btn>
  </div>
</template>

<script>
import api from '@/PizzaVotesApiService';

export default {
  data() {
    return {
      loading: false,
      userRecords: {},
      error: "",
      VOTES: {
        UP: 'UP',
        DOWN: 'DOWN'
      }
    };
  },
  async created() {
    this.userRecords = await this.getById('mihail.gaberov@gmail.com')
    console.log('user records: ', this.userRecords.id);
  },
  methods: {
    async getById(id) {
      this.loading = true

      try {
        return await api.getById(id)
      } catch (error) {
        if (error && error.response && error.response.status === 401) {
          this.error = "Please login in order to be able to vote."
        } else {
          this.error = error.message;
        }
      } finally {
        this.loading = false
      }
    },
    async addVote(id, dir) {
      const value = dir === this.VOTES.UP ? 1 : -1
      const isUpdating = this.userRecords.id === 'mihail.gaberov@gmail.com'
      const data = {
        id,
        Value: isUpdating ? this.userRecords.value + value : value,
        dateTime: new Date(Date.now())
      }

      try {
        // If there is no any records for the logged in user yet - create, otherwise - update
        if (isUpdating) {
          await api.update('mihail.gaberov@gmail.com', data)
        } else {
          await api.create(data)
        }
        // Fetch all records again to have latest data
        this.userRecords = await this.getById(id)
      } catch (error) {
        if (error && error.response && error.response.status === 401) {
          this.error = "Please login in order to be able to vote."
        } else {
          this.error = error.message;
        }
      }
    }
  }
}
</script>

