/*using ConsoleApp1;
*//*Первый пункт*//*
Article[] articles = { new Article(), new Article() };
Magazine magazine = new Magazine("Новый",Frequency.Weekly,DateTime.Now,15, articles);
Console.WriteLine(magazine.ToShortString());
Console.WriteLine();
*//*второй пункт*//*
Console.WriteLine(magazine[Frequency.Weekly]);
Console.WriteLine(magazine[Frequency.Monthly]);
Console.WriteLine(magazine[Frequency.Yearly]);
Console.WriteLine();
*//*третий пункт*//*
magazine.CountMagazine = 999;
magazine.NameMagazine = "Тестовый";
magazine.ReleasedDate = DateTime.Now;
magazine.frequencyMagazine = Frequency.Monthly;
Article[] articles1 = { new Article(new Person(), "какая то статья", 753)};
magazine.Articles = articles1;
Console.WriteLine(magazine.ToString());
*//*четрвертый пункт*//*
magazine.AddArticles(new Article(new Person(), "ещё одна статья", 666));
Console.WriteLine();
Console.WriteLine(magazine.ToString());*/


/*using ConsoleApp1;
using System.Collections;

Edition edition = new Edition("Новый", DateTime.Now, 15);
Edition edition1 = new Edition("Новый", DateTime.Now, 15);
Console.WriteLine("Проверяем одинковые ли поля у двух разных екземпляров" + edition.Equals(edition));
Console.WriteLine("Первый хэш:" + edition.GetHashCode());
Console.WriteLine("Второй хэш" + edition1.GetHashCode());
try
{
    edition.Circulation = -1;
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
ArrayList arrayList = [new Person("Редактор1", "Редактор2Фамилия", DateTime.Now)];
ArrayList articles = [new Article(new Person("Автор1","Автор1Фамилия",DateTime.Now),"Статья1",5), new Article(new Person("Автор2", "Автор2Фамилия", DateTime.Now), "Статья2", 5)];
Magazine magazine = new Magazine("Лучший магазин", arrayList,Frequency.Monthly,DateTime.Now,15,articles);
Console.WriteLine(magazine.ToString());
Console.WriteLine(magazine.GetEdition);
Magazine magazine1 = (Magazine)magazine.DeepCopy();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine(magazine1.ToString());
Console.WriteLine();
Console.WriteLine();
Console.BackgroundColor = ConsoleColor.Red;
Console.WriteLine("Изменяем массив");
Console.BackgroundColor = ConsoleColor.Black;
magazine.Circulation = 666;
magazine.Articles = [new Article()];
Console.WriteLine(magazine.ToString());
Console.WriteLine();
Console.WriteLine();
Console.WriteLine(magazine1.ToString());
Article article;
Console.WriteLine("Итератор");
IEnumerator<Article> iterator = magazine1.GetIterator(10);
while (iterator.MoveNext())
{
    Article article2 = iterator.Current;
    Console.WriteLine(article2.ToString());
}
Console.WriteLine("Итератор2 ");
iterator = magazine1.GetIterator("1");
while (iterator.MoveNext())
{
    Article article2 = iterator.Current;
    Console.WriteLine(article2.ToString());
}*/


