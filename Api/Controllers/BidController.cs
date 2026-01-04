using Application.DTO;
using Application.Service.BidService;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TendersManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [Authorize(Roles ="Bidder")]
        [HttpPost]
        public async Task<ActionResult> AddBid([FromBody]BidDTO dto) {
            var userIdClaim = User.FindFirst("UserId")?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
                return Unauthorized("Missing UserId claim");

            int userId = int.Parse(userIdClaim);

            await _bidService.AddBid(dto, userId);
            return Ok();
        }

        [Authorize(Roles = "Bidder")]
        [HttpGet("OpenTenders")]
        public async Task<ActionResult<List<TenderListItemDTO>>> GetOpenTenders()
        {
            var tenders=await _bidService.GetOpenTenders();
            return Ok(tenders);
        }

        [Authorize(Roles = "Bidder")]
        [HttpPost("FinancialProposal")]
        public async Task<ActionResult> AddFinancialProposal([FromBody] FinancialProposalDTO dto)
        {
            await _bidService.AddFinancialProposal(dto);
            return Ok();
        }

        [Authorize(Roles = "Bidder")]
        [HttpPost("TechnicalProposal")]
        public async Task<ActionResult> AddTechnicalProposal([FromBody] TechnicalProposalDTO dto)
        {
            await _bidService.AddTechnicalProposal(dto);
            return Ok();
        }

        [Authorize(Roles ="Bidder")]
        [HttpGet("tenders-docs")]
        public async Task<ActionResult<List<GetDocumentsDTO>>> GetTenderDocuments() {
            
            var docs = await _bidService.GetTenderDocuments();
            return Ok(docs);
        }
    }
}
