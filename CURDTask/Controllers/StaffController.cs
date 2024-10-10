using Application.Common;
using Application.DTO;
using Application.Services;
using Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CURDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffSetrvices _staffSetrvices;
        protected APIResponse _apiResponse;

        public StaffController(IStaffSetrvices staffSetrvices)
        {
            _staffSetrvices = staffSetrvices;
            _apiResponse = new APIResponse();

        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody] CreateStaffDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                 
                    _apiResponse.AddError(ModelState.ToString());
                    return Ok(_apiResponse);
                }
                var entity = await _staffSetrvices.CreateAsync(dto);
                _apiResponse.StatusCode = HttpStatusCode.Created;
                _apiResponse.IsSuccess = true;
               
                _apiResponse.Result = entity;
            }
            catch (Exception)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
              
            }


            return Ok(_apiResponse);


        }


        [HttpPut]
        public async Task<ActionResult<APIResponse>> Update([FromBody] UpdateStaffDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    
                    _apiResponse.AddError(ModelState.ToString());
                    return Ok(_apiResponse);
                }
                await _staffSetrvices.UpdateAsync(dto);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
               
            }
            catch (Exception)
            {

                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
               

            }


            return Ok(_apiResponse);


        }


        [HttpDelete]

        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                   
                    _apiResponse.AddError(ModelState.ToString());
                    return Ok(_apiResponse);
                }
                var products = await _staffSetrvices.GetByIdAsync(id);
                if (products == null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                   
                    _apiResponse.AddError(ModelState.ToString());
                    return Ok(_apiResponse);
                }

                await _staffSetrvices.DeleteAsync(id);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                
            }
            catch (Exception)
            {
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
               
                _apiResponse.AddError(ModelState.ToString());

            }



            return Ok(_apiResponse);


        }



        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {

            try
            {
                var product = await _staffSetrvices.GetByIdAsync(id);
                if (product == null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                   
                    return Ok(_apiResponse);
                }
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.IsSuccess = true;
                _apiResponse.Result = product;
            }
            catch (Exception)
            {

                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
               

            }



            return Ok(_apiResponse);


        }


        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {

            try
            {
                var products = await _staffSetrvices.GetAllAsync();
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.IsSuccess = true;
                _apiResponse.Result = products;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
               
            }


            return Ok(_apiResponse);


        }
    }
}
