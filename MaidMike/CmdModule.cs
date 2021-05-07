using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;

namespace MaidMike {
    public class CmdModule : BaseCommandModule {
        
        [Command("ping")]
        public async Task PingCmd(CommandContext ctx) {
            await ctx.RespondAsync("Pong!");
        }
    }
}