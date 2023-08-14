Results<Success, NotExist, NotFound, InternalError> result1 = new InternalError("custom msg", new ArgumentException("inner exception msg"));
Results<Success, InternalError> result2 = new Success("custom msg");
Result<Success> result3 = new Success("custom msg");
Result<InternalError> result4 = new InternalError("custom msg");
Result<string> result5 = ("ccccccccccccccc", true);

Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);
Console.WriteLine(result4);
Console.WriteLine(result5);


OneOf<int, string, InternalError> union1 = new InternalError("text");

Console.WriteLine(union1);