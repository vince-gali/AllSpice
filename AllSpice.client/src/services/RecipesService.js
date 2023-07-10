import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class RecipesService{

    async getRecipes(){
        logger.log('yes to recipes')
        const res = await api.get('api/recipes')
        logger.log('[GETTING RECIPES]', res.data)
        AppState.recipes = res.data.map(r=> new Recipe(r))
    }

    async setActiveRecipeById(recipeId){
        AppState.activeRecipe = AppState.recipes.find(r=> r.id == recipeId)
        logger.log('[GETTING ACTIVE RECIPE BY ID]', AppState.activeRecipe)
    }

    async createRecipe(formData){
        const res = await api.post('api/recipes', formData)
        logger.log('[Creating Recipe]', res.data)
        return res.data
    }

}

export const recipesService = new RecipesService()