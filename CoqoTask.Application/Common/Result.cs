namespace CoqoTask.Application.Common
{
    public class Result
    {
        public bool Ok { get; set; } = false;
        public dynamic? ReturnValue { get; set; }
        public ResultCode ResultCode { get; set; }
    }

    public class Result<T> : Result 
        where T : class, new()
    {
        public T ReturnObject { get; set; } = new T();
    }

    public enum ResultCode
    {
        Success,
        Unauthorized,
        BadRequest
    }
}