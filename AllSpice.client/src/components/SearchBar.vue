
<template>

<form @submit.prevent="searchRecipes()" action="">
    <div class="d-flex flex-row">

        <input type="text" class="w-100 rounded" v-model="search" placeholder="Search...">
        <!-- <button class="mdi mdi-magnify" type="submit"></button> -->
        <i class="mdi mdi-magnify"></i>
    </div>
    </form>

</template>


<script>
import { ref } from 'vue';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';

export default {
    setup(){

        const search = ref({})
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

</style>