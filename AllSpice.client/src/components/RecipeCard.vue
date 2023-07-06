<template>

    <!-- <div class="card">
        <img src="" alt="">
        <p>{{recipeProp.title}}</p>
    </div> -->

    {{recipeProp}}

</template>


<script>
import { Recipe } from '../models/Recipe.js';
export default {

    props: {
        recipeProp: {type: Recipe, required:true}
    },
    setup(){
        return {}
    }
}
</script>


<style lang="scss" scoped>

</style>