
using Discord.WebSocket;
using EasyBot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using EasyBot.Modules.Admin;
using EasyBot.Modules.Audio;
using EasyBot.Modules.Twitch;
using EasyBot.System;
using EasyBot.Modules.Mixer;

namespace Discorsole
{
    class Program
    {
        private static Bot _bot;

        private static TwitchComponent _twitchComponent;
        private static MixerComponent _mixerComponent;

        static void Main(string[] args)
        {
            Session.Get("discord");

            SteamCache.Load();

            IniFile file = new IniFile("configuration.ini");

            ConfigureBotParameters(file);

            new Program().MainAsync().GetAwaiter().GetResult();

            _bot.Connect(Session.Framework.Token);

            while (_bot.Status() != ConnectionState.Connected) { }


            Console.WriteLine($@"[NL][DISCORD].[API] Report [DISCORD].[API] @{{ ID:{_bot.GetUser().Id },USERNAME:{_bot.GetUser().Username },MAL_USR:{Session.Anime.Username} }}");

            if (file.KeyExists("AllowAlerts", "Twitch") && file.Read("AllowAlerts", "Twitch").ToUpper() == "TRUE")
            {
                _twitchComponent = new TwitchComponent(_bot);
                _twitchComponent.OpenConfiguration(Session.Twitch.XmlConfiguration);
                if (file.KeyExists("OnStart", "Twitch"))
                {
                    _twitchComponent.SetMode(file.Read("OnStart", "Twitch").ToUpper() == "TRUE");
                }
                else
                {
                    _twitchComponent.SetMode(false);
                }
            }

            if (Session.Mixer.Enabled)
            {
                _mixerComponent = new MixerComponent(_bot);
                _mixerComponent.OpenConfiguration(Session.Mixer.XmlConfiguration);
                if (file.KeyExists("OnStart", "Mixer"))
                {
                    _mixerComponent.SetMode(file.Read("OnStart", "Mixer").ToUpper() == "TRUE");
                }
                else
                {
                    _mixerComponent.SetMode(false);
                }
            }
            if (Session.Framework.EnableGamification)
            {
                Session.GameComponent.OpenConfiguration(Session.Gamification.XmlConfiguration);
            }
            if (Session.AudioComponent != null && Session.Framework.EnableAudio)
            {
                Thread.Sleep(1000);
                Session.AudioComponent.SetBot(_bot);
                Session.AudioComponent.BuildGroupDefinitions();
                Session.AudioComponent.JoinChannel(_bot.GetVoiceChannel(Session.Audio.GuildID, Session.Audio.VoiceChannelID));
                Console.WriteLine("PLEASE CLOSE VIA QUIT COMMAND TO CLOSE AUDIO CLIENT!");
            }

            string readLine;

            do
            {
                readLine = Console.ReadLine();

                if (string.IsNullOrEmpty(readLine)) continue;

                switch (readLine.ToUpper())
                {
                    case "TN-OFF":
                        _twitchComponent?.SetMode(false);
                        break;
                    case "TN-ON":
                        _twitchComponent?.SetMode();
                        break;
                    case "PRINT-IDS":
                        _bot?.PrintGuildIdentifications();
                        break;
                    case "HELP":
                        Console.WriteLine("Available Commands:\r\nTN-OFF/TN-ON -> Toggles Twitch Notification.\r\nPRINT-IDS -> Prints all id's for guild(s).\r\nSESSION-PUT -> Stores session data.\r\nSESSION-GET -> Gathers stored session data.\r\nRESTART -> Closes console and opens a new one reconnecting bot.\r\n");
                        break;
                    case "SESSION-PUT":
                        Session.Put();
                        break;
                    case "SESSION-GET":
                        Session.Get("discord");
                        break;
                    case "RESTART":
                        Process.Start(Application.ExecutablePath);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No Command Found.");
                        break;
                }

            } while (readLine != null && readLine.ToUpper() != "QUIT");

            if (Session.AudioComponent != null)
            {
                Session.AudioComponent.Disconnect();
            }

            Session.AudioComponent = null;

            Session.Put();

            _bot.Disconnect();

            Environment.Exit(0);
        }

