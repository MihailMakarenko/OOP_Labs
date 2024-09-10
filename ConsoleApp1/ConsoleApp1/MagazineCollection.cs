using System;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class MagazineCollection
    {
        private List<Magazine> _magazines;

        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);
        public string NameCollection { get; set; }

        public MagazineCollection()
        {
            _magazines = new List<Magazine>();
        }

        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;

        bool Replace(int j, Magazine mg)
        {
            if (_magazines == null || j < 0 || j > _magazines.Count - 1)
            {
                return false;
            }
            else
            {
                _magazines[j] = mg;
                OnMagazineReplaced(j);
                return true;
            }
        }

        public void AddMagazine(Magazine magazine)
        {
            _magazines.Add(magazine);
            OnMagazineAdded(magazine, _magazines.Count - 1);
        }

        public void ReplaceMagazine(int index, Magazine magazine)
        {
            if (index < 0 || index >= _magazines.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            _magazines[index] = magazine;
            OnMagazineReplaced(index);
        }

        protected virtual void OnMagazineAdded(Magazine magazine, int index)
        {
            MagazineAdded?.Invoke(this, new MagazineListHandlerEventArgs(magazine.NameCompany, $"Добавлен журнал: {magazine.NameCompany}", index));
        }

        protected virtual void OnMagazineReplaced(int index)
        {
            MagazineReplaced?.Invoke(this, new MagazineListHandlerEventArgs(_magazines.Count.ToString(), $"Заменен журнал на позиции {index}", index));
        }

        public Magazine this[int index]
        {
            get
            {
                return _magazines[index];
            }
            set
            {
                if (index >= 0 || index < _magazines.Count)
                {
                    _magazines[index] = value;
                    OnMagazineReplaced(index);
                }
            }
        }

        public void AddDefaults()
        {
            Random random = new Random();

            // Добавляем несколько объектов Magazine по умолчанию
            AddMagazine(new Magazine
            (
                "NUNUNUNU",
                [new Person(), new Person()],
                Frequency.Monthly,
                new DateTime(2019, 5, 1),
                random.Next(),
                [new Article(), new Article()]
            ));

            AddMagazine(new Magazine
           (
               "Lalalalal",
               [new Person(), new Person()],
               Frequency.Yearly,
               new DateTime(2020, 5, 1),
               random.Next(),
               [new Article(), new Article()]
           ));

            AddMagazine(new Magazine
          (
              "BEBEBEBEB",
              [new Person(), new Person()],
              Frequency.Weekly,
              new DateTime(2023, 10, 12),
              random.Next(),
              [new Article(), new Article()]
          ));

           
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            foreach (var magazine in magazines)
            {
                AddMagazine(magazine);
            }
        
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var magazine in _magazines)
            {
                sb.AppendLine(magazine.ToString());
            }
            return sb.ToString();
        }

        public string ToShortString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var magazine in _magazines)
            {
                sb.AppendLine(magazine.ToShortString());
            }
            return sb.ToString();
        }

        public void SortByName()
        {
            _magazines.Sort((x, y) =>
            {
                return x.CompareTo(y);
            });
        }

        public void SortByDate()
        {
            _magazines.Sort((x, y) =>
            {
                return x.Compare(x, y);
            });
        }

        public void SortByCirculation()
        {
            HelpClass helpClass = new HelpClass();
            _magazines.Sort((x, y) =>
            {
                return helpClass.Compare(x, y);
            });
        }

        public double MaxAverageRating
        {
            get
            {
                return _magazines.Any() ? _magazines.Max(m => m.Rating) : 0.0;
            }
        }

        public IEnumerable<Magazine> MonthlyMagazines
        {
            get
            {
                return _magazines.Where(m => m.GetFrequency == Frequency.Monthly);
            }
        }

        public List<Magazine> RatingGroup(double value)
        {
            return _magazines.Where(m => m.Rating >= value).ToList();
        }
    }
}