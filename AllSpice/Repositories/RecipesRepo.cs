namespace AllSpice.Repositories
{
    public class RecipesRepo
    {
        private readonly IDbConnection _db;
        public RecipesRepo(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (title, instructions, img, category, creatorId)
            VALUES 
            (@Title, @Instructions, @Img, @Category, @CreatorId);

            SELECT
                rec.*,
                creator.*
            FROM recipes rec
            JOIN accounts creator ON rec.creatorId = creator.id
            WHERE rec.id = LAST_INSERT_ID();
            ";
            Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) => 
            {
                recipe.Creator = creator;
                return recipe;
                
            }, recipeData).FirstOrDefault();
            return recipe;
        }


    }
}