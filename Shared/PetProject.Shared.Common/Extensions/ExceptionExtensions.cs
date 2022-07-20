using FluentValidation.Results;
using PetProject.Shared.Common.Exceptions;
using PetProject.Shared.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Shared.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static ErrorResponse ToErrorResponse(this ValidationResult data)
        {
            var res = new ErrorResponse()
            {
                Message = "",
                FieldErrors = data.Errors.Select(x =>
                {
                    var elems = x.ErrorMessage.Split('&');
                    var errorName = elems[0];
                    var errorMessage = elems.Length > 0 ? elems[1] : errorName;
                    return new ErrorResponseFieldInfo()
                    {
                        FieldName = x.PropertyName,
                        Message = errorMessage,
                    };
                })
            };

            return res;
        }

        public static ErrorResponse ToErrorResponse(this ProcessException data)
        {
            var res = new ErrorResponse()
            {
                Message = data.Message
            };

            return res;
        }

        public static ErrorResponse ToErrorResponse(this Exception data)
        {
            var res = new ErrorResponse()
            {
                ErrorCode = -1,
                Message = data.Message
            };

            return res;
        }
    }
}
