using BankAPI.DTOs.Client;
using BankAPI.Helpers;
using BankAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("BankAPI/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterClientDto registerClientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _clientService.Create(registerClientDto);
                return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result.Error);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _clientService.GetAll();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _clientService.GetById(id);
                return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetById([FromBody] string email)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
//
        //    try
        //    {
        //        var result = await _clientService.GetByEmail(email);
        //        return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result.Error);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(new {message = ex.Message});
        //    }
        //}

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UpdateClientDto updateClientDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _clientService.Update(id, updateClientDto);
                return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _clientService.Delete(id);
                return result.IsSuccess ? Ok() : BadRequest(result.Error);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}