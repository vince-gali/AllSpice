<template>

    <div class="modal-content">
            <div class="modal-header bg-green">
                <h1 class="modal-Provide brief description" id="exampleModalLabel">New Recipe</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
    <form @submit.prevent="createRecipe()" id="addRecipe" action="">
        <div class="modal-body">
                    <div class="form-floating mb-3">
                        <label for="floatingInput">Title</label>
                        <input type="text" class="form-control" id="floatingInput" placeholder="Title..." v-model="editable.title">
                    </div>
                    <div>
                        <label for="">Category</label>
                        <select name="category" id="category" v-model="editable.category">
                            <option value="italian">Italian</option>
                            <option value="mexican">Mexican</option>
                            <option value="specialty-coffee">Specialty Coffee</option>
                            <option value="cheese">Cheese</option>
                            <option value="soup">Soup</option>
                        </select>
                    </div>
                    <div class="form-floating my-3">
                        <label for="floatingInput">Provide brief description</label>
                        <input v-model="editable.description" type="text" class="form-control" id="floatingInput" placeholder="Details..">
                    </div>
                    <div class="form-floating my-3">
                        <label for="floatingInput">Add Instruction Below</label>
                        <input v-model="editable.instructions" type="text" class="form-control" id="floatingInput" placeholder="Recipe Instructions..">
                    </div>
                    <div class="form-floating my-3">
                        <label for="floatingInput">Image Url</label>
                        <input v-model="editable.img" id="img" type="url" class="form-control" >
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close">Cancel</button>
                        <button type="submit" class="btn btn-success" data-bs-dismiss="modal" aria-label="Submit">Submit</button>
                    </div>
        </div>    
    </form>
    </div>

</template>


<script>
import { Modal } from 'bootstrap';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { ref } from 'vue';

export default {
    setup(){
        const editable = ref({})

        return {
            editable,
            async createRecipe(){
                try {
                    const formData = editable.value
                    const newRecipe = await recipesService.createRecipe(formData)
                    Modal.getOrCreateInstance('#addRecipe').hide()
                    editable.value = {}
                } catch (error) {
                    logger.error(error)
                    Pop.toast(error.message, 'error')
                }
            }

        }
    }
}
</script>


<style lang="scss" scoped>

.bg-green{
    background-color: #527360;
    color: white;
}

</style>