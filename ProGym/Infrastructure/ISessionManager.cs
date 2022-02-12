using System;

namespace ProGym.Infrastructure
{
    public interface ISessionManager
    {
        void Abandon();
        T Get<T>(string key);
        T Get<T>(string key, Func<T> createDefault);
        void Set<T>(string name, T value);
        T TryGet<T>(string key);
    }
}