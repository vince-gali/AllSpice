<template>
<!-- 
    <div class="modal-content" v-if="recipeProp">
        <div class="modal-body">
            <div  class="sideBy">
                <img class="modalImg img-fluid" :src="recipeProp.img" alt="">
                <div class="modalTitle">
                    <h5>{{ recipeProp.title }}</h5>
                </div>
                <div class="card">
                    <div class="card-header">
                        <h5>{{ recipeProp.instructions }}</h5>

                    </div>
                </div>
            </div>
            

        </div>
    </div> -->

<div class="modal-content" v-if="recipeProp" >
    <div class="modal-body modalLayout">

        <div class="">
            <img class="img-fluid modalImg" :src="recipeProp.img" alt="">
        </div>
<!-- right side of card -->
        <div class=" ps-5">
            <div>
                <h4>{{ recipeProp.title }}</h4>
            </div>

            <div class="card">
                <div class="card-header">
                    <h5>Recipe Instructions</h5>
                </div>
            </div>

        </div>

    </div>
</div>




    <!-- <div class="modal-content" v-if="recipeProp" >
        <div class="modal-body">

            <div class="test">

                
                <div class="col-4">
                    <div class="">
                        <img class="img-fluid modalImg" :src="recipeProp.img" alt="">
                    </div>
                </div>
                
                <div class="col-8">
                    <div class="modalTitle">
                        <h5 class="modalTitle">{{ recipeProp.title }}</h5>
                    </div>

                    <div class="test">

                        <div class="d-flex">
                            <div class="card">
                                <div class="card-header">
                                    <h5>Recipe Instructions</h5>
                                </div>
                            </div>
                            
                            <div class="card">
                                <div class="card-header">
                                    <h5>Recipe Ingredients</h5>
                                </div>
                            </div>
                        </div>
                </div>

                <div class="test">

                    
                    <div class="d-flex">
                        <div class="card">
                            <div class="card-body">
                                <h5>{{ recipeProp.instructions }}</h5>
                            </div>
                        </div>
                    </div>
                    
                    <div class="">
                        <div class="card">
                            <div class="card-body">
                                <h5>{{ recipeProp.ingredients }}Ingredients</h5>
                            </div>
                        </div>
                    </div>

                </div>

                    
                </div>
            </div>

        </div>
    </div> -->







</template>


<script>
import { computed, onMounted, popScopeId, ref, watchEffect } from 'vue';
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
            },

            async addInstruction(){
                try {
                    const formData = editable.value
                    formData.recipeId = route.params.id
                    await recipesService.addInstruction(formData)
                    editable.value={}
                } catch (error) {
                    logger.error(error)
                    Pop.error(error.message, 'error')
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
    min-width: 300px;
    // padding: 2rem;
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

.sideBy{
    display: flex;

}

.modalImg{
    // max-height: 75vh;
    min-width: 250px;
    // position: relative;
    // aspect-ratio: 1/1;
}

.modalTitle{
    display: flex;
    justify-content: center;
    align-items: center;
}

.test{
    display: flex;
    flex-direction: row;
}

.modalSize{
    // min-width: 350px;
    // max-width: 800px;
}

.modalLayout{
    display: flex;
    flex-direction: row;

}

// .modal-content{
//     max-width: 90%;
// }

</style>