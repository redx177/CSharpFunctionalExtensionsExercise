// See https://aka.ms/new-console-template for more information
using CSharpFunctionalExtensions;
using System.Linq;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

public class Cases
{
    public Result<string, E> CaseA(Func<Result<string, E>> getFirstName, Func<Result<string, E>> getLastName)
    {
        var firstName = getFirstName();

        if (firstName.IsFailure)
            return Result.Failure<string, E>(new E(firstName.Error.Message));

        var lastName = getLastName();

        return lastName.IsFailure
            ? Result.Failure<string, E>(new E(lastName.Error.Message))
            : Result.Success<string, E>(lastName.Value);
    }

    public Result<string> CaseB(Func<Result<string>> getFirstName, Func<string> getLastName)
    {
        var firstName = getFirstName();

        if (firstName.IsFailure)
            return Result.Failure<string>(firstName.Error);

        var lastName = getLastName(); // <-- Returns not a Result

        return Result.Success<string>(lastName);
    }

    public Result<string, E> CaseC(Func<Result<string>> getFirstName, Func<string> getLastName)
    {
        var firstName = getFirstName();

        if (firstName.IsFailure)
            return Result.Failure<string, E>(new E(firstName.Error));

        var lastName = getLastName(); 

        return Result.Success<string, E>(lastName); // <-- Returns a Result with a typed error
    }

    public Result<string, E> CaseD(Func<Result<string>> getFirstName, Action getLastName)
    {
        var firstName = getFirstName();

        if (firstName.IsFailure)
            return Result.Failure<string, E>(new E(firstName.Error));

        getLastName(); // <-- Invoking void function

        return Result.Success<string, E>(firstName.Value);
    }

    public Result<string, E> CaseE(Func<Result<string, E>> getFirstName, Func<Result<string, E>> getLastName)
    {
        var firstName = getFirstName();

        if (firstName.IsFailure)
            return Result.Failure<string, E>(firstName.Error);

        var lastName = getLastName();

        return lastName.IsFailure
            ? Result.Failure<string, E>(new E(lastName.Error.Message)) // <-- On error: Return error of getLastName()
            : Result.Success<string, E>(firstName.Value); // <-- On success: Return value of getFirstName()
    }

    public Result<string, E> CaseF(Func<Result<string>> getFirstName, Func<Result<string, E>> getLastName)
    {
        var firstName = getFirstName(); // <-- Returns a non-typed error

        if (firstName.IsFailure)
            return Result.Failure<string, E>(new E(firstName.Error));

        var lastName = getLastName();

        return lastName.IsFailure
            ? Result.Failure<string, E>(new E(lastName.Error.Message))
            : Result.Success<string, E>(lastName.Value);
    }

    public Result<string, E> CaseG(
        Func<Result<string, E>> getFirstName,
        Func<Result<string, E>> getLastName,
        Func<string, string, Result<string, E>> getFullName)
    {
        var firstName = getFirstName();

        if (firstName.IsFailure)
            return Result.Failure<string, E>(firstName.Error);

        var lastName = getLastName();

        if (lastName.IsFailure)
            return Result.Failure<string, E>(new E(lastName.Error.Message));

        return getFullName(firstName.Value, lastName.Value); // <-- Call a method with the first and last name
    }

    public Result<IEnumerable<string>, E> CaseH(Func<IEnumerable<Result<string>>> getFirstNames)
    {
        var firstNames = getFirstNames(); // <-- Getting a list of results

        var result = Result.Combine(firstNames);

        return result.IsFailure
            ? Result.Failure<IEnumerable<string>, E>(new E(result.Error))
            : Result.Success<IEnumerable<string>, E>(firstNames.Select(firstName => firstName.Value)); // <-- Returning one result with a list of values
    }

    public Result<IEnumerable<string>, E> CaseI(Func<Result<IEnumerable<string>>> getFirstNames, Func<string, UnitResult<E>> sendEmail)
    {
        var firstNames = getFirstNames();

        if (firstNames.IsFailure)
            return Result.Failure<IEnumerable<string>, E>(new E(firstNames.Error));

        var results = new List<UnitResult<E>>();
        foreach (var firstName in firstNames.Value)
        {
            results.Add(sendEmail(firstName)); // <-- Call sendEmail for each firstName once
        }
        var combinedResults = Result.Combine(results);

        return combinedResults.IsFailure
            ? Result.Failure<IEnumerable<string>, E>(combinedResults.Error) // <-- Return errors from email sending if any occured
            : Result.Success<IEnumerable<string>, E>(firstNames.Value); // <-- If email sending succeeded, return all first names
    }
}
