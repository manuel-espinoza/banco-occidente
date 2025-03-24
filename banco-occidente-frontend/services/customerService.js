

export const GetCustomer = async (documentId) => {
  const {fetchData} = useApi()
  return await fetchData(`/Customers/GetByDocument?documentId=${documentId}`)
}