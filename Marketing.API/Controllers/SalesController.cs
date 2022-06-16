using AutoMapper;
using Marketing.Domain.DTO;
using Marketing.Domain.Entities;
using Marketing.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SalesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllSalesAsync")]
        public async Task<IActionResult> GetAllSalesAsync()
        {
            var result = await _unitOfWork.Sales.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("AddSalesAsync")]
        public async Task<IActionResult> AddSalesAsync([FromBody] SalesDTO salesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sales = _mapper.Map<Sales>(salesDTO);
                var distributor = await _unitOfWork.Distributors.GetSalesDistributorId(salesDTO);
                if (distributor != null) { sales.DistributorId = distributor.Id; }
                else { sales.DistributorId = null; };
                sales.SalesCode = Guid.NewGuid();

                await _unitOfWork.Sales.AddAsync(sales);
                await _unitOfWork.CompleteAsync();

                return Ok(salesDTO);
            }

            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        [HttpGet("GetSalesBonus{startDate},{endDate}")]
        public async Task<IActionResult> GetSalesBonus(DateTime startDate, DateTime endDate)
        {
            var TotalSold = await _unitOfWork.Sales.Query()
               .Where(d => d.DateSold >= startDate && d.DateSold <= endDate)
               .Include(x => x.Distributor)
              .ToListAsync();

            //I had no timee :(
          
            return Ok(TotalSold);
        }
    }
}
