<template>

<!-- <section class="row">
  <div class="container-fluid">
  <div class="d-flex flex-column justify-content-center">
    <div class="test-text text-white text-center">
    <h4> All Spice</h4>
    <p>Cherish Your Family</p>
    <p>And Their Cooking</p>
  </div>
    <img class="container-fluid elevation-5" src="../assets/img/spice-background.png" alt="">
  </div>
</div>
</section> -->


<div class="card text-bg-dark">
  <img src="../assets/img/spice-background.png" class="card-img" alt="...">
  <div class="align-content-center card-img-overlay text-center py-3">
    <h5 class="card-title">All Spice</h5>
    <p class="card-text">Cherish Your Family</p>
    <p class="card-text">And Their Cooking</p>
    <!-- <p class="card-text"><small>Last updated 3 mins ago</small></p> -->
  </div>
</div>







<section class="row">
  <div class="">
    <div class=" text-center">
        <button class="elevation-3" @click="filterBy = ''" >Home</button>
      <button class="elevation-3" @click="filterBy= 'myRecipes' " >My Recipes</button>
      <button class="elevation-3" @click="filterBy = 'favorites' " >Favorites</button>
    </div>
  </div>
</section>


<!-- <section class="row">
  <div class="text-center">
    <div class="d-flex flex-wrap ">
        <p class="p-2 elevation-3" @click="getRecipes()" >Home</p>
      <p class="p-2 elevation-3" @click="getMyRecipes()" >My Recipes</p>
      <p class="p-2 elevation-3" @click="getFavorites()" >Favorites</p>
    </div>
  </div>
</section> -->




<!-- //NOTE - old recipe card template
<section class="row">
  <div class="col-3 ">
    <div class="card rounded elevation-4">
      <div class="d-flex reverse-column">
        <p>Category</p>
        <i class="mdi mdi-heart-outline text-end"></i>
      </div>
        <img data-bs-toggle="modal" data-bs-target="#activeRecipe" src="https://th.bing.com/th/id/R.be8bdfb0c84545fd895880775229d9b4?rik=Nf9uPWQbmpIOVA&riu=http%3a%2f%2fthefoodiechef.com%2fwp-content%2fuploads%2f2014%2f03%2fIMG_6647.jpg&ehk=1wwUX2lqsykp8EAkLXucN0mdJx6GtpUvN0DG%2bxLJnrM%3d&risl=&pid=ImgRaw&r=0" alt="">
        <div>
          <p>Recipe Name</p>
          <p>Recipe Description</p>
        </div>
    </div>
  </div>
</section> -->






//NOTE - use code below as recipe card template

  <section class="row">
  <div class="py-2 container-fluid col-3" v-for="r in recipes" :key="r">
  <RecipeCard :recipeProp="r"/>
  </div>
  </section>



  








  <!-- <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 bg-white rounded elevation-3">
      <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo"
        class="rounded-circle">
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center">
        Vue 3 Starter
      </h1>
    </div>
  </div> -->



  

</template>

<script>
import { computed, onMounted, popScopeId, ref } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';

export default {
  setup() {

    const filterBy = ref('')
    
    async function getRecipes(){
      try{
        logger.log('getting recipes pt 1')
        await recipesService.getRecipes()
        // logger.log('is it working')
      } catch (error){
        Pop.error(error.message)
        logger.log(error)
      }
    }

   

    onMounted(()=>{
      getRecipes()
    })

    return {

      filterBy,

      recipes: computed(()=> 
      {
        if(filterBy.value == ""){
          return AppState.recipes
        } else{
          return AppState.recipes.filter(r => r.creatorId == AppState.account.id)
        }
      })

      // recipes: computed(()=>AppState.recipes),
      // myRecipes: computed(()=>AppState.myRecipes)
    }
  }
}
</script>

<style scoped lang="scss">
// @import "./assets/";
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }

  .header-img{
    background-image: url("../assets/img/spice-background.png");

  }

  .container {
  position: relative;
  // text-align: center;
  // color: white;
}

.centered {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}

.text-block {
  position: absolute;
  bottom: 20px;
  right: 20px;
  background-color: black;
  // color: white;
  padding-left: 20px;
  padding-right: 20px;
}

// .test-text{
//   position: absolute;
//   top: 0;
//   bottom: 10rem;
// }

.banner-card{
  position: relative;
}

.banner-card img{
max-width: 100%;
height: auto;
}

.banner-text{
  position: absolute;
  top: 25%;
}

// .text-bg{
//   border-style: solid;
//   border-width: 5px;
//   background-color: rgb(124, 118, 118);
//   text-shadow: 0 0 5px rgb(0, 0, 0);
// }

// .test{
//   border: ;
// }

.text-test{
  border: solid black;
  // padding: 10rem;
  border-color: red;
}

.text-bg{
  
  border: 1 px solid black;
  background-color: rgba(53, 53, 53, 0.699);
}

}
</style>
