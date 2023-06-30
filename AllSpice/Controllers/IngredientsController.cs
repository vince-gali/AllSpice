namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth0;

        public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0)
        {
            _ingredientsService = ingredientsService;
            _auth0 = auth0;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateIngredient([FromBody] Ingredients ingredientData)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                ingredientData.CreatorId = userInfo.Id;
                Ingredients newIngredient = _ingredientsService.CreateIngredient(ingredientData);
                return Ok(newIngredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{ingredientId}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                _ingredientsService.DeleteIngredient(ingredientId, userInfo.Id);
                return Ok("Ingredient has been removed from recipe");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}