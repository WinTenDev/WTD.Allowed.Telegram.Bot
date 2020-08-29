﻿using Allowed.Telegram.Bot.Models.Store;
using System;

namespace Allowed.Telegram.Bot.Builders
{
    public static class ContextBuilder
    {
        public static TUser CreateTelegramUser<TKey, TUser>(long chatId, string username)
            where TKey : IEquatable<TKey>
            where TUser : TelegramUser<TKey>
        {
            TUser user = Activator.CreateInstance<TUser>();

            user.ChatId = chatId;
            user.Username = username;

            return user;
        }

        public static TRole CreateTelegramRole<TKey, TRole>(string roleName)
            where TKey : IEquatable<TKey>
            where TRole : TelegramRole<TKey>
        {
            TRole role = Activator.CreateInstance<TRole>();

            role.Name = roleName;

            return role;
        }

        public static TBot CreateTelegramBot<TKey, TBot>(string botName)
            where TKey : IEquatable<TKey>
            where TBot : TelegramBot<TKey>
        {
            TBot bot = Activator.CreateInstance<TBot>();

            bot.Name = botName;

            return bot;
        }

        public static TBotUser CreateTelegramBotUser<TKey, TBotUser>(TKey userId, TKey botId)
            where TKey : IEquatable<TKey>
            where TBotUser : TelegramBotUser<TKey>
        {
            TBotUser botUser = Activator.CreateInstance<TBotUser>();

            botUser.TelegramUserId = userId;
            botUser.TelegramBotId = botId;

            return botUser;
        }

        public static object CreateTelegramBotUser<TKey>(Type botUserType, TKey userId, TKey botId)
            where TKey : IEquatable<TKey>
        {
            object botUser = Activator.CreateInstance(botUserType);

            botUserType.GetProperty("TelegramUserId").SetValue(botUser, userId);
            botUserType.GetProperty("TelegramBotId").SetValue(botUser, botId);

            return botUser;
        }

        public static TBotUserRole CreateTelegramBotUserRole<TKey, TBotUserRole>(TKey botUserId, TKey roleId)
            where TKey : IEquatable<TKey>
            where TBotUserRole : TelegramBotUserRole<TKey>
        {
            TBotUserRole userRole = Activator.CreateInstance<TBotUserRole>();

            userRole.TelegramBotUserId = botUserId;
            userRole.TelegramRoleId = roleId;

            return userRole;
        }

        public static object CreateTelegramBotUserRole<TKey>(Type botUserRoleType, TKey botUserId, TKey roleId)
            where TKey : IEquatable<TKey>
        {
            object botUserRole = Activator.CreateInstance(botUserRoleType);

            botUserRoleType.GetProperty("TelegramBotUserId").SetValue(botUserRole, botUserId);
            botUserRoleType.GetProperty("TelegramRoleId").SetValue(botUserRole, roleId);

            return botUserRole;
        }

        public static TState CreateTelegramState<TKey, TState>(TKey botUserId, string value)
            where TKey : IEquatable<TKey>
            where TState : TelegramState<TKey>
        {
            TState state = Activator.CreateInstance<TState>();

            state.TelegramBotUserId = botUserId;
            state.Value = value;

            return state;
        }
    }
}
