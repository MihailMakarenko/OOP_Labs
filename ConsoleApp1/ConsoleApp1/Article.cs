namespace ConsoleApp1
{
    public class Article: IRateAndCopy
    {

        public Article()
        {
            Random random = new();
            PersonAuthor = new Person();
            NameArticle = "defaulNameArticle" + random.Next().ToString();
            RatingArticle = random.Next(0,10);
        }

        public Article(Person personAuthor, string nameArticle, double ratingArticle)
        {
            _personAuthor = personAuthor;
            _nameArticle = nameArticle;
            _ratingArticle = ratingArticle;
        }

        private Person _personAuthor;
        private string _nameArticle;
        private double _ratingArticle;

        public Person PersonAuthor
        {
            get
            {
                return _personAuthor;
            }
            set
            {
                _personAuthor = value;
            }
        }

        public string NameArticle
        {
            get
            {
                return _nameArticle;
            }
            set
            {
                _nameArticle = value;
            }
        }

        public double RatingArticle
        {
            get
            {
                return _ratingArticle;
            }
            set
            {
                _ratingArticle = value;
            }
        }

        public override string ToString()
        {
            string article = $"{_personAuthor.ToString()}\nНазвание статьи: {_nameArticle}\nРейтинг статьи: {_ratingArticle}\n\n";
            return article;
        }


        public double Rating
        {
            get
            {
                return _ratingArticle;
            }
        }

        public object DeepCopy()
        {
            return new Article(_personAuthor,_nameArticle,_ratingArticle);
        }
    }
}