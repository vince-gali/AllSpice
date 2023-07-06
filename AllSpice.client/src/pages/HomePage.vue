<template>

<section class="row">
  <div class="d-flex flex-column justify-content-center">
    <img class="container-fluid" src="../assets/img/spice-background.png" alt="">
    <!-- <div> -->
    <h4 class="text-white text-center"> All Spice</h4>
    <!-- </div> -->
  </div>
</section>


<section class="row">
  <div>
    <div class=" d-flex justify-content-around rounded">
        <button @click="getRecipes()" >Home</button>
      <button @click="getMyRecipes()" >My Recipes</button>
      <button @click="getFavorites()" >Favorites</button>
    </div>
  </div>
</section>

<section class="row">
  <div>
    <!-- {{ recipes }} -->
    <RecipeCard/>
  </div>
</section>

  <!-- <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 bg-white rounded elevation-3">
      <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo"
        class="rounded-circle">
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center">
        Vue 3 Starter
      </h1>
    </div>
  </div> -->

  

  dehllo
</template>

<script>
import { computed, onMounted, popScopeId } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';

export default {
  setup() {
    
    async function getRecipes(){
      try{
        logger.log('getting recipes pt 1')
        await recipesService.getRecipes()
        // logger.log('is it working')
      } catch (error){
        Pop.error(error.message)
        logger.log(error)
      }
    }

    async function getMyRecipes(){
      try {
        logger.log('getting my recipes pt 1')
        await recipesService.getMyRecipes()
      } catch (error) {
        Pop.error(error.message)
        logger.log(error)
      }
    }

    onMounted(()=>{
      getRecipes()
    })

    return {

      recipes: computed(()=>AppState.recipes),
      myRecipes: computed(()=>AppState.myRecipes)
    }
  }
}
</script>

<style scoped lang="scss">
// @import "./assets/";
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }

  .header-img{
    background-image: url("../assets/img/spice-background.png");

  }

  .container {
  position: relative;
  text-align: center;
  color: white;
}

.centered {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
}
</style>
