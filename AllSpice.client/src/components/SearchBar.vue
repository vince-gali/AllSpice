
<template>

<form @submit.prevent="searchPosts()" action="">
    <div>

        <input type="text" class="w-100 rounded" v-model="search" placeholder="Search...">
        <button class="mdi mdi-magnify" type="submit"></button>
        <i class="mdi mdi-magnify"></i>
    </div>
    </form>

</template>


<script>
export default {
    setup(){
        return {}
    }
}
</script>


<style lang="scss" scoped>

</style>