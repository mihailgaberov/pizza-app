import { shallowMount } from '@vue/test-utils'
import Username from '@/components/Username.vue'

describe('Username.vue', () => {
  it('renders props.username when passed', () => {
    const username = 'mihail.gaberov@gmail.com'
    const wrapper = shallowMount(Username, {
      propsData: { username }
    })
    expect(wrapper.text()).toMatch(username)
  })
})
