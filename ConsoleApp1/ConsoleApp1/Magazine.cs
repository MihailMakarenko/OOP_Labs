using System.Collections;
using System.Security.AccessControl;

namespace ConsoleApp1
{
    public class Magazine : Edition, IRateAndCopy
    {

        public Magazine(string nameMagazine, List<Person> editors, Frequency frequency, DateTime releaseDate, int countMagazine, List<Article> articles) : base(nameMagazine, releaseDate, countMagazine)
        {
            _articles = articles;
            _frequency = frequency;
            _editors = editors;
        }

        private Frequency _frequency;
        private List<Article> _articles;
        private List<Person> _editors;


        public Frequency GetFrequency
        {
            get
            {
                return _frequency;
            }
        }

        public List<Article> Articles
        {
            get
            {
                return _articles;
            }
            set
            {
                _articles = value;
            }
        }

        public Edition GetEdition
        {
            get
            {
                return new Edition(NameCompany, PublishingTime, Circulation);
            }
            set
            {
                NameCompany = value.NameCompany;
                PublishingTime = value.PublishingTime;
                Circulation = value.Circulation;
            }
        }

        public double Rating
        {
            get
            {
                Article article;
                double sumRating = 0;
                foreach (var item in _articles)
                {
                    article = (Article)item;
                    sumRating += article.Rating;
                }
                return sumRating / _articles.Count;
            }
        }



        public void AddArticles(params Person[] articles)
        {
            foreach (var item in _articles)
            {
                _articles.Add(item);
            }
        }

        public override object DeepCopy()
        {
            List<Article> copyArticles = new List<Article>();
            for (int i = 0; i < _articles.Count; i++)
            {
                copyArticles.Add((Article)_articles[i].DeepCopy());
            }

            List<Person> copyEditors = new List<Person>();
            for (int i = 0; i < _editors.Count; i++)
            {
                copyEditors.Add((Person)_editors[i].DeepCopy());
            }

            return new Magazine(nameCompany, copyEditors, _frequency, PublishingTime, Circulation, copyArticles);
        }


        /*Вопрос по итератору*/
        public IEnumerator<Article> GetIterator(double rating)
        {
            foreach (var item in _articles)
            {
                Article article = (Article)item;
                if (article.Rating < rating)
                {
                    yield return article;
                }
            }
        }

        public IEnumerator<Article> GetIterator(string name)
        {
            foreach (var item in _articles)
            {
                Article article = (Article)item;
                string nameArticle = article.NameArticle;
                int index = nameArticle.IndexOf(name);
                if (index != -1)
                {
                    yield return article;
                }
            }
        }
        public override string ToString()
        {
            string str = base.ToString();
            str += "\n\n";
            for (int i = 0; i < _articles.Count; i++)
            {
                str += _articles[i].ToString();
            }
            str += "\n";
            return str;
        }

        public string ToShortString()
        {
            string str = "Журнал: \n";
            str = base.ToString();
            str += "\n\n";
            str += "Средний рейтинг: " + _articles.Average(x => x.RatingArticle);
            str += "\n";
            str += "Колличество сатей: " + _articles.Count;
            str += "\n";
            str += "Колличество редакторов: " + _editors.Count;
            str += "\n\n";
            return str;
        }
    }
}
