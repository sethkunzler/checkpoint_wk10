<template>
  <nav class="navbar navbar-expand-sm px-3 justify-content-center">
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto text-center">
        <li class="bg-dark rounded-top m-2">
          <router-link :to="{ name: 'Home' }" class="btn text-success lighten-30 selectable text-uppercase">
            Home
          </router-link>
        </li>
        <li class="bg-dark rounded-top m-2">
          <router-link :to="{ name: 'My Recipes' }" class="btn text-success lighten-30 selectable text-uppercase">
            My Recipes
          </router-link>
        </li>
        <li class="bg-dark rounded-top m-2">
          <router-link :to="{ name: 'Favorites' }" class="btn text-success lighten-30 selectable text-uppercase">
            Favorites
          </router-link>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <div class="text-center">
        <button class="btn text-light" @click="toggleTheme">
          <i class="mdi fs-3" :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i>
        </button>
      </div>
      <Login class="text-center" />
    </div>
  </nav>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
.navbar {
  background-image: url("https://images.unsplash.com/photo-1496701213998-7fd1bc5528b5?q=80&w=3870&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
  background-size: 100% 100%;
  background-position-y: bottom 50px;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-color: rgba(0, 0, 0, 0.40);
  background-blend-mode: color-burn;
  padding: 12px;
}

a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
