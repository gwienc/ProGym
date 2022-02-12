using System;
using System.Web;
using System.Web.SessionState;

namespace ProGym.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private HttpSessionState session;

        public SessionManager()
        {
            session = HttpContext.Current.Session;
        }

        public void Abandon()
        {
            session.Abandon();
        }

        public T Get<T>(string key)
        {
            return (T)session[key];
        }

        public T Get<T>(string key, Func<T> createDefault)
        {
            T retval;

            if(session[key] != null && session[key].GetType() == typeof(T))
            {
                retval = (T)session[key];
            }
            else
            {
                retval = createDefault();
                session[key] = retval;
            }
            return retval;
        }

        public void Set<T>(string name, T value)
        {
            session[name] = value;
        }

        public T TryGet<T>(string key)
        {
            try
            {
                return (T)session[key];
            }
            catch (NullReferenceException)
            {

                return default(T);
            }
        }
    }
}