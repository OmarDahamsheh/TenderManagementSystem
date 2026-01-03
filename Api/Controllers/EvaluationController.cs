using Application.Service.EvaluationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TendersManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;
        public EvaluationController(IEvaluationService evaluationService)
        {
            this._evaluationService = evaluationService;
        }

        [Authorize(Roles ="Evaluator")]
        [HttpGet("SortedBids")]
        public async Task<ActionResult> GetBidsSortedByPrice() {
            var bids=await _evaluationService.GetBidsSortedByPrice();
            return Ok(bids);
        }

        [Authorize("Evaluator")]
        [HttpPost("SetTheAwardUser/{tenderId:int}")]
        public async Task<ActionResult> AwardToUserWithHighestBid(int tenderId) {
            await _evaluationService.AwardedToUserWithHighestBid(tenderId);
            return Ok();
        }
    }
}
