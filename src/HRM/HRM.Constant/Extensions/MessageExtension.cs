using HRM.Constant.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Constant.Extensions
{
    public static class MessageExtension
    {
        public static string GetToastMessage(this ToastMessageType type)
        {
            switch (type)
            {
                case ToastMessageType.TitleSuccess:
                    return Message.ToastMessage.TITLE_SUCCESS;
                case ToastMessageType.TitleError:
                    return Message.ToastMessage.TITLE_ERROR;
                case ToastMessageType.TitleWarning:
                    return Message.ToastMessage.TITLE_WARNING;
                case ToastMessageType.CreateSuccess:
                    return Message.ToastMessage.CREATE_SUCCESS;
                case ToastMessageType.CreateError:
                    return Message.ToastMessage.CREATE_ERROR;
                case ToastMessageType.UpdateSuccess:
                    return Message.ToastMessage.UPDATE_SUCCESS;
                case ToastMessageType.UpdateError:
                    return Message.ToastMessage.UPDATE_ERROR;
                case ToastMessageType.DeleteSuccess:
                    return Message.ToastMessage.DELETE_SUCCESS;
                case ToastMessageType.DeleteError:
                    return Message.ToastMessage.DELETE_ERROR;
            }
            return string.Empty;
        }
    }
}
