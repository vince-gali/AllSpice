namespace AllSpice.Services;

public class FavoritesService
    {
        private readonly FavoritesRepo _repo;
        private readonly RecipesRepo _recRepo;

        public FavoritesService(FavoritesRepo repo, RecipesRepo recRepo)
        {
            _repo = repo;
            _recRepo = recRepo;
        }

        internal Favorite AddFavorite([FromBody]Favorite favoriteData)
        {
            var recipe = _recRepo.GetRecipeById(favoriteData.RecipeId);
            Favorite newFavorite = _repo.AddFavorite(favoriteData);
            return newFavorite;

        }

        // internal Favorite AddFavorite(Favorite favoriteData)
        // {
        //     Favorite newFavorite = _repo.AddFavorite(favoriteData);
        //     return newFavorite;

        // }

        internal List<FavoriteRecipe>GetMyFavoriteRecipes(string accountId)
        {
            List<FavoriteRecipe> myFavorties = _repo.GetMyFavoriteRecipes(accountId);
            return myFavorties;
        }

        internal void RemoveFavorite (int favoriteId, string userId)
        {
            Favorite fav = GetById(favoriteId);
            if(fav.AccountId != userId) new Exception("You cannot remove this recipe from favorites");
            int rows = _repo.RemoveFavorite(favoriteId);
            if (rows > 1) new Exception("Something went wrong... tried to remove more than one");
        }

        internal Favorite GetById(int favoriteId)
        {
            Favorite fav = _repo.GetById(favoriteId);
            if(fav == null) new Exception("Invalid Id");
            return fav;
        }
    }
