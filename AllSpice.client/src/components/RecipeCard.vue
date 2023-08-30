<template>

<!-- <div  class="card text-bg-dark recipe-card">
    <img  :src=" recipeProp.img " class="card-img img-fluid" alt="...">

    <div class=" card-img-overlay text-bg text-white">
      <h5 style=" background-color: rgba(53, 53, 53, 0.626);" class=" p-1 w-50 rounded card-title ">{{ recipeProp.category }}</h5>
      <i @click="addFavorite(recipeProp.id)" class="mdi mdi-heart-outline"></i>
      <div  class=" pt-5">
        <p @click="setActiveRecipe(recipeProp.id)"  style=" background-color: rgba(53, 53, 53, 0.626);" class=" w-50 p-1 border border-black rounded card-text text-borders">{{ recipeProp.title }}</p>
        <p  style=" background-color: rgba(53, 53, 53, 0.626);" class=" w-50 p-1 border border-black rounded card-text">Recipe Description</p>
      </div>
    </div>
  </div> -->


<!-- //ANCHOR - Recipe card mach 2 (below) -->
<!-- <div class="container-fluid">
  <img class="img-container img-fluid elevation-5 rounded" :src="recipeProp.img" alt="">
  <div class="overlay-info">
    <h5 @click="setActiveRecipe(recipeProp.id)"><em>{{ recipeProp.title }}</em></h5>
    <p >{{ recipeProp.category }}</p>
    <p style="overflow: hidden;" >{{ recipeProp.description }}</p>
  </div>
</div> -->


<!-- //ANCHOR - Recipe card mach 3 (below) -->

<div class="col-md-3 col-10 p-2" v-if="recipeProp">
  <div class="card elevation-5 ">
    <img class="rounded" :src="recipeProp.img" alt="">
    <div class="recipeInfo">
      <h3  @click="setActiveRecipe(recipeProp.id)" class="textBg">{{ recipeProp.title }}</h3>
    </div>
    <div class="recipeCat">
      <p class="textBg"><em>{{ recipeProp.category }}</em></p>
    </div>
  </div>
</div>





</template>


<script>
import { Modal } from 'bootstrap';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import { favoritesService } from '../services/FavoritesService.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { AppState } from '../AppState.js';
import { computed } from 'vue';
import { useRoute } from 'vue-router';
export default {
    // components: {ActiveRecipeCard},
    props: {
        recipeProp: {type: Recipe, required:true}
    },
    setup(){

      const route = useRoute()

      
      

        return {

          favorites: computed (()=> AppState.favorites),
          
          async setActiveRecipe(recipeId){
            try {
              await recipesService.setActiveRecipeById(recipeId)
              Modal.getOrCreateInstance('#activeRecipe').show()
            } catch (error) {
              Pop.error(error)
            }
          },

          async addFavorite(recipeId){
            try {
              // const recipeId = route.params.id
              await favoritesService.addFavorite(recipeId)
            } catch (error) {
              logger.log(error)
              Pop.error(error.message, 'error')
            }
          }

        }
    }
}
</script>


<style lang="scss" scoped>

.recipe-card{
width: 100%;
height: 35dvh;
object-fit: cover;
}


.overlay-info {
    position: absolute;
    // top: 15%;
    // left: 85%;
    transform: translate(0%, -100%);
    // z-index: 1;
    padding: 10px;
    background-color: rgba(65, 59, 59, 0.696);
    color: white;
    border-radius: 5px;
    overflow: hidden;
    max-width: 275px;
    width: 250px;
    
    // border-radius: 5px;
  }
  .img-container {
    position: relative;
    display: inline-block;
  }

  .recipeInfo{
    position: absolute;
    top: 10%;
    left: 40%;
    transform: translate(-50%,-0%);
    
}

  .recipeCat{
    position: absolute;
    top: 75%;
    left: 20%;
    transform: translate(-50%,-0%);
    
}

.textBg{
  color: white;
  // background-color: black;
  border: 2px solid rgba(0, 0, 0, 0.185);
  border-radius: 5px;
  background-color: rgba(0, 0, 0, 0.553);
  padding: .5rem;
}

</style>