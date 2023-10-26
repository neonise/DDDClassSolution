namespace Domain
{
    public enum CountryCode
    {
        Iran = 98,
        USA = 88,
        UAE = 44
    }

    public static class CountryCodeExtension
    {
        public static IEnumerable<string> CountryCodes = Enum.GetValues<CountryCode>().Cast<string>();
    }
}
