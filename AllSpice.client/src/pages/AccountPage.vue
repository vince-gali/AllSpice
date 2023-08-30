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
import { computed } from 'vue';
import { AppState } from '../AppState';
export default {
  setup() {
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
