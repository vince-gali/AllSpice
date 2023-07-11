<template>

<div  @click="setActiveRecipe(recipeProp.id)" class="card text-bg-dark recipe-card">
    <img  :src=" recipeProp.img " class="card-img" alt="...">

    <div class=" card-img-overlay text-bg text-white">
      <h5 style=" background-color: rgba(53, 53, 53, 0.626);" class=" p-1 w-50 rounded card-title ">{{ recipeProp.category }}</h5>
      <div  class=" pt-5">
        <p  style=" background-color: rgba(53, 53, 53, 0.626);" class=" w-50 p-1 border border-black rounded card-text text-borders">{{ recipeProp.title }}</p>
        <p  style=" background-color: rgba(53, 53, 53, 0.626);" class=" w-50 p-1 border border-black rounded card-text">Recipe Description</p>
      </div>
    </div>

  </div>

<!-- <div>
  <img :src="recipeProp.img" alt="">

  <div class="card-img-overlay">
    <h5>{{ recipeProp.category }}</h5>
  </div>
</div> -->



</template>


<script>
import { Modal } from 'bootstrap';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
export default {
    // components: {ActiveRecipeCard},
    props: {
        recipeProp: {type: Recipe, required:true}
    },
    setup(){

      
      

        return {
          
          async setActiveRecipe(recipeId){
            try {
              await recipesService.setActiveRecipeById(recipeId)
              Modal.getOrCreateInstance('#activeRecipe').show()
            } catch (error) {
              Pop.error(error)
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

</style>