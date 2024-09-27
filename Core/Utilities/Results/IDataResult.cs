namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult //generic ile döndüreceğimiz şeyin tipini belli ettik <T>
    {
        T Data { get; }
    }
}
