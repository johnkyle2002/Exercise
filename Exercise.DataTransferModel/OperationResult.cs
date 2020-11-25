using System.Net;

namespace Exercise.DataTransferModel
{
    public class OperationResult<TEntity> where TEntity : class
    {
        public bool Succeeded { get; set; }
        public TEntity Entity { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
