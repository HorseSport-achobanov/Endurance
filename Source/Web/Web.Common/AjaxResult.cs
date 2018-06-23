namespace Web.Common
{
    public class AjaxResult
    {
        public AjaxResult(bool success = true, string message = null, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; }

        public string Message { get; }

        public object Data { get;  }
    }
}
