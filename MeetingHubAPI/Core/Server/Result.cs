using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Server
{
    /// <summary>
    /// Result Mimarisi
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : IResult<T>
    {
        public bool Success { get; }
        public string Message { get; private set; }
        public T Data { get; }

        public Result(T data, bool success, string message)
        {
            this.Data = data;
            this.Success = success;
            this.Message = message;
        }

        public void UpdateMessage(string newMsg)
        {
            this.Message = newMsg;
        }
    }

    public class SuccessResult<T> : Result<T>
    {
        public SuccessResult(T data, string message)
            : base(data, true, message)
        {

        }
    }

    public class ErrorResult<T> : Result<T>
    {
        public ErrorResult(T data, string message)
            : base(data, false, message)
        {

        }
    }
}
