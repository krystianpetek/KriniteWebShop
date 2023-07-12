namespace KriniteWebShop.WebUI.Blazor.Helpers;

public static class LinqExtensions
{
    public static T RandomElement<T>(this IEnumerable<T> collection)
    {
        int elementsInCollection = 0;
        if (!collection.TryGetNonEnumeratedCount(out elementsInCollection))
            elementsInCollection = collection.Count();

        Random random = new Random();
        var randomNumber = random.Next(0, elementsInCollection);

        return collection.ElementAt(randomNumber);
    }
}
