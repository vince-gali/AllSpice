<template>

    <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title" id="exampleModalLabel">New Recipe</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
    <form id="addRecipe" action="">
        <div class="modal-body">
                    <div class="form-floating mb-3">
                        <label for="floatingInput">Title</label>
                        <input type="text" class="form-control" id="floatingInput" placeholder="Title...">
                    </div>
                    <div>
                        <label for="">Category</label>
                        <select name="category" id="category">
                            <option value="appetizer">Appetizer</option>
                            <option value="snack">Snack</option>
                            <option value="entree">Entree</option>
                        </select>
                    </div>
                    <!-- <div>
                    <select name="type" id="type" v-model="editable.type">
                        <option value="concert">Concerts</option>
                        <option value="convention">Conventions</option>
                        <option value="sport">Sports</option>
                        <option value="digital">Digital</option>
                    </select>
                </div> -->
        </div>    
    </form>
    </div>

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