import { render } from '@testing-library/vue'
import VotesChart from "@/components/VotesChart";

describe('Dashboard.vue', () => {
    test('container contains canvas that renders a Bar chart', () => {
        const { container } = render(VotesChart)
        expect(container.lastChild.lastChild.tagName).toBe('CANVAS')
        expect(container.lastChild.lastChild.attributes[0].value).toBe('bar-chart')
    })
})
