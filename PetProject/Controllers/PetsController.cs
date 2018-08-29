using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetProject.Enums;
using PetProject.Models;
using PetProject.Services;

namespace PetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PetNamesByOwnerGender>> Get()
        {
            var results = _petService.GetOwnersWithPetType(PetType.Cat);

            return results;
        }

    }
}
