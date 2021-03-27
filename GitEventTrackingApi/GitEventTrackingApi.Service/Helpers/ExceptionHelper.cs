using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GitEventTrackingApi.Service.Helpers
{
    public static class ExceptionHelper
    {
        public static ValidationException ThrowAndLogValidationException<T>(ILogger<T> logger, string error)
        {
            //log error
            logger.LogError(error);
            throw new ValidationException(error);
        }
    }
}
