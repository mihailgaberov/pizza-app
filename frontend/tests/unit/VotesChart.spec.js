import { render } from '@testing-library/vue'
import VotesChart from "@/components/VotesChart";

describe('Dashboard.vue', () => {
    test('container contains canvas', () => {
        const { container } = render(VotesChart)
        expect(container.lastChild.lastChild.tagName).toBe('CANVAS')
    })
})
