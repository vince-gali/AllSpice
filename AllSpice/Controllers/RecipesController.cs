namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RecipesController : ControllerBase
{
        private readonly RecipesService _recipesService;
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, Auth0Provider auth, IngredientsService ingredientsService)
        {
            _recipesService = recipesService;
            _auth = auth;
            _ingredientsService = ingredientsService;
        }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = _recipesService.CreateRecipe(recipeData);
            return new ActionResult<Recipe>(Ok(recipe));
        }
        catch (Exception e)
        {
            return new ActionResult<Recipe>(BadRequest(e.Message));
        }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetAllRecipes();
            return Ok(recipes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


//FIXME - fix get request below and replace the one above

    // [HttpGet]
    // public ActionResult<List<Recipe>> GetAllRecipes (string search)
    // {
    //     try
    //     {
    //         List<Recipe> recipes;
    //         if (search == null)
    //             {
    //                 recipes=_recipesService.GetAllRecipes();
    //             }
    //         else
    //         {
    //             recipes = _recipesService.SearchRecipes(search);
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }



    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.GetRecipeById(recipeId);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredients>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredients> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
            return Ok(ingredients);
        }
        catch (Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            _recipesService.DeleteRecipe(recipeId, userInfo.Id);
            return Ok("That recipe has been deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{recipeId}")]
    [Authorize]
    public  ActionResult<Recipe> UpdateRecipe(int recipeId, [FromBody] Recipe updateData)
    {
        updateData.Id = recipeId;
        //TODO - creators info?
        Recipe recipe = _recipesService.UpdateRecipe(updateData);
        return Ok(recipe);
    }

   
}




