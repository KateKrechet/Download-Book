using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Music
{
    static class SiteToStringcs
    {
        public static string GetSite(string URL)//static позволяет не создавать экземпляры
        {
            WebRequest webRequest = WebRequest.Create(URL);//запрос сервера
            WebResponse webResponse = webRequest.GetResponse();//ответ сервера
            //получить поток данных с сервера
            Stream stream = webResponse.GetResponseStream();
            //записать результат
            StreamReader streamReader = new StreamReader(stream);
            string result = streamReader.ReadToEnd();
            return result;

        }

    }
}
