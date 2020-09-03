<template>
  <div id="dashboard">
    <h1 class="h1">Love Pizza, Vote for Pizza</h1>
    <b-alert :show="error.length > 0" variant="danger">{{ error }}</b-alert>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <div class="main">
      <div class="positive">
        <b-badge v-if="userRecords" v-show="userRecords.value > 0" variant="success" class="count">{{ userRecords.value }}</b-badge>
        <b-btn v-show="!loading && isLogged" type="submit" variant="success"
               @click.prevent="addVote('mihail.gaberov@gmail.com', VOTES.UP)">
          Like +
        </b-btn>
      </div>
      <img src="../assets/pizza.png" alt="Love Pizza, Vote for Pizza"/>
      <div class="negative">
        <b-badge v-if="userRecords" v-show="userRecords.value <= 0" variant="danger" class="count">{{ userRecords.value }}</b-badge>
        <b-btn v-show="!loading && isLogged" type="submit" variant="danger"
               @click.prevent="addVote('mihail.gaberov@gmail.com', VOTES.DOWN)">Dislike -
        </b-btn>
      </div>
    </div>
  </div>
</template>

<style lang="scss">
.main {
  display: flex;
  align-items: center;
  justify-content: center;

  .count {
    margin: 1em;
  }
}

.positive {
  display: flex;
  flex-direction: column;
}

.negative {
  display: flex;
  flex-direction: column;
}
</style>

<script>
import api from '@/PizzaVotesApiService';

export default {
  data() {
    return {
      loading: false,
      userRecords: {},
      error: "",
      isLogged: false,
      VOTES: {
        UP: 'UP',
        DOWN: 'DOWN'
      }
    };
  },
  async created() {
    this.userRecords = await this.getById('mihail.gaberov@gmail.com')
  },
  methods: {
    async getById(id) {
      this.loading = true

      try {
        this.isLogged = true
        return await api.getById(id)
      } catch (error) {
        if (error && error.response && error.response.status === 401) {
          this.error = "Please login in order to be able to vote."
          this.isLogged = false
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

