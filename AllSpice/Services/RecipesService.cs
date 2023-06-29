namespace AllSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepo _repo;
        public RecipesService(RecipesRepo repo)
        {
            _repo = repo;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.CreateRecipe(recipeData);
            return recipe;
        }

        internal List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = _repo.GetAllRecipes();
            return recipes;
        }

        internal Recipe GetRecipeById(int recipeId)
        {
            Recipe recipe = _repo.GetRecipeById(recipeId);
            if(recipe == null) throw new Exception("Recipe at id{recipeId} does not exist");
            return recipe;
        }

        internal void DeleteRecipe(int recipeId, string userId)
        {
            Recipe recipe = GetRecipeById(recipeId);
            if( recipe.CreatorId != userId) throw new Exception("Hey you can't do that");
            int rows = _repo.DeleteRecipe(recipeId);
            if (rows> 1 )throw new Exception ("What is even going on. Where is Mello Mike?");
        }

        internal Recipe UpdateRecipe(Recipe updateData)
        {
            Recipe original = GetRecipeById(updateData.Id);
            // if(original.CreatorId != userId) throw new Exception("you aren't authorized to do that");
            original.Title = updateData.Title !=null ? updateData.Title : original.Title;
            original.Instructions = updateData.Instructions !=null ? updateData.Instructions : original.Instructions;
            original.Img = updateData.Img !=null ? updateData.Img : original.Img;
            original.Category = updateData.Category !=null ? updateData.Category : original.Category;
            _repo.UpdateRecipe(original);
            return original;
        }


    }
}