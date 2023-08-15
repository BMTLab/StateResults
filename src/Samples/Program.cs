Results<Success, NotExist, NotFound, InternalError> result1 = new InternalError("custom msg", new ArgumentException("inner exception msg"));
Result<InternalError> result2 = new InternalError("custom msg");

Console.WriteLine(result1);
Console.WriteLine(result2);

OneOf<int, string, InternalError> union1 = new InternalError("text");

Console.WriteLine(union1);