using CoqoTask.Application.Common;
using CoqoTask.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoqoTask.Api.ConversionServices.Controllers.v1
{
    [Route("api/v1/conversions")]
    [ApiController]
    public class ConversionsController : ControllerBase
    {
        private readonly IConvertRomanNumberToDecimalQuery _convertRomanNumberToDecimalQuery;
        public ConversionsController(IConvertRomanNumberToDecimalQuery convertRomanNumberToDecimalQuery)
        {
            _convertRomanNumberToDecimalQuery = convertRomanNumberToDecimalQuery;
        }

        [HttpGet("roman-to-decimal/{romanNumber}")]
        public ActionResult<decimal> RomanToDecimal([FromRoute] string romanNumber)
        {
            var result = _convertRomanNumberToDecimalQuery.Execute(romanNumber);

            if (result.ResultCode == ResultCode.Unauthorized)
                return Unauthorized();

            if (result.ResultCode == ResultCode.BadRequest)
                return BadRequest();

            return Ok(result);
        }
    }
}
