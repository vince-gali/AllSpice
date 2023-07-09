<template>

    <div class="modal-content">
            <div class="modal-header bg-green">
                <h1 class="modal-Provide brief description" id="exampleModalLabel">New Recipe</h1>
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
                    <div class="form-floating my-3">
                        <label for="floatingInput">Provide brief description</label>
                        <input type="text" class="form-control" id="floatingInput" placeholder="Details..">
                    </div>
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

.bg-green{
    background-color: #527360;
    color: white;
}

</style>