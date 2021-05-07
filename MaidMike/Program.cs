using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;

namespace MaidMike {
    internal static class Program {
        private static async Task Main() {
            var discord = new DiscordClient(new DiscordConfiguration() {
                Token = GetToken(),
                TokenType = TokenType.Bot
            });

            discord.UseInteractivity(new InteractivityConfiguration() {
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(30)
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration() { StringPrefixes = new[] {"!"}});
            commands.RegisterCommands<CmdModule>();
            commands.RegisterConverter(new ArgConverter());
            
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private static string GetToken() {
            var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\config.cfg");
            return (from x in lines select x.Split("=") into line where line[0].Equals("token") select line[1]).FirstOrDefault();
        }
    }
}