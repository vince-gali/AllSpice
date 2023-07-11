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

        internal List<Recipe> GetAllRecipes()
        {
            string sql = @"
            SELECT
            rec.*,
            creator.*
            FROM recipes rec
            JOIN accounts creator ON rec.creatorId = creator.id;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator)=>
            {
                recipe.Creator = creator;
                return recipe;
            }).ToList();
            return recipes;
        }

        internal Recipe GetRecipeById(int recipeId)
        {
            string sql = @"
            SELECT 
            rec.*,
            creator.*
            FROM recipes rec
            JOIN accounts creator ON rec.creatorId = creator.id
            WHERE rec.id = @recipeId;
            ";
            Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator)=>
            {
                recipe.Creator = creator;
                return recipe;
            }, new {recipeId}).FirstOrDefault();
            return recipe;
        }

        internal int DeleteRecipe(int recipeId)
        {
            string sql = @"
            DELETE FROM recipes
            WHERE id = @recipeId LIMIT 1;
            ";
            int rows = _db.Execute(sql, new {recipeId});
            return rows;
        }

        internal void UpdateRecipe(Recipe updateData)
        {
            string sql = @"
            UPDATE recipes SET
            title=@title,
            instructions = @instructions,
            img = @img,
            category = @category
            WHERE id = @id;
            ";
            _db.Execute(sql, updateData);
        }

        internal List<Recipe> SearchRecipes(string search)
        {
            search = '%' + search + '%';
            string sql = @"
            SELECT
            rec.*,
            act.*
            FROM recipes rec
            JOIN accounts act ON act.id = rec.creatorId
            WHERE rec.title LIKE @search
            ;";
            List<Recipe> recipes = _db.Query<Recipe, Account, Recipe> (sql, (rec, profile)=>
            {
                rec.Creator = profile;
                return rec;
            }, new {search}).ToList();
            return recipes;
        }


    }
}