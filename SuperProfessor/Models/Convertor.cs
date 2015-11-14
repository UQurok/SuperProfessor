using SuperProfessor.Storages;
namespace SuperProfessor.Models
{
    public class Convertor
    {
        public static LecturesModel Convert(NewsModel obj)
        {
            LecturesModel res = new LecturesModel();
            res.text = obj.text;
            res.title = obj.title;
            return res;
        }
        public static NewsModel Convert(LecturesModel obj)
        {
            NewsModel res = new NewsModel();
            res.id = -1;
            res.text = obj.text;
            res.title = obj.title;
            res.likes = 0;
            return res;
        }
    }
}