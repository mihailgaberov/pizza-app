<template>
  <div id="dashboard">
    <h1 class="h1">Love Pizza, Vote for Pizza</h1>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-btn type="submit" variant="success" @click.prevent="addVote('mihail.gaberov@gmail.com', 1)">Like +</b-btn>
    <img src="../assets/pizza.png" alt="Love Pizza, Vote for Pizza" />
    <b-btn type="submit" variant="danger">Dislike -</b-btn>
  </div>
</template>

<script>
import api from '@/PizzaVotesApiService';

export default {
  data() {
    return {
      loading: false,
      records: [],
    };
  },
  async created() {
    this.getById('mihail.gaberov@gmail.com')
    console.log('>>> records', this.records);
  },
  methods: {
    async getById(id) {
      this.loading = true

      try {
        this.records = await api.getById(id)
      } finally {
        this.loading = false
      }
    },
    async addVote(id, dir) {
      console.log('>>> addVote called...', id);
      const data = {
        dir,
        dateTime: new Date(Date.now())
      };
        await api.update(id, data)

        // Fetch all records again to have latest data
        await this.getById(id)
    }
  }
}
</script>

