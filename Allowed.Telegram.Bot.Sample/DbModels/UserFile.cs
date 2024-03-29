﻿using Allowed.Telegram.Bot.Sample.DbModels.Allowed;

namespace Allowed.Telegram.Bot.Sample.DbModels;

public class UserFile
{
    public int Id { get; set; }

    public int TelegramUserId { get; set; }
    public ApplicationTgUser TelegramUser { get; set; }

    public string Type { get; set; }
    public string Value { get; set; }
}