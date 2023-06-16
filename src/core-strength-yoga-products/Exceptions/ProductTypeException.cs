namespace core_strength_yoga_products.Exceptions
{
    public class ProductTypeException : Exception
    {
       public ProductTypeException(Exception exception) : 
            base($"Could not retrieve Product Types from API", exception)
       { 
            
       }    
    }
}