using ConsoleApp1;
using System;
using System.Collections;
/*Console.WriteLine("ПЕРВЫЙ ПУНКТ!!!!!!!!!!!!!!!!!!!!!!!");
Console.WriteLine("____________________________________");
MagazineCollection magazineCollection = new MagazineCollection();
magazineCollection.AddDefaults();
Console.WriteLine(magazineCollection.ToString());

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("ВТОРОЙ ПУНКТ!!!!!!!!!!!!!!!!!!!!!!!");
Console.WriteLine("____________________________________");
magazineCollection.SortByName();
Console.WriteLine("СОРТИРОВКА ПО ИМЕНИ");
Console.WriteLine("____________________________________");
Console.WriteLine(magazineCollection.ToShortString());
magazineCollection.SortByDate();
Console.WriteLine("____________________________________");
Console.WriteLine("СОРТИРОВКА ПО ДАТЕ");
Console.WriteLine("____________________________________");
Console.WriteLine(magazineCollection.ToShortString());
magazineCollection.SortByCirculation();
Console.WriteLine("____________________________________");
Console.WriteLine("СОРТИРОВКА ПО Колличеству");
Console.WriteLine("____________________________________");
Console.WriteLine(magazineCollection.ToShortString());

Console.WriteLine("Третий ПУНКТ!!!!!!!!!!!!!!!!!!!!!!!");
Console.WriteLine("____________________________________");

Console.WriteLine("ПЕРВАЯ ЧАСТЬ");
Console.WriteLine("Максимальное среднее значение рейтинга: " + magazineCollection.MaxAverageRating);
Console.WriteLine("____________________________________");
Console.WriteLine("ВТОРАЯ ЧАСТЬ");
IEnumerable<Magazine> monthlyMagazines = magazineCollection.MonthlyMagazines;

// Использование коллекции monthlyMagazines
foreach (var magazine in monthlyMagazines)
{
    Console.WriteLine(magazine.ToShortString());
}
Console.WriteLine("____________________________________");
Console.WriteLine("ТРЕТЬЯ ЧАСТЬ");
List<Magazine> magazines2 = magazineCollection.RatingGroup(4);
foreach (var magazine in magazines2)
{
    Console.WriteLine(magazine.ToShortString());
}
Console.WriteLine("____________________________________");
Console.WriteLine("ЧЕТВЕРТЫЙ ПУНКТ!!!!!!!!!!!!!!!!!!!!!!!!!!!");
TestCollections testCollections = new TestCollections(2000);
Console.WriteLine("Первое значение");
testCollections.MeasurePerformance(testCollections.GetEditions[0], testCollections.GetStrings[0]);
Console.WriteLine("Последнее значение");
testCollections.MeasurePerformance(testCollections.GetEditions[1999], testCollections.GetStrings[1999]);
Console.WriteLine("Посередине");
testCollections.MeasurePerformance(testCollections.GetEditions[1000], testCollections.GetStrings[1000]);
Edition edition = testCollections.GetEditions[1999];
String str = testCollections.GetStrings[1999];
Console.WriteLine("Значение которого нет");
testCollections.MeasurePerformance(edition, str);

*/


Console.WriteLine("ПЕРВЫЙ ПУНКТ!!!!!");
MagazineCollection magazineCollection = new MagazineCollection();
magazineCollection.AddDefaults();
MagazineCollection magazineCollectionTwo = new MagazineCollection();
magazineCollectionTwo.AddDefaults();

Listener listener = new Listener();
Listener listenerTwo = new Listener();

magazineCollection.MagazineAdded += listener.OnMagazineAdded;
magazineCollection.MagazineReplaced += listener.OnMagazineReplaced;

magazineCollectionTwo.MagazineAdded += listenerTwo.OnMagazineAdded;  
magazineCollectionTwo.MagazineReplaced += listenerTwo.OnMagazineReplaced;
Random random = new Random();
magazineCollection.AddMagazines(new Magazine("Добавление1",[new Person(), new Person()],Frequency.Monthly,new DateTime(1111, 1, 1),random.Next(),[new Article(), new Article()])) ;
magazineCollection[1] = new Magazine("Добавление2", [new Person(), new Person()], Frequency.Monthly, new DateTime(7777, 7, 7), random.Next(), [new Article(), new Article()]);


magazineCollectionTwo.AddMagazines(new Magazine("Добавление2", [new Person(), new Person()], Frequency.Monthly, new DateTime(2222, 2, 2), random.Next(), [new Article(), new Article()]));
magazineCollectionTwo.ReplaceMagazine(2,new Magazine("Замена2", [new Person(), new Person()], Frequency.Monthly, new DateTime(9999, 9, 9), random.Next(), [new Article(), new Article()]));
Console.WriteLine("Первый слушатель");
Console.WriteLine(listener.ToString());
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Второй слушатель");
Console.WriteLine(listenerTwo.ToString());
