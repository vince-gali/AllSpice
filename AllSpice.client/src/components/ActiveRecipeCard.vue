<template>

<div class="card mb-3" v-if="recipeProp">
  <div class="row ">
    <div class="col-4">
      <img class="img" :src="recipeProp.img" alt="...">
    </div>
    <div class="col-md-8">
      <div class="card-body">
        <h5 class="card-title">{{ recipeProp.title }}</h5>
        <!-- <p class="card-text">{{ recipeProp.description }}</p> -->
        <!-- <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p> -->
        <div class="d-flex flex-wrap p-1">
            <div class="card col-6">
            <div class="card-header">
                <p>Recipe instructions:</p>
            </div>
            <div class="card-body">
                <p>{{ recipeProp.instructions }}</p>
                <div>
                    <form >
                        <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Add Instruction"  aria-describedby="button-addon2">
                        <button class="btn btn-outline-secondary" type="button" id="button-addon2"> <i class="mdi mdi-plus"></i> </button>
                     </div>
                    </form>

                    <!-- <form action="">
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="Add Instruction">
                            <button> <i class="mdi mdi-plus"></i> </button>
                        </div>
                    </form> -->


                    

                </div>
            </div>
        </div>
            <div class="card col-6">
            <div class="card-header">
                <p>Ingredients List:</p>
            </div>
            <div class="card-body">
                <form @submit.prevent="addIngredient()">
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Add Ingredient" aria-label="Add Ingredient" aria-describedby="button-addon2">
                        <button class="btn btn-outline-secondary" type="button" id="button-addon2"> <i class="mdi mdi-plus"></i> </button>
                     </div>
                </form>
                <!-- <p>{{ recipeProp.ingredients }}</p> -->
                <!-- <p>2. Ingredients 2</p>
                <p>3. Ingredients 3</p> -->
            </div>
        </div>

        <div>
            <!-- <button >Remove Recipe</button> -->
            <button class="bg-danger" @click="deleteRecipe(recipeProp.id)" v-if="recipeProp.creatorId == user.id">Remove Recipe</button>
        </div>


        </div>
      </div>
    </div>
  </div>
</div>


<div class="card mb-3" style="max-width: 540px;">
  <div class="row g-0">
    <div class="col-md-4">
      <img src="..." class="img-fluid rounded-start" alt="...">
    </div>
    <div class="col-md-8">
      <div class="card-body">
        <h5 class="card-title">Card title</h5>
        <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
        <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p>
      </div>
    </div>
  </div>
</div>


<!-- <section class="row">
    <div class="col-10">
        <div class="d-flex flex-wrap">
        <div class="col-md-4">
            <img class="img-fluid rounded-start" src="https://th.bing.com/th/id/R.be8bdfb0c84545fd895880775229d9b4?rik=Nf9uPWQbmpIOVA&riu=http%3a%2f%2fthefoodiechef.com%2fwp-content%2fuploads%2f2014%2f03%2fIMG_6647.jpg&ehk=1wwUX2lqsykp8EAkLXucN0mdJx6GtpUvN0DG%2bxLJnrM%3d&risl=&pid=ImgRaw&r=0" alt="">
        </div>
        <div class="col-md-6">
            <div>
                <h5>Recipe name</h5>
                <p>Recipe description</p>
            </div>
            <div class="">
                <div class="card">
                    recipe instructions
                </div>
                <div class="card">
                    recipe Ingredients
                </div>
            </div>

        </div>
    </div>
    </div>
</section> -->



<!-- <div class="modal-body">
  <div class="container-fluid">
    <div class="row">
      <div class="col-sm-9 flex-wrap">
        <img :src="recipeProp?.img" alt="">
        <div class="row">
          <div class="col-8 col-sm-6">
            <h5>{{ recipeProp.title }}</h5>
          </div>
          <div class="col-4 col-sm-6">
            Level 2: .col-4 .col-sm-6
          </div>
        </div>
      </div>
    </div>
  </div>
</div> -->



</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';

export default {
    setup(){

        
        return {

            
            recipeProp: computed(()=> AppState.activeRecipe),
            user: computed(()=> AppState.user),

            async deleteRecipe(){
                try {
                    
                } catch (error) {
                    
                }
            },

            async deleteRecipe(recipeId){
                try {
                    logger.log('deleting yes')
                    await recipesService.deleteRecipe(recipeId)
                } catch (error) {
                    logger.error(error)
                    Pop.toast(error.message, 'error')
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>

.leftHalf {
   background: url(bg-1.jpg);
   width:50%;
   position: absolute;
   left: 0px;
   height: 100%;
aspect-ratio: 1/1;
}

.rightHalf {

   width: 50%;
   position: absolute;
   right: 0px;
   height: 100%;
}

.card-header{
    background-color: #527360;
    color:#fff ;
}

.card-img img{
    aspect-ratio: 1/1;
}
.img{
    width: 100%;
    // object-fit: c;
}


</style>