namespace AllSpice.Services;

public class FavoritesService
    {
        private readonly FavoritesRepo _repo;

        public FavoritesService(FavoritesRepo repo)
        {
            _repo = repo;
        }

        internal Favorite AddFavorite(Favorite favoriteData)
        {
            Favorite newFavorite = _repo.AddFavorite(favoriteData);
            return newFavorite;

        }

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
