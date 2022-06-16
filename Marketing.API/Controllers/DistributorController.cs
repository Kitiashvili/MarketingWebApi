using AutoMapper;
using Marketing.Domain.DTO;
using Marketing.Domain.Entities;
using Marketing.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Marketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DistributorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllDistributor")]
        public async Task<IActionResult> GetAllDistributorAsync()
        {

            var distributors = await _unitOfWork.Distributors.Query()
                .Include(x => x.Sales)
                .Include(a => a.AddressInfo)
                .Include(x => x.ChildDistributors)
                .ToListAsync();

            if (distributors is null)
                return NotFound();

            var tmp = _unitOfWork.Distributors.GetAllAsync();
            return Ok(distributors);
        }

        [HttpPost("RegisterDistributor")]
        [ActionName(nameof(CreateDistributorAsync))]
        public async Task<IActionResult> CreateDistributorAsync([FromBody] DistributorDTO distributorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var distributor = _mapper.Map<Distributor>(distributorDTO);
                var recomendator = await _unitOfWork.Distributors.GetRecomendatorId(distributorDTO);
                var childCounts = await _unitOfWork.Distributors.IfCanBeRecomendator(recomendator);
                if (!childCounts )
                {
                    return StatusCode(400, "Recomendator isn't available");
                }
                else
                {
                    if (recomendator != null) { distributor.RecomendatorId = recomendator.Id; }
                    else { distributor.RecomendatorId = null; };
                    distributor.DistributorCode = Guid.NewGuid();

                    await _unitOfWork.Distributors.AddAsync(distributor);
                    await _unitOfWork.CompleteAsync();

                    return Ok(distributorDTO);
                }

            }

            catch (Exception ex )
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("GetDistributorById")]
        public async Task<IActionResult> GetDistributorByIdAsync(int id)
        {
            var distributor = await _unitOfWork.Distributors.GetByIdAsync(id);
            if (distributor is null)
                return NotFound();

            return Ok(distributor);
        }

        [HttpDelete("DeleteDistributorByCode{code}")]
        public async Task<IActionResult> DeleteDistributorByIdAsync(Guid code)
        {
            var distributor = _unitOfWork.Distributors.Query().Where(x => x.DistributorCode == code).SingleOrDefault();
            var childs = _unitOfWork.Distributors.Query().Where(c => c.RecomendatorId == distributor.Id);
            
            // thisremove all child with parent
            foreach (var item in childs)
            {
                if (!distributor.ChildDistributors.Contains(item))
                    await _unitOfWork.Distributors.Delete(item);
            }

            if (distributor is null)
                return NotFound();

            await _unitOfWork.Distributors.Delete(distributor);
            await _unitOfWork.CompleteAsync();

            return Ok(distributor);
        }

        [HttpPut("UpdateDistributorByCode{id}")]
        public async Task<IActionResult> PutDistributorAsync(int id, [FromBody] Distributor distributorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (id != distributorDTO.Id)
                    return BadRequest();
                
                await _unitOfWork.Distributors.Update(distributorDTO);
                await _unitOfWork.CompleteAsync();

                return Ok(distributorDTO);
            }
            catch (Exception ex)
            {                
                return StatusCode(500, ex);
            }
        }
    }
}
