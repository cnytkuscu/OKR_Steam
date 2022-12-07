using OKR_Steam.Validators.UserValidators;

namespace OKR_Steam.Middlewares
{
    public class RequestCheckMiddleware
    {
        private RequestDelegate _requestDelegate;

        public RequestCheckMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (context.Request.Path.ToString() == "/cuneyt")
            //    context.Response.WriteAsync("Hoşgeldin Cüneyt");
            //else
            //{
            //    await _requestDelegate.Invoke(context);
            //}
            var requestPathArray = context.Request.Path.ToString().Split("/");
            foreach (var requestName in requestPathArray)
            {
                switch (requestName)
                {
                    case "GetSteamProfileDataByName": {
                            GetSteamProfileDataByNameRequestControl(context.Request.RouteValues.Values.ToList()[2].ToString());
                                } break;
                    default: break;
                }
            }
             
        }

        private void GetSteamProfileDataByNameRequestControl(string username)
        {
            var requestData = new SteamProfileRequestModel()
            {
                Username = username
            };
            var validation = new SteamProfileRequestModelValidator().Validate(requestData);
        }
    }
}
