﻿using Microsoft.Extensions.Logging;

namespace Grapevine
{
    public static class RouterBaseExtensions
    {
        public static void HandleHttpListenerExceptions(this RouterBase router)
        {
            HandleErrorAsync routerDefaultErrorHandler = RouterBase.DefaultErrorHandler;

            Router.DefaultErrorHandler = async (context, exception) =>
            {
                if (exception != null && exception is HttpListenerException && ((HttpListenerException)exception).ErrorCode == 1229)
                {
                    var logger = DefaultLogger.GetInstance<IRouter>();
                    logger.LogDebug("The remote connection was closed before a response could be sent.");
                }
                else
                {
                    await routerDefaultErrorHandler(context, exception);
                }
            };
        }
    }
}
