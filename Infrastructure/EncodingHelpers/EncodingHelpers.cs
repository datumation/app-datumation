using System.IO;
using System.Net;

namespace app_datumation.Infrastructure.EncodingHelpers
{
    public class EncodingHelpers
    {
        public byte[] ConvertToBytes(WebResponse response, MemoryStream memStream)
        {
            byte[] retVal;
            Stream response_stream = response.GetResponseStream();
            response_stream.CopyTo(memStream);
            byte[] pdf_bytes = memStream.ToArray();
            retVal = pdf_bytes;
            response.Close();
            response.Dispose();
            return retVal;
        }
    }
}