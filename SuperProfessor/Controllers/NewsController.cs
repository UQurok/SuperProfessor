namespace SuperProfessor.Controllers
{
    using SuperProfessor.Models;
    using SuperProfessor.Storages;
    using System;
    using System.IO;
    using System.Net;
    using System.Web.Http;
    using System.Xml.Linq;

    [RoutePrefix("news")]
    public class NewsController : ApiController
    {
        NewsStorage AllNews;
        public NewsController()
        {
            AllNews = new NewsStorage();
        }

        [Route("")]
        [HttpGet]
        public NewsModel GetAllNews()
        {
            throw new NotImplementedException();
        }

        [Route("popular")]
        [HttpGet]
        public NewsModel GetPopular()
        {
            throw new NotImplementedException();
        }

        [Route("like")]
        [HttpPost]
        public NewsModel Like()
        {
            throw new NotImplementedException();
        }

        [Route("create")]
        [HttpPost]
        public LecturesModel CreateLecture([FromUri] string param)
        {
            WebRequest reqGET = WebRequest.Create(@"https://referats.yandex.ru/referats/write/?t=mathematics");
            WebResponse resp = reqGET.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string s = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + "<response>" + sr.ReadToEnd() + "</response>";
            var xRoot = XElement.Parse(s);


            LecturesModel lect = new LecturesModel();
            lect.title = xRoot.Element("strong").Value;
            lect.text = xRoot.Element("p").Value;
            AllNews.AddNews(Convertor.Convert(lect));
            return lect;
        }
    }
}
