namespace ProjectCoreDDD.Application.ResponseEvent
{
    public class ResponseResult
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public ResponseResult(object data, bool success = true, string message = "")
        {
            Data = data;
            Success = success;
            Message = message;
        }
    }
}