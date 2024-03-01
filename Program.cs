using System.Security.Principal;
using AulasAi.Search;

var list = new List<float>() {
    1, 2, 3, 5, 7, 8, 9
};

var sold = Search.BinarySearch(list, 0);
System.Console.WriteLine(sold);


foreach (var item in list)
{
    var sol = Search.BinarySearch(list, item);
    System.Console.WriteLine(sol);
}
