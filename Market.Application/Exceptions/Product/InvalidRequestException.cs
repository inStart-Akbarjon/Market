using Market.Application.Exceptions.Abstract;

namespace Market.Application.Exceptions.Product;

public class InvalidRequestException(string message) : AppException($"Validation error: {message}")
{
    
}