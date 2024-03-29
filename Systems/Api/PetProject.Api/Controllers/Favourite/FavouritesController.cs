﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models;
using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.Api.Controllers.Advertisement.Models.Advertisement;
using PetProject.Api.Controllers.Favourite.Models;
using PetProject.Api.Controllers.Subscribe.Models;
using PetProject.FavoutiteService;
using PetProject.FavoutiteService.Models;

namespace PetProject.Api.Controllers.Favourite
{
    [Route("api/v{version:apiVersion}/favourite")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FavouritesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<FavouritesController> logger;
        private readonly IFavouriteService favouriteService;

        public FavouritesController(IMapper mapper,
            ILogger<FavouritesController> logger,
            IFavouriteService favouriteService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.favouriteService = favouriteService;
        }

        [HttpGet("{idUser}/{pageNumber}")]
        public async Task<AdvertisementResponseList> GetFavourites([FromRoute] Guid idUser, [FromRoute] int pageNumber)
        {
            var advertisementsModelList = await favouriteService.GetAllFavourite(idUser, pageNumber);
            var response = mapper.Map<AdvertisementResponseList>(advertisementsModelList);
            return response;
        }

        [HttpPost("add/")]
        public async Task<IActionResult> AddInFavouriteAsync([FromBody] AddFavouriteRequest request)
        {
            var model = mapper.Map<AddFavouriteModel>(request);
            await favouriteService.AddInFavourite(model);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInFavourite([FromRoute] int id)
        {
            await favouriteService.DeleteInFavourite(id);
            return Ok();
        }        
    }
}
