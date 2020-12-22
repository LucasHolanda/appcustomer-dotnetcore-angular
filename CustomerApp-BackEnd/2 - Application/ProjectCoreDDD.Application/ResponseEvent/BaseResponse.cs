using System.Threading.Tasks;

namespace ProjectCoreDDD.Application.ResponseEvent
{
    public class BaseResponse
    {
        public BaseResponse(object data, bool success = true, string message = "")
        {
            result = new ResponseResult(data, success, message);
        }

        public BaseResponse(object data, string message = "")
        {
            result = new ResponseResult(data, true, message);
        }

        public BaseResponse(string message = "")
        {
            result = new ResponseResult(null, true, message);
        }

        private ResponseResult result { get; set; }
        public Task<ResponseResult> Result => Task.Run(() => { return result; });
    }
}