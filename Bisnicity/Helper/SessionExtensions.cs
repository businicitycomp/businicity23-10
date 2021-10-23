/*************************************************************************************************************/
/*Class Name    : SessionExtensions.cs                                                                       /
/*Created By    : Hamza Nayef                                                                             */
/*Ceation Date  : 10-12-2021                                                                            */
/******************************************************************************************************/
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Bisnicity.Helper
{
    public static class SessionExtensions
    {

        #region Method :: SetObject
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        #endregion
        #region Method ::GetObject
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        #endregion
       
       
    }
}


