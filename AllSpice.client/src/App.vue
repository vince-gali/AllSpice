<template>
  <header>
    <!-- <Navbar /> -->
  </header>
  <main>
    <router-view />
  </main>
   <footer class="bg-dark text-light">
    <div class="mb-5 sticky">
      <img data-bs-toggle="modal" data-bs-target="#addRecipe" class="addBtn sticky rounded container-fluid" src="./assets/img/add-recipe.png" alt="">
    </div>
  </footer>

  <Modal id="addRecipe">
    <CreateRecipeForm/>
  </Modal>

  <Modal id="activeRecipe">
    <ActiveRecipeCard/>
  </Modal>

</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
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
  height: 32px;
}

.sticky {
  position: -webkit-sticky; 
  position: sticky;
  top: 0;
}

.addBtn:hover{
  transition: .04s ease-in;
  transform: scale(1.1);
}
// .imgSticky{
//   position: sticky;
// }
</style>
