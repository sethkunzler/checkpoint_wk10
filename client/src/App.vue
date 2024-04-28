<template>
  <header class="sticky-top">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
   <footer class="bg-dark text-light">
    <p class="mb-0">
      Made with 💖 by <a href="https://www.linkedin.com/in/seth-kunzler/" target="_blank" class="text-success">Seth Kunzler</a> @ <a href="https://boisecodeworks.com/" target="_blank"><span class="text-primary text-underlined-primary"><b>Boise CodeWorks</b></span></a> 
      <br><a class="mdi mdi-github selectable text-success fs-3 mx-2 px-2 rounded" href="https://github.com/sethkunzler" target="_blank" title="GitHub Profile"></a>
      <a class="mdi mdi-linkedin selectable text-success fs-3 mx-2 px-2 rounded" href="https://www.linkedin.com/in/seth-kunzler/" target="_blank" title="Linked In Profile"></a>
      <!-- TODO add my resume -->
      <a class="mdi mdi-book selectable text-success fs-3 mx-2 px-2 rounded disabled" href="https://sethkunzler.github.io/Resume/" target="_blank" title="Resume"></a>
      <a class="mdi mdi-map-marker selectable text-primary fs-3 mx-2 px-2 rounded disabled" href="https://maps.app.goo.gl/iDJ5xRSpiYcWt3Mz7" target="_blank" title="Boise Codeworks' Location"></a>
      <a class="mdi mdi-facebook selectable text-primary fs-3 mx-2 px-2 rounded disabled" href="https://www.facebook.com/boisecodeworks/" target="_blank" title="Boise Codeworks' Facebook"></a>
      <a class="mdi mdi-web selectable text-primary fs-3 mx-2 px-2 rounded disabled" href="https://www.facebook.com/boisecodeworks/" target="_blank" title="Boise Codeworks' Home Page"></a>
    </p>
  </footer>
  <CreateRecipeModal />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import CreateRecipeModal from './components/CreateRecipeModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, CreateRecipeModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 96px;
}
</style>
