namespace SuperProfessor.Storages
{
    using SuperProfessor.Models;
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;
    public class NewsStorage
    {
        List<NewsModel> AllNews;
        int NewsCount;
        XDocument xDoc;
        XElement xRoot;

        public NewsStorage() {      

            AllNews = new List<NewsModel>();
            NewsCount = 0;
            NewsModel news = new NewsModel();

            xDoc = XDocument.Load("news.xml");
            xRoot = xDoc.Element("news");

            foreach (XElement element in xDoc.Element("news").Elements("news"))
            {
                news.id = Int32.Parse(element.Attribute("id").Value); ;
                news.title = element.Element("title").Value;
                news.text = element.Element("text").Value;
                news.likes = Int32.Parse(element.Element("likes").Value);
                
                if (news.id > 0)
                {
                    NewsCount = news.id;
                    AllNews.Add(news);
                }
            }       
    
        }

        public void AddNews(NewsModel news)
        {
            NewsCount++;
            news.id = NewsCount;
            AllNews.Add(news);

            xRoot.Add(new XElement("news",
                      new XAttribute("id", news.id),
                      new XElement("title", news.title),
                      new XElement("text", news.text),
                      new XElement("likes", news.likes)));
            xDoc.Save("news.xml");

        }

        public void RemoveNews(NewsModel news)
        {
            NewsCount--;
            AllNews.Remove(news);

            foreach (XElement element in xDoc.Element("news").Elements("news"))
            {
                if (element.Attribute("id").Value == news.id.ToString())
                {
                    element.Remove();
                }
            }
            xDoc.Save("news.xml");

        }
    }
}