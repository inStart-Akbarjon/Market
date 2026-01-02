using System.Runtime.Serialization;

namespace Market.Application.Exceptions.Abstract;

public abstract class AppException(string? message) : Exception(message)
{
}