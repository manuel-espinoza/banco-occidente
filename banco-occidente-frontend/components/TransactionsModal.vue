<template>
  <div v-if="isOpen" class="modal fade show" data-bs-backdrop="static" style="display: block;" tabindex="-1" aria-modal="true" role="dialog">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{ modalTitle }}</h5>
          <button type="button" class="btn-close" @click="closeModal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="submitForm">
            <div class="mb-3">
              <label class="form-label">Monto:</label>
              <input v-model="amount" type="number" class="form-control" required />
            </div>
            <div class="mb-3">
              <label class="form-label">Descripción:</label>
              <textarea v-model="description" class="form-control" required></textarea>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" @click="closeModal">Cancelar</button>
          <button type="submit" class="btn btn-primary" @click="submitForm">Guardar</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    isOpen: Boolean,
    transactionType: String,
  },
  data() {
    return {
      amount: null,
      description: "",
    };
  },
  computed: {
    modalTitle() {
      return this.transactionType === "cargo" ? "Reportar Compra" : "Pagar Tarjeta";
    },
  },
  methods: {
    cleanForm() {
      this.amount = null;
      this.description = "";
    },
    closeModal() {
      this.cleanForm();
      this.$emit("close");
    },
    async submitForm() {
      const transaction = {
        amount: this.amount,
        description: this.description,
        transactionType: this.transactionType,
      }
      this.$emit("createTransaction", transaction);
      this.cleanForm();
    },

    
  },
};
</script>

