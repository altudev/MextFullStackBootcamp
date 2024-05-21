namespace MextFullstackSaaS.Domain.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
