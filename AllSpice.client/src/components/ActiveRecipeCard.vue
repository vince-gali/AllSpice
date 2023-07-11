<template>

<div class="card mb-3" v-if="recipeProp">
  <div class="row ">
    <div class="col-4">
      <img class="img" :src="recipeProp.img" alt="...">
    </div>
    <div class="col-md-8">
      <div class="card-body">
        <h5 class="card-title">{{ recipeProp.title }}</h5>
<!-- import AddIngredientForm from './AddIngredientForm.vue.js'; -->
        <!-- <p class="card-text">{{ recipeProp.description }}</p> -->
        <!-- <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p> -->
        <div class="d-flex flex-wrap p-1">
            <div class="card col-6">
            <div class="card-header">
                <p>Recipe instructions:</p>
            </div>
            <div class="card-body">
                <p>{{ recipeProp.instructions }}</p>
                <!-- <p>{{ recipeProp.id }}</p> -->
                <div>
                    <form v-if="recipeProp.creatorId == user.id">
                        <div class="input-group mb-3">
                            <input v-model="editable.instructions" type="text" class="form-control" placeholder="Add Instruction"  aria-describedby="button-addon2">
                            <button class="btn btn-outline-secondary" type="button" id="button-addon2"> <i class="mdi mdi-plus"></i> </button>
                        </div>
                    </form>


                </div>
            </div>
            </div>
            <div class="card col-6">
            <div class="card-header">
                <p>Ingredients List:</p>
            </div>
            <div class="card-body">
                <div>
                    {{ recipeIngredients }}
                    <!-- <p>{{ recipeIngredients.name }}</p> -->
                </div>
                <form v-if="recipeProp.creatorId == user.id" @submit.prevent="addIngredient()">
                    <div class="input-group mb-3">
                        <input v-model="editable.ingredient" type="text" class="form-control" placeholder="Add Ingredient" aria-label="Add Ingredient" aria-describedby="button-addon2">
                        <button class="btn btn-outline-secondary" type="button" id="button-addon2"> <i class="mdi mdi-plus"></i> </button>
                     </div>
                </form>
            </div>
        </div>

        <div class="modal-footer">
            <!-- <button >Remove Recipe</button> -->
            <button class="bg-danger" @click="deleteRecipe(recipeProp.id)" v-if="recipeProp.creatorId == user.id">Remove Recipe</button>
        </div>

        <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>


        </div>
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




</template>


<script>
import { computed, onMounted, ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js';
import { useRoute } from 'vue-router';
import { Recipe } from '../models/Recipe.js';

export default {
    props: {
        recipeProp: { type: Recipe, required: true }
    },
    setup(props) {
        const editable = ref({});
        const route = useRoute();
        // const recipeIngredients = ref()
        watchEffect(() => {
            // editable.value = props.recipeProp
            if (AppState.activeRecipe) {
                getIngredientsByRecipeId();
            }
        });
        async function getIngredientsByRecipeId() {
            try {
                // debugger
                // const recipeId = route.params.id
                logger.log(props.recipeProp);
                await ingredientsService.getIngredientsByRecipeId(AppState.activeRecipe.id);
            }
            catch (error) {
                logger.error(error);
                Pop.toast(error.message, "error");
            }
        }
        // onMounted(()=> {
        //     getIngredientsByRecipeId()
        // })
        return {
            editable,
            recipeProp: computed(() => AppState.activeRecipe),
            user: computed(() => AppState.user),
            // ingredients: computed(()=>AppState.ingredients),
            recipeIngredients: computed(() => AppState.ingredients.filter(i => i.recipeId == AppState.activeRecipe.id)),
            // activeRecipe: computed(()=> AppState.activeRecipe),
            async deleteRecipe(recipeId) {
                try {
                    if (await Pop.confirm("are you sure you want to delete your recipe"))
                        logger.log("deleting yes");
                    await recipesService.deleteRecipe(recipeId);
                }
                catch (error) {
                    logger.error(error);
                    Pop.toast(error.message, "error");
                }
            },
            async addIngredient() {
                try {
                    const formData = editable.value;
                    formData.recipeId = route.params.id;
                    await ingredientsService.addIngredient(formData);
                    editable.value = {};
                }
                catch (error) {
                    logger.error(error);
                    Pop.toast(error.message, "error");
                }
            }
        };
    },
    // components: { AddIngredientForm }
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
    aspect-ratio: 1/1;
    display: flex;
    align-content: center;
    // object-fit: c;
}


</style>