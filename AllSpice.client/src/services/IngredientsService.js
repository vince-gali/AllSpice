import { AppState } from "../AppState.js"
import { Ingredients } from "../models/Ingredients.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService{

    async addIngredient(formData){
        const res = await api.post(`api/ingredients`, formData)
        logger.log('[Adding ingredient to list]', res.data)
        AppState.ingredients.push(new Ingredients(res.data))
        return res.data
    }

    async getIngredientsByRecipeId(recipeId){
        // AppState.ingredients = []
        logger.log(recipeId)
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('getting recipe ingredients', res.data)
        // if(res.data.length > 0){
            const ingredients = res.data.map(i=> new Ingredients(i))
            AppState.ingredients.push(...ingredients)
        // }
    }
}

export const ingredientsService = new IngredientsService()