import { useApi } from '@/utils/api'



export const getTransactionByCreditCreditCard = async (creditCard, mont) => {
  const { fetchData } = useApi()
  return await fetchData(`/Transactions/GetTransactionsByCreditCard?creditCardNumber=${creditCard}&month=${mont}`)
}

export const saveTransaction = async (transaction) => {
  const { fetchData } = useApi()
  return await fetchData(`/Transactions/CreateTransaction`, {
    method: 'POST',
    body: JSON.stringify(transaction)
  })
}