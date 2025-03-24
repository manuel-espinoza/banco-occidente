import { useApi } from '@/utils/api'

export const getCreditCardStatementHeader = async (customerId) => {
  const { fetchData } = useApi()
  return await fetchData(`/CreditCardStatement/GetHeaderInformation/${customerId}`)
}

export const getCreditCardStatementPurchases = async (customerId, month) => {
  const { fetchData } = useApi()
  return await fetchData(`/CreditCardStatement/GetPurchasesInformation/${customerId}/${month}`)
}