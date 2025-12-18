using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TendersManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TenderController : ControllerBase
    {
        private Application.TenderService.ITenderService _tenderService;
        public TenderController(Application.TenderService.ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        [HttpPost]
        public ActionResult AddTender([FromBody] TenderDetailsDto dto) {
            int userId= int.Parse(User.FindFirst("UserId")!.Value); //Get back for it, it need JWT
            _tenderService.CreateTender(dto,userId);
            return Ok();  
        }
    }
}
