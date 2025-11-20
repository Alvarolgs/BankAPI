using System.Security.Claims;
using BankAPI.DTOs.BankAccount;
using BankAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("BankAPI/bankAccount")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByUserId()
        {
            var appUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            try
            {
                var result = await _bankAccountService.GetByUserId(appUserId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] RegisterBankAccountDto registerBankAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _bankAccountService.Create(registerBankAccountDto, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return result.IsSuccess ? Created(string.Empty, result.Value) : BadRequest(result.Error);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateBankAccountDto updateBankAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var result = await _bankAccountService.Update(userId, updateBankAccountDto);
                return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var result = await _bankAccountService.Delete(appUserId);
                return result.IsSuccess ? Ok() : BadRequest(result.Error);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}