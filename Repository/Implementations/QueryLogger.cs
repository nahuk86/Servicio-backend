using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class QueryLogger : IQueryLogger
    {
        public void Log(string message)
        {
            // Simple console logging, replace with real logging
            Console.WriteLine($"[Query] {message}");
        }
    }
}
