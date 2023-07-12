import { AppState } from "../AppState.js"
import { Favorites } from "../models/Favorites.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class FavoritesService{
    async addFavorite(recipeId){
        const res = await api.post('api/favorites', {recipeId})
        logger.log('Adding to favorites', res.data)
        AppState.favorites = AppState.favorites.filter(f => new Favorites(res.data))

    }
}

export const favoritesService = new FavoritesService()