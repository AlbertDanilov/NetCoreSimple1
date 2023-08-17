using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace NetCoreSimple1.Helpers
{
    public static class WebHelper
    {
        public static R WebRequest<T, R>(string apiController, T data) where R : new()
        {
            try
            {
                string rez = string.Empty;
                R rez_content = new R();
                string json = string.Empty;
                MemoryStream stream = new MemoryStream();

                if (data != null)
                {
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
                    deserializer.WriteObject(stream, data);
                    stream.Position = 0;

                    StreamReader sr = new StreamReader(stream);
                    json = sr.ReadToEnd();
                }

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{Helpers.BaseHelper.programLogsConnectionString}/api/{apiController}");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.MediaType = "HTTP/1.1";
                request.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");

                if (data != null)
                {
                    Stream str = request.GetRequestStream();
                    if (str != null)
                    {
                        str.Write(Encoding.UTF8.GetBytes(json), 0, Encoding.UTF8.GetBytes(json).Length);
                    }
                    str.Close();
                }
                else
                {
                    request.ContentLength = 0;
                }

                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse()) 
                {
                    StreamReader streamReader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                    rez = streamReader.ReadToEnd();
                    streamReader.Close();
                    resp.Close();
                    streamReader.Dispose();
                }
                
                if (rez == null) { return default(R); }

                MemoryStream stream2 = new MemoryStream(Encoding.Unicode.GetBytes(rez));
                DataContractJsonSerializer deserializer2 = new DataContractJsonSerializer(typeof(R));
                rez_content = (R)deserializer2.ReadObject(stream2);
                stream.Close();

                return rez_content;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);

                return default(R);
            }            
        }
    }
}
