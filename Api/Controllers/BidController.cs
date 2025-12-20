using Application.DTO;
using Application.Service.BidService;
using Domain.Models;
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

        [HttpPost]
        public async Task<ActionResult> AddBid([FromBody]BidDTO dto) {
            await _bidService.AddBid(dto);
            return Ok();
        }

        [HttpGet("OpenTenders")]
        public async Task<ActionResult<List<Tender>>> GetOpenTenders()
        {
            var tenders=await _bidService.GetOpenTenders();
            return Ok(tenders);
        }

        [HttpPost("FinancialProposal")]
        public async Task<ActionResult> AddFinancialProposal([FromBody] FinancialProposalDTO dto)
        {
            await _bidService.AddFinancialProposal(dto);
            return Ok();
        }

        [HttpPost("TechnicalProposal")]
        public async Task<ActionResult> AddTechnicalProposal([FromBody] TechnicalProposalDTO dto)
        {
            await _bidService.AddTechnicalProposal(dto);
            return Ok();
        }
    }
}
