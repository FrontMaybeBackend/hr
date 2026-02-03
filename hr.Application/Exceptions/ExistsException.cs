namespace Application.Exceptions;

public sealed class ExistsException(string message) : Exception(message);
