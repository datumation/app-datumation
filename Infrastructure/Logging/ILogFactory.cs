using System;

namespace app_datumation.Infrastructure.Logging
{
    public interface ILogFactory
    {
        void WriteMessage(string msg);

        void WriteMessage(string msg, Exception ex);

        void GenerateEmail(string subject, string body);
    }
}