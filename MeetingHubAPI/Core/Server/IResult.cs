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
    public interface IResult<T>
    {
        bool Success { get; }
        string Message { get; }
        T Data { get; }

        void UpdateMessage(string newMsg);
    }
}
