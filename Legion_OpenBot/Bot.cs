
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Legion_OpenBot.Commands;

namespace Legion_OpenBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsunk()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                /*LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true,*/
            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            /*Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(2)
            });*/

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,
                /*Services = services*/
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<BasicCommands>();
            /*Commands.RegisterCommands<ItemCommands>();
            Commands.RegisterCommands<ProfileCommands>();
            Commands.RegisterCommands<TeamCommands>();*/

            Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnClientReady(DiscordClient sender, ReadyEventArgs readyEventArgs)
        {
            return Task.CompletedTask;
        }
    }
}
        





   


