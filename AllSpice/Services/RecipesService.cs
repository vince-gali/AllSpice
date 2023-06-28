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


    }
}