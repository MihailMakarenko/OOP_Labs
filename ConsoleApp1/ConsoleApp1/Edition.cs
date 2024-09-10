namespace ConsoleApp1
{
    public class Edition : IComparable, IComparer<Edition>
    {
        public Edition(string nameCompany, DateTime publishingTime, int circulation)
        {
            NameCompany = nameCompany;
            PublishingTime = publishingTime;
            Circulation = circulation;
        }

        protected string nameCompany;
        private DateTime _publishingTime;
        private int _circulation;

        public string NameCompany
        {
            get
            {
                return nameCompany;
            }
            set
            {
                nameCompany = value;
            }
        }

        public DateTime PublishingTime
        {
            get
            {
                return _publishingTime;
            }
            set
            {
                _publishingTime = value;
            }
        }

        public int Circulation
        {
            get
            {
                return _circulation;
            }
            set
            {
                if (value < 0)
                {
                    // возможно нужно переделать
                    throw new ArgumentException("Тираж не может быть отрицательным");
                }
                else
                {
                    _circulation = value;
                }
            }
        }

        public virtual object DeepCopy()
        {
            return new object();
        }

        public override string ToString()
        {
            string str = $"Название издаения: {nameCompany}\nДата публикации: {_publishingTime}\nТираж: {_circulation}";
            return str;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            Edition edition = (Edition)obj;
            if (edition.NameCompany == nameCompany &&
                edition.PublishingTime == _publishingTime &&
                edition.Circulation == _circulation)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() / 2;
        }

        public int CompareTo(object? obj)
        {
            Edition edition = (Edition)obj;
            return nameCompany.CompareTo(edition.NameCompany);
        }

        public int Compare(Edition x, Edition y)
        {
            if (x is null && y is null)
                return 0;
            else if (x is null)
                return -1;
            else if (y is null)
                return 1;
            else
                return x._publishingTime.CompareTo(y._publishingTime);
        }

        public static bool operator ==(Edition left, Edition right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Edition left, Edition right)
        {
            return !(left == right);
        }

        public static bool operator <(Edition left, Edition right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Edition left, Edition right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Edition left, Edition right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Edition left, Edition right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
