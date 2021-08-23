using HRM.Constant.Enums;
using HRM.Constant.Extensions;
using Microsoft.JSInterop;
using System.Net;
using System.Threading.Tasks;

namespace HRM.Infrastructure
{
    public class ToastMessageHelper
    {
        private readonly int successTime = 2500;
        private readonly int errorTime = 5000;
        private readonly string successType = "success";
        private readonly string errorType = "error";

        private readonly IJSRuntime _jsRuntime;

        public ToastMessageHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Success(string message)
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleSuccess.GetToastMessage(),
                                            message,
                                            successType,
                                            successTime);
        }

        public async Task Error(string message)
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleError.GetToastMessage(),
                                            message,
                                            errorType,
                                            errorTime);
        }

        public async Task CreateSuccess()
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleSuccess.GetToastMessage(),
                                            ToastMessageType.CreateSuccess.GetToastMessage(),
                                            successType,
                                            successTime);
        }

        public async Task UpdateSuccess()
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleSuccess.GetToastMessage(),
                                            ToastMessageType.UpdateSuccess.GetToastMessage(),
                                            successType,
                                            successTime);
        }

        public async Task DeleteSuccess()
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleSuccess.GetToastMessage(),
                                            ToastMessageType.DeleteSuccess.GetToastMessage(),
                                            successType,
                                            successTime);
        }

        public async Task CreateError()
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleError.GetToastMessage(),
                                            ToastMessageType.CreateError.GetToastMessage(),
                                            successType,
                                            errorTime);
        }

        public async Task UpdateError()
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleError.GetToastMessage(),
                                            ToastMessageType.UpdateError.GetToastMessage(),
                                            errorType,
                                            errorTime);
        }

        public async Task DeleteError()
        {
            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleError.GetToastMessage(),
                                            ToastMessageType.DeleteError.GetToastMessage(),
                                            errorType,
                                            errorTime);
        }

        public async Task ApplicationError(HttpStatusCode statusCode)
        {
            string message = string.Empty;
            switch (statusCode)
            {
                case HttpStatusCode.InternalServerError:
                    message = ToastMessageType.InternalError.GetToastMessage();
                    break;
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.MethodNotAllowed:
                    message = ToastMessageType.MethodNotAllow.GetToastMessage();
                    break;
                case HttpStatusCode.Unauthorized:
                    message = ToastMessageType.Unauthorized.GetToastMessage();
                    break;
                default:
                    message = string.Empty;
                    break;
            }

            await _jsRuntime.InvokeVoidAsync("showToastMessage",
                                            ToastMessageType.TitleError.GetToastMessage(),
                                            message,
                                            errorType,
                                            errorTime);
        }

    }
}
