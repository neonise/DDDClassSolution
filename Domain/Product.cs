using System.Drawing;

namespace Domain
{
    public class Product
    {
        private Product()
        {

        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public long Price { get; private set; }
        public Color Color { get; private set; }
        public CurrencyType Currency { get; private set; }
        public ProductType ProductType { get; private set; }

        public static Product Create(
            string name,
            string code,
            ProductType productType,
            Color color,
            CurrencyType currency,
            long price
            )
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (price is 0 or > 100000000)
                throw new InvalidDataException(nameof(price));

            CheckCodeRules(code);

            return new Product
            {
                Code = code,
                Color = color,
                Currency = currency,
                Name = name,
                Price = price,
                ProductType = productType
            };
        }

        private static void CheckCodeRules(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code));

            if (code.Trim().Length != 10)
                throw new InvalidDataException("code len is invalid");

            if (IsNumberCode(code))
                throw new InvalidDataException("code is invalid");

            if (!IsValidCountryCode(code))
                throw new InvalidDataException("code doesn't start by country code");

            if (!IsValidCategoryCode(code))
                throw new InvalidDataException("code doesn't start by category code");
        }

        private static bool IsValidCountryCode(string code)
        {
            var countryCode = code.Substring(0, 2);
            return CountryCodeExtension.CountryCodes.Contains(countryCode);
        }

        private static bool IsValidCategoryCode(string code)
        {
            var categoryCode = code.Substring(1, 2);
            return ProductCategoryExtension.ProductCategories.Contains(categoryCode);
        }

        private static bool IsNumberCode(string code)
        {
            return long.TryParse(code, out _);
        }
    }
}