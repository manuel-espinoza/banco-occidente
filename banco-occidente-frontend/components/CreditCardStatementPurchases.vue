<template>
  <div>
    <div class="card">
      <h5 class="card-header">Compras</h5>
      <div class="card-body">
        <table class="table">
          <thead>
            <tr>
              <th scope="col">Fecha</th>
              <th scope="col">Descripcion</th>
              <th scope="col">Monto</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(purchase, index) in creditCardpurchases" :key="index">
              <td>{{ purchase.date }}</td>
              <td>{{ purchase.description }}</td>
              <td>{{ formattedCurrency(purchase.amount) }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import { formattedCurrency } from "../utils/formattedCurrency";
export default {
  name: "CreditCardStatementPurchases",
  props: {
    creditCardpurchases: {
      type: Array
    },
  },
  methods: {
    formattedCurrency
  }
};
</script>

<style></style>
