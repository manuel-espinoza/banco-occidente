<template>
  <div class="d-flex">
    <nav class="sidebar bg-ligth p-3">
      <h5 class="text-center border-bottom">Banco Occidente</h5>
      <ul class="nav flex-column">
        <li class="nav-item">
          <NuxtLink class="nav-link" to="/">Inicio</NuxtLink>
        </li>
        <li class="nav-item">
          <NuxtLink class="nav-link" to="/transactions">Transacciones</NuxtLink>
        </li>
        <li class="nav-item">
          <NuxtLink class="nav-link" to="/about">Acerca de</NuxtLink>
        </li>
      </ul>
    </nav>

    <div class="content flex-grow-1">
      <nav class="navbar navbar-light bg-secondary px-4 pb-2">
        <span class="navbar-text me-3 text-light">
          {{ userEmail }}
        </span>
        <button class="btn btn-danger" @click="logout">Cerrar sesión</button>
      </nav>

      <main class="p-4">
        <slot />
      </main>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userEmail: "usuario@correo.com",
    };
  },
  methods: {
    logout() {
      console.log("Cerrar sesión");
    },
  },
};
</script>

<style scoped>
.sidebar {
  width: 250px;
  min-height: 100vh;
  border-right: 1px solid #ccc;
}

.content {
  display: flex;
  flex-direction: column;
  width: 100%;
}

.navbar {
  display: flex;
  justify-content: end;
  align-items: center;
}
.router-link-active, .router-link-exact-active {
    font-weight: bold;
    color: black;
}
</style>
