using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using promociones.api.Helpers;
using promociones.api.Interfaces;
using promociones.api.Models;
using promociones.api.Responses;
using promociones.data.Interfaces;
using promociones.data.Models;
using promociones.data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace promociones.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : ControllerBase
    {
        private readonly IPromocionRepository _promoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PromocionController(IPromocionRepository promoRepository, IUnitOfWork uow, IMapper mapper)
        {
            _promoRepository = promoRepository;
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/<PromocionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = new BaseResponse<IList<PromocionRequest>>();

            res.Data = _mapper.Map<IList<Promocion>, IList<PromocionRequest>>(await _promoRepository.GetAll());
            return Ok(res);
        }

        // GET api/<PromocionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = new BaseResponse<PromocionRequest>();
            var promo = await _promoRepository.Get(id);
            if (promo == null)
            {
                return NotFound();
            }
            res.Data = _mapper.Map<PromocionRequest>(promo);
            return base.Ok(res);
        }

        // POST api/<PromocionController>
        [HttpPost]
        public async Task<IActionResult> Create(PromocionRequest promocionRequest)
        {
            var res = new BaseResponse<PromocionRequest>();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            var promocion = _mapper.Map<data.Models.Promocion>(promocionRequest);

            if (PromocionHelper.Validate(promocion))
            {
                var promo = await _promoRepository.Add(promocion);
                await _uow.Commit();
                res.Data = _mapper.Map<PromocionRequest>(promo);
            }

            return Ok(res);
        }

        // PUT api/<PromocionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, data.Models.Promocion promocionIn)
        {
            return NoContent();
        }

        // DELETE api/<PromocionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return NoContent();
        }
    }
}
