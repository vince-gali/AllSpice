namespace AllSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepo _repo;

        public IngredientsService(IngredientsRepo repo)
        {
            _repo = repo;
        }

        internal Ingredients CreateIngredient(Ingredients ingredientData)
        {
            Ingredients newIngredient = _repo.CreateIngredient(ingredientData);
            return newIngredient;
        }

        internal Ingredients GetById(int ingredientsId)
        {
            Ingredients ingredients = _repo.GetById(ingredientsId);
            if (ingredients == null) throw new Exception("Invalid Id");
            return ingredients;
        }

        internal List<Ingredients> GetIngredientsByRecipeId (int recipeId)
        {
            List<Ingredients> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
            return ingredients;
        }

        internal void DeleteIngredient (int ingredientId, string userId)
        {
            Ingredients ingredient = GetById(ingredientId);
            _repo.DeleteIngredient(ingredientId);
            // if(rows>1) new Exception("Something went wrong... tried to delete more than one");
        }
    }
}


