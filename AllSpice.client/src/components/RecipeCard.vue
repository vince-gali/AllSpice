<template>

<div data-bs-toggle="modal" data-bs-target="#activeRecipe" class="card text-bg-dark">
    <img :src=" recipeProp.img " class="card-img" alt="...">

    <div class=" card-img-overlay text-bg text-white">
      <h5 style=" background-color: rgba(53, 53, 53, 0.626);" class=" p-1 w-50 rounded card-title ">Soup Category</h5>
      <div  class=" pt-5">
        <p  style=" background-color: rgba(53, 53, 53, 0.626);" class=" w-50 p-1 border border-black rounded card-text text-borders">{{ recipeProp.title }}</p>
        <p  style=" background-color: rgba(53, 53, 53, 0.626);" class=" w-50 p-1 border border-black rounded card-text">Recipe Description</p>
      </div>
    </div>

  </div>

</template>


<script>
import { Recipe } from '../models/Recipe.js';
export default {

    props: {
        recipeProp: {type: Recipe, required:true}
    },
    setup(){
        return {}
    }
}
</script>


<style lang="scss" scoped>

</style>