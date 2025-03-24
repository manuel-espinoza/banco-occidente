<template>
  <div>
    <section v-if="!pending">
      <CreditCardStatementHeader
        :header-info="headerInfo"
        @openModal="openModal"
      />
      <br class="my-2" />
      <CreditCardStatementPurchases :creditCardpurchases="purchases" />
  
      <TransactionsModal
        :is-open="showModal"
        :transaction-type="modalType"
        @close="showModal = false"
        @createTransaction="createTransacion"
      />
    </section>
    <section v-else>
      <div class="flex justify-center items-center h-screen">
        <div class="loader">Cargando informacion</div>
      </div>
    </section>
  </div>
</template>

<script>
import {
  getCreditCardStatementHeader,
  getCreditCardStatementPurchases,
} from "../services/creditCardStatementService";
import { saveTransaction } from "../services/transactionService";

export default {
  data() {
    return {
      headerInfo: null,
      pending: true,
      error: null,
      customerId: 1,
      purchases: null,
      showModal: false,
      modalType: "",
    };
  },
  async mounted() {
    await this.getCreditCardStatementInfo();
  },
  methods: {
    async getCreditCardStatementInfo() {
      try {
        const today = new Date();
        const month = today.getMonth() + 1;
        const [headerInfoResponse, purchasesResponse] = await Promise.all([
          getCreditCardStatementHeader(this.customerId),
          getCreditCardStatementPurchases(this.customerId, month),
        ]);
        this.headerInfo = headerInfoResponse;
        this.purchases = purchasesResponse;
      } catch (err) {
        this.error = err;
        alert("An error occurred while fetching the data");
      } finally {
        this.pending = false;
      }
    },
    openModal(type) {
      this.modalType = type;
      this.showModal = true;
    },
    async createTransacion(transaction) {
      try {
        const today = new Date();
        let savedTransaction = transaction;
        savedTransaction.TransactionDate = today;
        savedTransaction.creditCardNumber = this.headerInfo.creditCard;

        await saveTransaction(savedTransaction);
        this.getCreditCardStatementInfo();
      } catch (error) {
        console.error(error);
        alert("An error occurred while saving the transaction");
      }
      finally {
        
        this.showModal = false;
      }
    },
  },
};
</script>
