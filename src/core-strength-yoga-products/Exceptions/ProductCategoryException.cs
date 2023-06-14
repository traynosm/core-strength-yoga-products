namespace core_strength_yoga_products.Exceptions
{
    public class ProductCategoryException : Exception
    {
        public ProductCategoryException(Exception exception) :
            base($"Could not retrieve Product Category from API", exception)
        {

        }
    }
}
