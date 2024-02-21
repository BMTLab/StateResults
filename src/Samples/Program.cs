// OneOf.Reduced
// 1


using BMTLab.StateResults.Samples;

OneOf<string, Exception> union;

union = "Operation is successful";
Console.WriteLine(union); // >> Operation is successful

union = new TimeoutException("User canceled the operation");
Console.WriteLine(union); // >> System.TimeoutException: User canceled the operation

Console.WriteLine(union.Index); // >> 1
Console.WriteLine(union.IsT0); // >> False
Console.WriteLine(union.IsT1); // >> True

var message = union.AsT0; // OK. message is null
var exception = union.AsT1; // OK. exception is Exception

// message = (string) union; // Exeption. System.InvalidCastException: This union does not currently store the given type: System.String.
exception = (Exception) union; // OK


// 2
OneOf<bool, int, string> union1 = 42;
OneOf<bool, int, string> union2 = 42;

var isMatch = union1 == union2;
Console.WriteLine(isMatch); // >> True


// 3
OneOf<int, string, Exception> union3 = "Some text";
string result = union3.Match
(
    number => number.ToString(),
    text => text.ToUpperInvariant(),
    error => error.Message
);

Console.WriteLine(result); // >> SOME TEXT


// 4
OneOf<int, string> union4 = "Some text";
await union4.SwitchAsync
(
    Task.Delay,
    async text =>
    {
        await Task.Delay(100);

        Console.WriteLine(text);
    }
);



// StateResults
// 1
Result<string> result1;

result1 = new Result<string>("Success message", isSuccess: true);
result1 = "Success message";

Console.WriteLine(result1); // >> { Value = Success message, IsSuccess = True }
Console.WriteLine(result1.Value); // >> Success message
Console.WriteLine(result1 == "Success message"); // >> True

result1 = new Result<string>("Failed message", isSuccess: false);
result1 = ("Failed message", IsSuccess: false);

Console.WriteLine(result1); // >> { Value = Failed message, IsSuccess = False }
Console.WriteLine(result1.Value == "Failed message"); // >> True
Console.WriteLine(result1 == ("Failed message", false)); // >> True
Console.WriteLine(result1.IsSuccess); // >> False
Console.WriteLine(result1.IsError); // >> True

Results<CustomStates.Success, CustomStates.Forbidden> t1 = new CustomStates.Success();


