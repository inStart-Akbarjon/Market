using Market.Application.Exceptions.Abstract;

namespace Market.Application.Exceptions.Product;

public class InvalidRequestException : AppException
{
    public InvalidRequestException(string message) : base($"Validation error: {message}")
    {
    }

    public InvalidRequestException(string propertyName, string propertyValue) : base($"Validation error: Product with {propertyName} {propertyValue} already exists!")
    {
    }
}