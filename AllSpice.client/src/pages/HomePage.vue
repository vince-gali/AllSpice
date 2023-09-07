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
  <div class="overlay-input d-flex flex-row">
    <div>
      <SearchBar/>
    </div>
    <div>
      <Login/>
    </div>
  </div>
  <img src="../assets/img/spice-background.png" class="card-img image-container" alt="...">
  <div class="align-items-center card-img-overlay text-center ">
    <h5 class="card-title">All Spice</h5>
    <p class="card-text">Cherish Your Family</p>
    <p class="card-text">And Their Cooking</p>
  </div>
</div>

<!-- <div class="homePage">
  <img src="../assets/img/spice-background.png" alt="">
//NOTE - left off right here
</div> -->






<!-- //NOTE - buttons below work -->
<!-- <section class="row">
  <div class="">
    <div class=" text-center">
        <button class="elevation-3" @click="filterBy = ''" >Home</button>
      <button class="elevation-3" @click="filterBy= 'myRecipes' " >My Recipes</button>
      <button class="elevation-3" @click="filterBy = 'favorites' " >Favorites</button>
    </div>
  </div>
</section> -->




<section class="row py-2"> 
  <div class="col-10 col-md-5">
    <div class="card elevation-3 bg-white">
      <div class="d-flex pt-1 justify-content-around">
        <h5  class="filters" @click="filterBy = ''" >Home</h5>
        <!-- <h5 v-if="filterBy=''"  class="activeText filters" @click="filterBy = ''" >Home</h5> -->
        <h5 class="filters" @click="filterBy= 'myRecipes' " id="myRecipes">My Recipes</h5>
        <!-- <h5 class="filters" @click="getMyFavorites(user.id)" id="myFavorites" >Favorites</h5> -->
        <h5 class="filters" @click="filterBy = 'myFavorites' " >Favorites</h5>
      </div>
    </div>
  </div>
</section>

<!-- 
<section class="row py-2"> 
  <div class="col-10 col-md-5">
    <div class="card elevation-3 bg-white">
      <div class="d-flex justify-content-around">
        <h5 class="filters" @click="filterBy = ''" >Home</h5>
        <h5 class="filters" @click="filterBy= 'myRecipes' ">My Recipes</h5>
        <h5 class="filters" @click="filterBy = 'favorites' " >Favorites</h5>
      </div>
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





<!-- //NOTE - use code below as recipe card template -->

  <!-- <section class="row">
  <div class="py-4 container-fluid col-11 col-md-3" v-for="r in recipes" :key="r">
  <RecipeCard :recipeProp="r"/>
  </div>
  </section> -->

  <!-- <section class="row">
    <div class="ps-3 col-11 col-md-3" v-for="r in recipes" :key="r">
      <RecipeCard :recipeProp="r"/>
    </div>
  </section> -->

  <div class="hmRecipes">
    <RecipeCard v-for="r in recipes" :key="r.id" :recipeProp="r"/>
  </div>



  








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
import { accountService } from '../services/AccountService.js';

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

    // async function getMyFavorites(){
    //   try {
    //     await accountService.getAccountFavorites()
    //   } catch (error) {
    //     Pop.error(error.message)
    //     logger.log(error)
    //   }
    // }

   

    onMounted(()=>{
      getRecipes()
      // getMyFavorites()
    })

    return {

      filterBy,

     async getMyFavorites(){
      try {
        await accountService.getAccountFavorites()
        
      } catch (error) {
        Pop.error(error)
        
      }
     },
    
      user: computed(()=> AppState.user),
      // recipes: computed(()=> 
      // {
      //   if(filterBy.value == ""){
      //     return AppState.recipes
      //   } else{
      //     return AppState.recipes.filter(r => r.creatorId == AppState.account.id)
      //   }
      // }),
      recipes: computed(()=>
      {
      if(filterBy.value == ''){
        return AppState.recipes
      } 
      else if(filterBy.value == 'myFavorites'){
        return AppState.myFavorites
      }
      else {
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


.filters:hover{
  color: #219653;
  // border-color: #D5BBB1;
  // border-radius: .5rem;
}


.overlay-input {
    position: absolute;
    top: 15%;
    left: 85%;
    transform: translate(-50%, -50%);
    z-index: 1;
    padding: 10px;
    border-radius: 5px;
  }

  .image-container {
    position: relative;
    display: inline-block;
  }

  .hmRecipes{
    display: flex;
  flex-wrap: wrap;
  }

  @media(max-width: 768px){
  .hmRecipes{
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
}
}

.row{
  display: flex;
  justify-content: center;
  align-items: center;
}

.activeText{
  color: #219653;
}


</style>
