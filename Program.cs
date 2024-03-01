using AulasAi.Search;

var list = new List<float>() {
    1, 2, 3, 5, 7, 8, 9
};

var sol = Search.BinarySearch(list, 1);

System.Console.WriteLine(sol);
foreach (var item in list)
{
    // System.Console.WriteLine(item);
}
