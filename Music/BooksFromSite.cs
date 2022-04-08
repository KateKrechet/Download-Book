using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class BooksFromSite
    {
        public List<string> Names;
        public List<string> URLs;//ссылки для скачивания

        public BooksFromSite()
        {
            Names = new List<string>();
            URLs = new List<string>();

        }
        public void Refresh(string site)
        {
            Names = new List<string>();
            URLs = new List<string>();
            //indexof - находит данную строчку в массиве букв
            //возвращает ее индекс, посчитает сколько букв было до нужной буквы
            int index = site.IndexOf("href=\"/b");
            while(index!=-1)
            {
                site = site.Remove(0, index + 7);//удалили до и сам href
                string url = site.Remove(site.IndexOf("/"));//удалили, что после
                URLs.Add(url);

                index = site.IndexOf(">");
                site = site.Remove(0, index + 1);//удалили до и сам href
                string name = site.Remove(site.IndexOf("<"));//удалили, что после
                Names.Add(name);

                index = site.IndexOf("href=\"/b");
            }
        }

    }
}
