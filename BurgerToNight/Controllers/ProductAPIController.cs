using AutoMapper;
using BurgerToNight.Models;
using BurgerToNight.Models.DTOs;
using BurgerToNight.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

namespace BurgerToNight.Controllers
{
	[Route("api/ProductAPI")]
	[ApiController]

	public class ProductAPIController : ControllerBase
	{
		protected APIResponse _response;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ProductAPIController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_response = new();
		}

		[HttpGet(Name ="GetBurgers")]
		public async Task<ActionResult<APIResponse>> GetBurgers()
		{
			try
			{
				IEnumerable<BurgerProduct> burgerList = await _unitOfWork.BProducts.GetAllAsync(includeProperties: "BurgerCategory");
				_response.Result = _mapper.Map<List<BProductGetDTO>>(burgerList);
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					 = new List<string>() { ex.ToString() };
			}
			return _response;
		}


		[HttpGet("{id:int}", Name = "GetBurger")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> GetBurger(int id)
		{
			try
			{
				if (id == 0)
				{
					_response.StatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				var burger = await _unitOfWork.BProducts.GetAsync(u=>u.Id==id);
				if (burger == null)
				{
					_response.StatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}
				_response.Result = _mapper.Map<BProductGetDTO>(burger);
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					 = new List<string>() { ex.ToString() };
			}
			return _response;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<APIResponse>> CreateProduct([FromBody] BProductPostDTO createDTO)
		{
			try
			{
				if (createDTO == null)
				{
					_response.IsSuccess = false;
					_response.ErrorMessages.Add("Invalid input data.");
					return BadRequest(_response);
				}

				if (await _unitOfWork.BProducts.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
				{
					ModelState.AddModelError("ErrorMessages", "Product already exists!");
					_response.IsSuccess = false;
					_response.ErrorMessages.Add("Product already exists.");
					return BadRequest(_response);
				}
				BurgerProduct burgerProduct = _mapper.Map<BurgerProduct>(createDTO);
				await _unitOfWork.BProducts.CreateAsync(burgerProduct);
				_response.Result = _mapper.Map<BProductGetDTO>(burgerProduct);
				_response.StatusCode = HttpStatusCode.Created;
				return CreatedAtRoute("GetBurger", new { id = burgerProduct.Id }, _response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					 = new List<string>() { ex.ToString() };
			}
			return _response;
		}
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpDelete("{id:int}", Name = "DeleteProduct")]
		public async Task<ActionResult<APIResponse>> DeleteProduct(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest();
				}
				var burger = await _unitOfWork.BProducts.GetAsync(u => u.Id == id);
				if (burger == null)
				{
					return NotFound();
				}
				await _unitOfWork.BProducts.RemoveAsync(burger);
				_response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				_response.Result = burger;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					 = new List<string>() { ex.ToString() };
			}
			return _response;
		}
		[HttpPut("{id:int}", Name = "UpdateProduct")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateProduct(int id, [FromBody] BProductUpdateDTO updateDTO)
        {
			try
			{
				if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }
                var model = _mapper.Map<BurgerProduct>(updateDTO);

                await _unitOfWork.BProducts.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				_response.Result = model;
				return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


    }
}
