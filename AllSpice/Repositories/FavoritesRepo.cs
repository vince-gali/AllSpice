namespace AllSpice.Repositories;

public class FavoritesRepo
    {
        private readonly IDbConnection _db;
        public FavoritesRepo (IDbConnection db)
        {
            _db = db;
        }

        internal Favorite AddFavorite (Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (accountId, recipeId)
            VALUES 
            (@AccountId,@RecipeId);
            SELECT LAST_INSERT_ID();
            ";
            int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = lastInsertId;
            return favoriteData;
        }

        internal List<FavoriteRecipe> GetMyFavoriteRecipes(string accountId)
        {
            string sql = @"
            SELECT
            favs.*,
            rec.*,
            act.*
            FROM favorites favs
            JOIN recipes rec ON rec.id = favs.recipeId
            JOIN accounts act ON act.id = rec.creatorId
            WHERE favs.accountId = @accountId;
            ";
            List<FavoriteRecipe> myFavorites = _db.Query<Favorite, FavoriteRecipe, Account, FavoriteRecipe>(sql, (favs, recipe, account)=>
            {
                recipe.FavoriteId = favs.Id;
                recipe.Creator = account;
                return recipe;
            }, new {accountId}).ToList();
            return myFavorites;
        }

        internal Favorite GetById(int favoriteId)
        {
            string sql = @"
            SELECT
            favs.*
            FROM favorites favs
            WHERE favs.id=@favoriteId;
            ";
            Favorite fav = _db.Query<Favorite>(sql, new{favoriteId}).FirstOrDefault();
            return fav;
        }

        internal int RemoveFavorite (int favoriteId)
        {
            string sql = @"
            DELETE FROM favorites
            WHERE id=@favoriteId
            LIMIT 1;
            ";
            int rows = _db.Execute(sql,new {favoriteId});
            return rows;
        }
    }
