using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

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
