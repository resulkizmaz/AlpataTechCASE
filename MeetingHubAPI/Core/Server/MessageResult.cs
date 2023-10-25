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
    public class MessageResult
    {
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public bool Success { get; set; }

        public MessageResult(bool success, string messageCode, string message)
        {
            this.Message = message;
            this.MessageCode = messageCode;
            this.Success = success;
        }
    }
}
