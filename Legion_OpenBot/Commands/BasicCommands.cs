using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legion_OpenBot.Commands
{
    public class BasicCommands : BaseCommandModule 
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            ctx.Channel.SendMessageAsync("Работает");
        }
    }
}

