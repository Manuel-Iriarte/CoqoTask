using CoqoTask.Application.Common;

namespace CoqoTask.Application.Interfaces
{
    public interface IConvertRomanNumberToDecimalQuery
    {
        Result Execute(string number);
    }
}
