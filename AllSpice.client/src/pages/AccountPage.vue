<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>

  <div class="accountRecipes">
    <RecipeCard v-for="r in recipes" :key="r.id" :recipe="r"/>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { accountService } from '../services/AccountService.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
export default {
  setup() {

    async function getAccountFavorites(){
      try {
        await accountService.getAccountFavorites()
      } catch (error) {
        Pop.error(error.message)
        logger.log(error)
      }
    }

    onMounted(()=>{
      getAccountFavorites()
    })
    return {
      account: computed(() => AppState.account),
      recipe: computed(()=>AppState.myRecipes)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