        private static void ConfigureBotParameters(IniFile file)
        {
            if (file.KeyExists("EnableWelcome", "Framework"))
            {
                Session.Framework.WelcomeMessage = file.Read("WelcomeMessage", "Framework");
                Session.Framework.EnableWelcome = file.Read("EnableWelcome", "Framework").ToUpper() == "TRUE";
            }
            if (file.KeyExists("EnableAnime", "Framework"))
            {
                Session.Framework.EnableAnime = file.Read("EnableAnime", "Framework").ToUpper() == "TRUE";
            }

            if (file.KeyExists("Enabled", "Mixer"))
                Session.Mixer.Enabled = file.Read("Enabled", "Mixer").ToUpper() == "TRUE";

            if (file.KeyExists("OnStart", "Mixer"))
                Session.Mixer.Startup = file.Read("OnStart", "Mixer").ToUpper() == "TRUE";

            if (file.KeyExists("AuthToken", "Mixer"))
                Session.Mixer.AuthToken = file.Read("AuthToken", "Mixer");

            if (file.KeyExists("MixerCID", "Mixer"))
                Session.Mixer.MixerCID = file.Read("MixerCID", "Mixer");

            if (file.KeyExists("XMLConfiguration", "Mixer"))
                Session.Mixer.XmlConfiguration = file.Read("XMLConfiguration", "Mixer");

            if (file.KeyExists("Message", "Mixer"))
                Session.Mixer.Message = file.Read("Message", "Mixer");

            if (file.KeyExists("EnableGamification", "Framework"))
            {


                if (file.KeyExists("MessageExp", "Gamification"))
                {
                    Session.Gamification.Message_Exp = double.Parse(file.Read("MessageExp", "Gamification"));
                }
                else
                {
                    Session.Gamification.Message_Exp = 12.5;
                }
                if (file.KeyExists("MediaExp", "Gamification"))
                {
                    Session.Gamification.Media_Post_Exp = double.Parse(file.Read("MediaExp", "Gamification"));
                }
                else
                {
                    Session.Gamification.Media_Post_Exp = 25.00;
                }
                if (file.KeyExists("Subscriber", "Gamification"))
                {
                    Session.Gamification.Sub_Percentage_Bonus = double.Parse(file.Read("Subscriber", "Gamification"));
                }
                else
                {
                    Session.Gamification.Sub_Percentage_Bonus = 1.50;
                }
                if (file.KeyExists("JoinExp", "Gamification"))
                {
                    Session.Gamification.Join_Experience = double.Parse(file.Read("JoinExp", "Gamification"));
                }
                else
                {
                    Session.Gamification.Join_Experience = 150.00;
                }
                if (file.KeyExists("XMLConfiguration", "Gamification"))
                {
                    Session.Gamification.XmlConfiguration = file.Read("XMLConfiguration", "Gamification");
                }
                else
                {
                    Session.Gamification.XmlConfiguration = "./conf/gamification.xml";
                }
                if (file.KeyExists("MaxLevel", "Gamification"))
                {
                    Session.Gamification.Max_Level = int.Parse(file.Read("MaxLevel", "Gamification"));
                }
                else
                {
                    Session.Gamification.Max_Level = 20;
                }
                if (file.KeyExists("ExperienceByLevel", "Gamification"))
                {
                    Session.Gamification.Exp_By_Level = int.Parse(file.Read("ExperienceByLevel", "Gamification"));
                }
                else
                {
                    Session.Gamification.Max_Level = 1000;
                }
                Session.Framework.EnableGamification = file.Read("EnableGamification", "Framework").ToUpper() == "TRUE";
            }
            if (file.KeyExists("EnableTerms", "Framework"))
            {
                if (file.KeyExists("Configuration", "Terms"))
                {
                    Session.Framework.EnableTerms = file.Read("EnableTerms", "Framework").ToUpper() == "TRUE";
                    if (Session.TermsComponent == null)
                    {
                        Session.TermsComponent = new TermsComponent();
                    }
                    Session.TermsComponent.OpenConfiguration(file.Read("Configuration", "Terms"));
                }
            }
            if (file.KeyExists("EnableAudio", "Framework"))
            {
                Session.Framework.EnableAudio = file.Read("EnableAudio", "Framework").ToUpper() == "TRUE";
                if (Session.Framework.EnableAudio)
                {
                    Session.AudioComponent = new AudioComponent();
                    try
                    {
                        Session.Audio.GuildID = ulong.Parse(file.Read("GuildID", "Music"));
                        Session.Audio.VoiceChannelID = ulong.Parse(file.Read("AudioID", "Music"));
                        Session.Audio.TextChannelID = ulong.Parse(file.Read("TextID", "Music"));
                        Session.Audio.AllowSummon = file.Read("AllowSummons", "Music") == "TRUE";
                        Session.Audio.AutoRejoin = file.Read("AutoRejoin", "Music") == "TRUE";
                        Session.Audio.YTBDPath = file.Read("youtube-dl", "Music");
                        Session.Audio.Output = file.Read("Output", "Music");
                        Session.Audio.FFMpegPath = file.Read("ffmpeg", "Music");
                        Session.Audio.GroupConfig = file.Read("GroupConfig", "Music");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($@"[NL][MAIN].[PROGRAM] Report [MAIN].[PROGRAM] @{{ ERROR: FAILED TO READ MUSIC CONFIG! }}");
                        Session.Framework.EnableAudio = false;
                    }

                }
            }
            if (file.KeyExists("EnableSteam", "Framework"))
            {
                Session.Framework.EnableSteam = file.Read("EnableSteam", "Framework").ToUpper() == "TRUE";
            }
            if (Session.Anime.AllowedChannels == null)
            {
                Session.Anime.AllowedChannels = new List<ulong>();
            }
            if (Session.Steam.Channels == null)
            {
                Session.Steam.Channels = new List<ulong>();
            }
            if (file.KeyExists("Token", "Framework"))
            {
                if (string.IsNullOrEmpty(Session.Framework.Token))
                {
                    Session.Framework.Token = file.Read("Token", "Framework");
                }
            }
            if (file.KeyExists("SID", "Steam"))
            {
                if (string.IsNullOrEmpty(SteamCache.Cache.Apikey))
                {
                    SteamCache.Cache.Apikey = file.Read("SID", "Steam");
                    SteamCache.Save();
                }
            }
            if (file.KeyExists("MALUser", "Anime"))
            {
                if (string.IsNullOrEmpty(Session.Anime.Username))
                {
                    Session.Anime.Username = file.Read("MALUser", "Anime");
                }
            }
            if (file.KeyExists("MALPwd", "Anime"))
            {
                if (string.IsNullOrEmpty(Session.Anime.Password))
                {
                    Session.Anime.Password = file.Read("MALPwd", "Anime");
                }
            }
            if (file.KeyExists("Channels", "Anime"))
            {
                foreach (string uid in file.Read("Channels", "Anime").Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    ulong id = ulong.Parse(uid);
                    if (!Session.Anime.AllowedChannels.Contains(id))
                    {
                        Session.Anime.AllowedChannels.Add(id);
                    }
                }
            }
            if (file.KeyExists("Channels", "Steam"))
            {
                foreach (string uid in file.Read("Channels", "Steam").Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    ulong id = ulong.Parse(uid);
                    if (!Session.Steam.Channels.Contains(id))
                    {
                        Session.Steam.Channels.Add(id);
                    }
                }
            }
            if (Session.Anime.AnimeFormat == null)
            {
                Session.Anime.AnimeFormat = new[] { "No Format Specified." };
            }
            if (Session.Anime.MangaFormat == null)
            {
                Session.Anime.MangaFormat = new[] { "No Format Specified." };
            }
            if (file.KeyExists("AnimeFormat", "Anime"))
            {
                Session.Anime.AnimeFormat = File.ReadAllLines(file.Read("AnimeFormat", "Anime"));
            }
            if (file.KeyExists("MangaFormat", "Anime"))
            {
                Session.Anime.MangaFormat = File.ReadAllLines(file.Read("MangaFormat", "Anime"));
            }
            if (file.KeyExists("AllowNSFW", "Anime"))
            {
                Session.Anime.AllowNSFW = file.Read("AllowNSFW", "Anime").ToUpper() == "TRUE";
            }
            if (file.KeyExists("AllowNSFWDM", "Anime"))
            {
                Session.Anime.AllowNSFWDM = file.Read("AllowNSFWDM", "Anime").ToUpper() == "TRUE";
            }
            if (file.KeyExists("AllowDM", "Anime"))
            {
                Session.Anime.AllowDM = file.Read("AllowDM", "Anime").ToUpper() == "TRUE";
            }
            if (file.KeyExists("Warning", "Anime"))
            {
                Session.Anime.WarningMessage = file.Read("Warning", "Anime");
            }
            if (file.KeyExists("Block", "Anime"))
            {
                Session.Anime.BlockMessage = file.Read("Block", "Anime");
            }
            if (file.KeyExists("TwitchCID", "Twitch"))
            {
                Session.Twitch.TwitchCID = file.Read("TwitchCID", "Twitch");
            }
            if (file.KeyExists("Message", "Twitch"))
            {
                Session.Twitch.Message = file.Read("Message", "Twitch");
            }
            if (Session.Anime._warnedUsers == null)
            {
                Session.Anime._warnedUsers = new Dictionary<ulong, int>();
            }
            if (Session.Anime._blockedUsers == null)
            {
                Session.Anime._blockedUsers = new Dictionary<ulong, DateTime>();
            }
            Session.Twitch.Interval = file.KeyExists("Interval", "Twitch") ? int.Parse(file.Read("Interval", "Twitch")) : 60000;
            Session.Anime.max_offence = file.KeyExists("Offence", "Anime") ? int.Parse(file.Read("Offence", "Anime")) : 3;
            Session.Anime.max_timeout = file.KeyExists("Timeout", "Anime") ? int.Parse(file.Read("Timeout", "Anime")) : 120;
            if (file.KeyExists("XMLConfiguration", "Twitch"))
            {
                Session.Twitch.XmlConfiguration = file.Read("XMLConfiguration", "Twitch");
            }
            Session.Put();
        }

        public async Task MainAsync()
        {
            _bot = new Bot();
            _bot.SetMessageRecieved(MessageReceived);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
        }
    }
}
