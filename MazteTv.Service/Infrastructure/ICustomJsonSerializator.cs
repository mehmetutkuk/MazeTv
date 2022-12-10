namespace MazteTv.Service.Infrastructure
{
    public interface ICustomJsonSerializator
    {
        Task<string> Serialize(object obj);
        Task Serialize(Stream writer, object value, Type type);
        Task<T> Deserialize<T>(string model);
        Task<object> Deserialize(Stream reader, Type type);
    }
}