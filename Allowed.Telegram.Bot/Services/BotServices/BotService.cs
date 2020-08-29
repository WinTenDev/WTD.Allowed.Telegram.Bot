﻿using Allowed.Telegram.Bot.Extensions.Collections;
using Allowed.Telegram.Bot.Extensions.Collections.Items;
using Allowed.Telegram.Bot.Handlers.MessageHandlers;
using Allowed.Telegram.Bot.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Allowed.Telegram.Bot.Services.BotServices
{
    public class BotService : BackgroundService
    {
        protected readonly ControllersCollection _controllersCollection;

        public BotService(IServiceProvider services,
            ControllersCollection controllersCollection)
        {
            Services = services;

            _controllersCollection = controllersCollection;
        }

        protected IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await DoWork(stoppingToken);
        }

        private MessageHandler GetMessageHandler(ITelegramBotClient client, BotData botData)
        {
            return new MessageHandler(_controllersCollection, client, botData, Services);
        }

        protected virtual async Task DoWork(CancellationToken stoppingToken)
        {
            ClientsCollection clientsCollection = Services.GetService<ClientsCollection>();

            foreach (ClientItem client in clientsCollection.Clients)
            {
                MessageHandler messageHandler = GetMessageHandler(client.Client, client.BotData);

                client.Client.OnMessage += async (a, b) => await messageHandler.OnMessage(b);
                client.Client.OnCallbackQuery += async (a, b) => await messageHandler.OnCallbackQuery(b);

                client.Client.StartReceiving();
            }

            await Task.Delay(Timeout.Infinite);
        }
    }
}