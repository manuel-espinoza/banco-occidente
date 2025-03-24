export const useApi = () => {
    const config = useRuntimeConfig()
    console.log("API Base URL:", config.public.apiBaseUrl);
    const fetchData = async (endpoint, options = {}) => {
      try {
        const response = await $fetch(`${config.public.apiBaseUrl}${endpoint}`, options)
        return response
      } catch (error) {
        console.error('Error en la API:', error)
        throw error
      }
    }
  
    return { fetchData }
  }