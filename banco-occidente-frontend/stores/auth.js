import { defineStore } from 'pinia'
import {GetCustomer} from '../services/customerService'

export const useAuthStore = defineStore( 'auth', {
  state: () => ({
    user: null,
   }),
  actions: {
    async login() {
      const user = await GetCustomer('1234567890')
      this.user = user
    },
  }
})
