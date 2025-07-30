﻿namespace MPeyghoom.Configuration.Result;

public record Error
{
    public string? Code { get; }
    public string? Message { get; }
    public ErrorType ErrorType { get; }
    
    public Error(string? code, string? message, ErrorType errorType)
    {
        ErrorType = errorType;
        Message = message;
        Code = code;
    }
    
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

    public static Error NotFound(string message = "The entity was not found!",string code = "1" ) =>
        new (code, message, ErrorType.NotFound);
    
    public static Error Validation( string message = "Bad Request", string code = "2") =>
        new (code, message, ErrorType.Validation);
    
    public static Error Conflict( string message, string code = "3") =>
        new (code, message, ErrorType.Conflict);

}