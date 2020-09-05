<script>
import { Bar } from 'vue-chartjs'

export default {
  extends: Bar,
  props: { data: Array },

  watch: {
    data: async function(newVal) {
      // TODO: sort the array to contain only top 10 users with the highest appreciation
      this.labels = newVal.map(user => user.id);
      this.values = newVal.map(user => user.value)

      this.renderChart({
        labels: this.labels,
        datasets: [
          {
            label: 'Pizza Lovers',
            backgroundColor: '#f87979',
            data: this.values
          }
        ]
      })

    }
  }
}
</script>
