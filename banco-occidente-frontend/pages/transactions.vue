<template>
  <div>
    <div class="card" v-if="!pending">
      <h5 class="card-header">Movimientos de la tarjeta de credito</h5>
      <div class="card-body">
        <table class="table">
          <thead>
            <tr>
              <th scope="col">Fecha</th>
              <th scope="col">Descripcion</th>
              <th scope="col">Monto</th>
              <th scope="col">Tipo</th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="transaction in transactions"
              :key="transaction.transactionId"
            >
              <td>{{ transaction.transactionDate }}</td>
              <td>{{ transaction.description }}</td>
              <td>{{ formattedCurrency(transaction.amount) }}</td>
              <td>
                <span
                  :class="{
                    'badge bg-success': transaction.transactionType === 'abono',
                    'badge bg-danger': transaction.transactionType === 'cargo',
                  }"
                >
                  {{ transaction.transactionType.toUpperCase() }}
                </span>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div v-else class="flex justify-center items-center h-screen">
      <div class="loader">Cargando informacion</div>
    </div>
  </div>
</template>

<script>
import { getTransactionByCreditCreditCard } from "../services/transactionService";
import { formattedCurrency } from "../utils/formattedCurrency";
export default {
  name: "CreditCardTransactions",
  data() {
    return {
      transactions: null,
      creditCard: "4111111111111111",
      pending: true,
      error: null,
    };
  },
  async mounted() {
    try {
      const today = new Date();
      const month = today.getMonth() + 1;
      const transactionsResponse = await getTransactionByCreditCreditCard(
        this.creditCard,
        month
      );
      this.transactions = transactionsResponse;
    } catch (err) {
      this.error = err;
    } finally {
      this.pending = false;
    }
  },
  methods: {
    formattedCurrency,
  },
};
</script>

<style></style>
