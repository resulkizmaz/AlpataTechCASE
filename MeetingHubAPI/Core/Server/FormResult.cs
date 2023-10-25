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
    public class FormResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<MessageResult> Responds { get; set; }

        public FormResult(bool success, string message, T data, List<MessageResult> responds)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
            this.Responds = responds;
        }
    }
}
