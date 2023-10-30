using CoqoTask.Application.Common;
using CoqoTask.Application.Interfaces;
using CoqoTask.Domain;

namespace CoqoTask.Application.Queries
{
    public class ConvertRomanNumberToDecimalQuery : IConvertRomanNumberToDecimalQuery
    {
        public ConvertRomanNumberToDecimalQuery()
        {
                
        }
        public Result Execute(string number)
        {
            var result = new Result();
            var numberProcessed = new ImageNumber();

            if (string.IsNullOrEmpty(number))
                result.ResultCode = ResultCode.BadRequest;

            numberProcessed.RomanToDecimal(number);

            result.ReturnValue = numberProcessed.Value;

            return result;
        }
    }
}
