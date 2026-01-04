using Application.DTO;
using Application.Service.TenderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TendersManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenderController : ControllerBase
    {
        private ITenderService _tenderService;
        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }


        


        [Authorize(Roles = "ProcurementOfficer")]
        [HttpPost]
        public async Task<ActionResult<int>> AddTender([FromBody] CreateTenderDTO dto) {
           
            var userIdClaim= User.FindFirst("UserId")?.Value; //This gets the user ID from the JWT claims.

            if (string.IsNullOrWhiteSpace(userIdClaim)) //if the claim is missing, return an unauthorized response.
                return Unauthorized("Missing UserId claim");

            int userId = int.Parse(userIdClaim);//Parse the user ID claim to an integer.
            var tenderId= await _tenderService.CreateTender(dto,userId);
            return Ok(tenderId);  
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpPost("{tenderId:int}/eligibility")]
        public async Task<ActionResult> AddEligibilityCriteria(int tenderId, [FromBody] EligibilityCriteriaDTO dto)
        {
            dto.TenderId = tenderId;
            await _tenderService.AddEligibilityCriteria(dto);
            return Ok();
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpPost("{tenderId:int}/documents/upload")]
        public async Task<ActionResult> UploadTenderDocument(int tenderId,[FromForm] TenderDocumentListItemDto dto) {

            await _tenderService.UploadTenderDocument(tenderId, dto);
            return Ok();
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpDelete("{tenderId:int}")]
        public async Task<ActionResult> DeleteTender(int tenderId) { 
            await _tenderService.DeleteTender(tenderId);
            return Ok();
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpDelete("eligibility/{criteriaId:int}")]
        public async Task<ActionResult> DeleteEligibilityCriteria(int criteriaId)
        {
            await _tenderService.DeleteEligibilityCriteria(criteriaId);
            return Ok();
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpDelete("documents/{documentId:int}")]
        public async Task<ActionResult> DeleteTenderDocument(int documentId)
        {
            await _tenderService.DeleteTenderDocument(documentId);
            return Ok();
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpPut("{tenderId:int}/update")]
        public async Task<ActionResult> UpdateTender(int tenderId, [FromBody]CreateTenderDTO dto) { 
           await  _tenderService.UpdateTender(dto, tenderId);
            return Ok();
        }

        [Authorize(Roles = "ProcurementOfficer")]
        [HttpPut("eligibilitycriteria/{criteriaId:int}/update")]
        public async Task<ActionResult> UpdateEligibilityCriteria(int criteriaId, [FromBody] EligibilityCriteriaDTO dto)
        {
            await _tenderService.UpdateCriteria(dto, criteriaId);
            return Ok();
        }

    }
}
