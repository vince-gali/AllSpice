namespace AllSpice.Repositories
{
    public class IngredientsRepo
    {
        private readonly IDbConnection _db;

        public IngredientsRepo(IDbConnection db)
        {
            _db = db;
        }

        // internal Ingredients CreateIngredient(Ingredients ingredientData)
        // {
        //     string sql = @"
        //     INSERT INTO ingredients
        //     (name, quantity, recipeId, creatorId)
        //     VALUES 
        //     (@Name, @Quantity, @RecipeId, @CreatorId);
            
        //     SELECT 
        //     ing.*,
        //     act.*
        //     FROM ingredients ing
        //     JOIN accounts act ON act.id = ing.creatorId
        //     WHERE ing.id = LAST_INSERT_ID();
        //     ";
        //     Ingredients newIngredient = _db.Query<Ingredients, Account, Ingredients>(sql, (ingredients, account)=>
        //     {
        //         ingredients.Creator = account;
        //         return ingredients;
        //     }, ingredientData).FirstOrDefault();
        //     return newIngredient;
            
        // }

        internal Ingredients CreateIngredient(Ingredients ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@Name, @Quantity, @RecipeId);
            SELECT 
            *
            FROM ingredients
            WHERE id = LAST_INSERT_ID();
            ";
            Ingredients newIngredient = _db.Query<Ingredients>(sql, ingredientData).FirstOrDefault();
            return newIngredient;
        }

        // internal Ingredients GetById(int ingredientsId)
        // {
        //     string sql = @"
        //     SELECT
        //     ing.*,
        //     act.*
        //     FROM ingredients ing
        //     WHERE ing.id = @ingredientsId
        //     ;";
        //     Ingredients ingredients = _db.Query<Ingredients, Account, Ingredients>(sql, (ingredients, account)=>
        //     {
        //         ingredients.Creator = account;
        //         return ingredients;
        //     }, new {ingredientsId}).FirstOrDefault();
        //     return ingredients;
        // }

        internal Ingredients GetById(int ingredientsId)
        {
            string sql = @"
            SELECT
            ing.*
            FROM ingredients ing
            WHERE ing.id = @ingredientsId
            ";
            Ingredients ingredients = _db.Query<Ingredients>(sql,new {ingredientsId}).FirstOrDefault();
            return ingredients;
        }

        // internal List<Ingredients> GetIngredientsByRecipeId(int recipeId)
        // {
        //     string sql = @"
        //     SELECT 
        //     ing.*,
        //     act.*
        //     FROM ingredients ing
        //     JOIN accounts act on act.id = ing.creatorId
        //     WHERE ing.recipeId = @recipeId;
        //     ";
        //     List<Ingredients> recipeIngredients = _db.Query<Ingredients, Account, Ingredients>(sql, (ingredients, account)=>
        //     {
        //         ingredients.Creator = account;
        //         return ingredients;
        //     }, new {recipeId}).ToList();
        //     return recipeIngredients;
        // }

        internal List<Ingredients> GetIngredientsByRecipeId(int recipeId)
        {
            string sql = @"
            SELECT
            *
            FROM ingredients ing
            WHERE recipeId = @recipeId;
            ";
            List<Ingredients> recipeIngredients = _db.Query<Ingredients>(sql, new {recipeId}).ToList();
            return recipeIngredients;
        }

        internal void DeleteIngredient (int ingredientId)
        {
            string sql = @"
            DELETE 
            FROM ingredients
            WHERE id=@ingredientId
            LIMIT 1;
            ";
            _db.Execute(sql, new {ingredientId});
        }

    }
}