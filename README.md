[![package](https://img.shields.io/badge/ICQ.Bot-v1.0.5-blue)](https://www.nuget.org/packages/ICQ.Bot)
[![icq chat](https://img.shields.io/badge/Support%20Chat-ICQ-blue)](https://icq.im/bots_dotnet)
[![license](https://img.shields.io/badge/License-MIT-brightgreen)](https://github.com/idan-rubin/icq.bot.net/blob/master/LICENSE)

# icq.bot.net

C# wrapper for ICQ Bot APIs. Inspired by [Telegram.Bot]

No Microsoft proprietary mambo jumbo needed! Built on the goodness of .Net Core 3.1 and Json.Net

## What's in it for me?
With this package you can:
* Get Bot Events - polling is currently the only way to get events from ICQ :(
* Send Text Messages
* Edit Text Messages
* Send Files (supports image and video)

## How do I get it?
NuGet package is avaiable at [nuget.org]

## How do I ramp up?
Usage is similar to the excellent .Net [Telegram.Bot] project.

Simple Echo Bot:
```csharp
using ICQ.Bot.Args;
using System;

private readonly static IICQBotClient bot = new ICQBotClient("[BOT_ID_FROM_ICQ_METABOT]");

public static void Main(string[] args)
{
  bot.OnMessage += BotOnMessageReceived;
  var me = bot.GetMeAsync().Result;

  bot.StartReceiving();
  Console.WriteLine($"Start listening for @{me.Nick}");

  Console.ReadLine();
  bot.StopReceiving();
}

private static void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
{
  var message = messageEventArgs.Message;
  bot.SendTextMessageAsync(message.From.UserId, message.Text).Wait();
}
```

Let's make .Net the #1 client for ICQ bots!

[nuget.org]: https://www.nuget.org/packages/ICQ.Bot
[Telegram.Bot]: https://github.com/TelegramBots/Telegram.Bot
