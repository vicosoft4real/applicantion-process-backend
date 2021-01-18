namespace Hahn.ApplicatonProcess.December2020.Web.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class Response<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccessful"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public Response(bool isSuccessful, T data, string message)
        {
            IsSuccessful = isSuccessful;
            Data = data;
            Message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccessful { get; }


        /// <summary>
        /// 
        /// </summary>
        public string Message { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class ApiResponse
    {
        /// <summary>
        /// Converts to response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="succeed">if set to <c>true</c> [succeed].</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static Response<T> ToResponse<T>(this object data, bool succeed = true, string message = "Operation Successful") where T : class
        {
            return new Response<T>(succeed, (T)data, message);
        }
    }
}
