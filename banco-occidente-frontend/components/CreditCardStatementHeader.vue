<template>
  <div>
    <div class="card">
      <h5 class="card-header">Estado de cuenta</h5>
      <div class="card-body">
        <div class="row mb-3">
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Cliente:</span>
              {{ headerInfo?.customerName }}
            </p>
          </div>
          <div class="col-md-6">
            <p class="card-text">
              <span class="fw-bold">Tarjeta:</span> {{ formattedCreditCard }}
            </p>
          </div>
        </div>
        <div class="row mb-3">
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Limite de credito:</span>
              {{ formattedCurrency(headerInfo?.creditLimit) }}
            </p>
          </div>
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Saldo actual:</span>
              {{ formattedCurrency(headerInfo?.currentBalance) }}
            </p>
          </div>
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Saldo disponible:</span>
              {{ formattedCurrency(headerInfo?.availableCredit) }}
            </p>
          </div>
        </div>
        <div class="row mb-3">
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Total compras:</span>
              {{ formattedCurrency(headerInfo?.totalPuchasesAmount) }}
            </p>
          </div>
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Interes bonificable:</span>
              {{ formattedCurrency(headerInfo?.waivableInterestAmount) }}
            </p>
          </div>
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Pago minimo:</span>
              {{ formattedCurrency(headerInfo?.minimumPaymentAmount) }}
            </p>
          </div>
          <div class="col-md-3">
            <p class="card-text">
              <span class="fw-bold">Total a pagar:</span>
              {{ formattedCurrency(headerInfo?.lumpSumPaymentAmount) }}
            </p>
          </div>
        </div>
      </div>
      <div class="card-footer">
        <section class="credit-card-statement-options d-flex justify-content-end">
          <button class="btn btn-outline-primary me-2" @click="$emit('openModal', 'cargo')">Reportar Compra</button>
          <button class="btn btn-primary" @click="$emit('openModal', 'abono')">Pagar/Abonar tarjeta</button>
        </section>
      </div>
    </div>
  </div>
</template>

<script>
import { formattedCurrency } from "../utils/formattedCurrency";
export default {
  name: "CreditCardStatementHeader",
  props: {
    headerInfo: {
      type: Object
    },
  },
  computed: {
    formattedCreditCard() {
      if (!this.headerInfo?.creditCard) return "";
      return this.headerInfo.creditCard.replace(/\d{4}(?=.)/g, "$&-");
    },
  },
  methods: {
    formattedCurrency,
  },
};
</script>

<style></style>
