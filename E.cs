using CSharpFunctionalExtensions;

public class E : ICombine
{
    public string Message;

    public E()
    {
    }

    public E(string error)
    {
        Message = error;
    }

    public ICombine Combine(ICombine value)
    {
        Message = $"{Message}, {((E)value).Message}";
        return this;
    }
}