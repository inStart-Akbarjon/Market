using System.Net;
using Market.Application.Exceptions.Abstract;

namespace Market.Application.Exceptions.Product;

public class NotFoundException(string message) : AppException(message)
{
}