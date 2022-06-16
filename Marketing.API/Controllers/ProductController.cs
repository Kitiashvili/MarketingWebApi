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

namespace Marketing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllProductAsync")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await _unitOfWork.Products.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("AddProductAsync")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<Product>(productDTO);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return Ok(productDTO);

        }

    }
}
