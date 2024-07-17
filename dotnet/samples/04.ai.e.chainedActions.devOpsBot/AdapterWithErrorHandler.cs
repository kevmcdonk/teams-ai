﻿using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Teams.AI;

namespace DevOpsBot
{
    public class AdapterWithErrorHandler : TeamsAdapter
    {
        public AdapterWithErrorHandler(IConfiguration configuration, ILogger<TeamsAdapter> logger)
            : base(configuration, null, logger)
        {
            OnTurnError = async (turnContext, exception) =>
            {
                // Log any leaked exception from the application.
                // NOTE: In production environment, you should consider logging this to
                // Azure Application Insights. Visit https://aka.ms/bottelemetry to see how
                // to add telemetry capture to your bot.
                logger.LogError(exception, "[OnTurnError] unhandled error : {message}", exception.Message);

                // Send a message to the user
                await turnContext.SendActivityAsync($"The bot encountered an unhandled error: {exception.Message}").ConfigureAwait(false);
                await turnContext.SendActivityAsync("To continue to run this bot, please fix the bot source code.").ConfigureAwait(false);

                // Send a trace activity
                await turnContext.TraceActivityAsync("OnTurnError Trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError").ConfigureAwait(false);
            };
        }
    }
}
