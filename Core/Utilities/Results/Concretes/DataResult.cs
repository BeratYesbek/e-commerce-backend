using Core.Utilities.Results.Abstracts;

namespace Core.Utilities.Results.Concretes
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public DataResult(bool success, string message,T data) : base(success, message)
        {
            Data = data;
        }   

        public DataResult(bool success,T data) : base(success)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
