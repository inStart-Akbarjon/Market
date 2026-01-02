using System.Net;
using Market.Application.Exceptions.Abstract;

namespace Market.Application.Exceptions.Product;

public class NotFoundException(int Id) : AppException($"Product with id {Id} not found!")
{
}