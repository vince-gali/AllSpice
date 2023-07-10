<template>

<div class="card mb-3" >
  <div class="row ">
    <div class="col-md-4">
      <img src="https://th.bing.com/th/id/R.be8bdfb0c84545fd895880775229d9b4?rik=Nf9uPWQbmpIOVA&riu=http%3a%2f%2fthefoodiechef.com%2fwp-content%2fuploads%2f2014%2f03%2fIMG_6647.jpg&ehk=1wwUX2lqsykp8EAkLXucN0mdJx6GtpUvN0DG%2bxLJnrM%3d&risl=&pid=ImgRaw&r=0" class="img-fluid rounded-start" alt="...">
    </div>
    <div class="col-md-8">
      <div class="card-body">
        <h5 class="card-title">{{ recipe.title }}</h5>
        <p class="card-text">Recipe Description</p>
        <!-- <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p> -->
        <div class="d-flex flex-wrap p-1">
            <div class="card col-6">
            <div class="card-header">
                <p>Recipe instructions here</p>
            </div>
            <div class="card-body">
                <p>1. step 1</p>
                <p>2. step 2</p>
                <p>3. step 3</p>
            </div>
        </div>
            <div class="card col-6">
            <div class="card-header">
                <p>Ingredients here</p>
            </div>
            <div class="card-body">
                <p>1. Ingredients 1</p>
                <p>2. Ingredients 2</p>
                <p>3. Ingredients 3</p>
            </div>
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
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
    setup(){
        return {
            recipe: computed(()=> AppState.activeRecipe)
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

</style>