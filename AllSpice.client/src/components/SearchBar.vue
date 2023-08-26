
<template>

<form @submit.prevent="searchRecipes()" action="">
    <div class="d-flex flex-row ps-5 pe-5">
        <input type="text" autocomplete="off" name="text" class="input" placeholder="Search Recipes...">
    </div>
</form>

</template>


<script>
import { ref } from 'vue';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';

export default {
    setup(){

        const search = ref('')
        return {

            search, 
            
            async searchRecipes(){
                try {
                    const searchTerm = search.value
                    logger.log('searching recipes', searchTerm)
                    await recipesService.searchRecipes(searchTerm)
                } catch (error) {
                    logger.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>


.input {
  border: none;
  outline: none;
  border-radius: 15px;
  padding: .5em;
  background-color: #ccc;
  box-shadow: inset 2px 5px 10px rgba(0,0,0,0.3);
  transition: 300ms ease-in-out;
}

// .input:focus {
//   background-color: white;
//   transform: scale(1.05);
//   box-shadow: 13px 13px 100px #969696,
//              -13px -13px 100px #ffffff;
// }
</style>