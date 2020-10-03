﻿using System;
using System.Threading.Tasks;

namespace Allowed.Telegram.Bot.Middlewares
{
    public abstract class MessageDbMiddleware<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual Task AfterMessageProcessedAsync(TKey botId, long chatId) { return Task.CompletedTask; }
        public virtual Task AfterCallbackProcessedAsync(TKey botId, long chatId) { return Task.CompletedTask; }

        public virtual void AfterMessageProcessed(TKey botId, long chatId) { }
        public virtual void AfterCallbackProcessed(TKey botId, long chatId) { }
    }
}
