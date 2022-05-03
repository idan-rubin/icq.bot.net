[![package](https://img.shields.io/badge/ICQ.Bot-v1.4.8-blue)](https://www.nuget.org/packages/ICQ.Bot)
[![icq chat](https://img.shields.io/badge/Community-Chat-purple)](https://icq.im/bots_dotnet)
[![license](https://img.shields.io/badge/license-MIT-orange)](https://github.com/idan-rubin/icq.bot.net/blob/master/LICENSE)
[![Bot API Version](https://img.shields.io/badge/Bot%20API%20Version-11.05.2021-ff69b4)](https://agent.mail.ru/botapi/?lang=en#/self/get_self_get)

# icq.bot.net

Lightweight, HTTP-Based C# implementation for [ICQ Bot APIs](https://icq.com/botapi/) (also known as [Mail.ru Agent bot API](https://agent.mail.ru/botapi/?lang=ru) / [VK Teams](https://help.mail.ru/biz/myteam) bot API).
>>>>>>> e185c3e934c0f51764e2bc2007e4b32f11d12831

No Microsoft proprietary mambo jumbo needed! Built on the goodness of .Net Standard 2.0 and Newtonsoft.Json

## What's in it for me?
With this package you can:
* Respond to Bot Events
* Send, Edit and Delete Text Messages
* Send Inline Buttons with Text Messages
* Send Files (supports image and video)

## How do I get it?
NuGet package is avaiable at [nuget.org]

## How do I ramp up?
Usage is similar to the excellent .Net [Telegram.Bot] project.

## Simple Echo Bot
```csharp
using ICQ.Bot.Args;
using System;

private readonly static IICQBotClient bot = new ICQBotClient("BOT_ID_FROM_ICQ_METABOT");

public static void Main(string[] args)
{
  bot.OnMessage += BotOnMessageReceived;
  var me = bot.GetMeAsync().Result;

  bot.StartReceiving();
  Console.WriteLine($"Start listening to @{me.Nick}");

  Console.ReadLine();
  bot.StopReceiving();
}

private static void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
{
  var message = messageEventArgs.Message;
  bot.SendTextMessageAsync(message.From.UserId, message.Text).Wait();
}
```

## Simple Translator Bot
Check out a simple English/Russian translator bot: [ICQTranslatorBot]

Let's make .Net the #1 client for ICQ bots!

[nuget.org]: https://www.nuget.org/packages/ICQ.Bot
[Telegram.Bot]: https://github.com/TelegramBots/Telegram.Bot
[ICQTranslatorBot]: https://github.com/idan-rubin/ICQTranslatorBot
