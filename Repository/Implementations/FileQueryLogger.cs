using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class FileQueryLogger : IQueryLogger
    {
        private static readonly string LogPath = Path.Combine(AppContext.BaseDirectory, "queries.log");

        public void Log(string message)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}";
            File.AppendAllText(LogPath, line + Environment.NewLine);
        }
    }
}
