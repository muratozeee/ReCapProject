using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {

        // it is using for generic
        T Get<T>(string key);
        // it is using for any type of method without generic
        object Get(string key);
        //object = base is all of value type we can defined the all things.
        //duration = it can provide us to how many minute can hold in memory.
        void Add(string key, object value, int duration);

        //if it has a key same key in cache dont fetch form cache .
        //if it has'nt a key same key in cache fetch from database and add the cache.
        bool IsAdd(string key);

        //when ı give it key , it can remove it in cache 
        void Remove(string key);

        //maybe sometimes ı dont know which name that's why we can use like a (Get starts)
        //ı give it regex pattern to regular expression
        void RemoveByPattern(string pattern);
        
    }
}
