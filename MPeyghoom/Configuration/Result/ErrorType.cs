﻿namespace MPeyghoom.Configuration.Result;
public enum ErrorType
{
    Failure = 0,
    Validation = 1,
    NotFound = 2,
    Conflict = 3,
    Forbidden = 4,
    Unauthorized = 5, 
    InternalServerError = 6
}
