namespace Domain
{
    public enum ProductCategory
    {
        Laptops = 11,
        Books = 22,
    }

    public static class ProductCategoryExtension
    {
        public static IEnumerable<string> ProductCategories = Enum.GetValues<ProductCategory>().Cast<string>();
    }
}
