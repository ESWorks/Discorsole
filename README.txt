> --- INSTALL/SETUP GUIDE --- <

1) Extract Discorsole Archive

2) Open Configuration.ini
	2.1) Set Token value in [Framework]
	2.2) Run discorsole.exe
	2.3) Wait for connection...
	2.4) Enter PRINT-IDS
	2.5) Open the file "ids.txt"

3) Open and finalise Configuration.ini
	3.1) [Anime] Category
		3.1.1) Set MALUser, MyAnimeList username.
		3.1.2) Set MALPwd, MyAnimeList password.
		3.1.3) Set AllowNSFW, allow NSFW in guild channels.
		3.1.4) Set AllowNSFWDM, allow NSFW in DM if DM is enabled.
		3.1.5) Set AllowDM, allow DM to bot for anime.
		3.1.6) Set AnimeFormat, give file path for the formatting of anime replies.
			*** See Step 4 for format information. ***
		3.1.7) Set MangaFormat, give file path for the formatting of manga replies.
			*** See Step 4 for format information. ***
		3.1.8) Set Channels, read from the list printed by the bot in step 2.
		3.1.9) Set Timeout, when a user query's for NSFW content more then allowed offence.
		3.1.10) Set Offence limit before message timeout, only used when NSFW in non DM is enabled.
		
	3.2) [Gamification] Category
		3.2.1) Set MessageExp, Experienced gained per message.
		3.2.2) Set MediaExp, Experienced gained per message with embeds or attachments.
		3.2.3) Set Subscriber, Experienced gained per for subscribers.
			*** See Step 4 for format information. ***
		3.2.4) Set JoinExp, Experienced gained when joining guild.
		3.2.5) Set MaxLevel, Max Level.
		3.2.6) Set ExperienceByLevel, value multiplied by level.
		3.2.7) Set SubscriberConf, location of config file for subscriber roles.
		
	3.3) [Framework] Category
		3.3.1) Set Values to ENABLE on the Modules to install.
		3.3.2) If Welcome message enabled, set the Welcome message here (applies to all guilds).
		
	3.4) [Twitch] Category
		3.4.1) Set Twitch Client ID, needed to query data.
		3.4.2) Set configuration file location.
			*** See Step 4 for format information. ***
		3.4.3) Set Live channel message (applies to all guilds)
		3.4.3) Set FALSE/TRUE for Allow Alerts to check for alerts.
		3.4.5) set TRUE if you want bot to start checking on start up.
		
	3.5) [Mixer] Category
		3.5.1) Set Mixer Client ID, may be needed to query data.
		3.5.1) Set Mixer AuthToken, may be needed to query data.
		3.5.2) Set configuration file location.
			*** See Step 4 for format information. ***
		3.5.3) Set Live channel message (applies to all guilds)
		3.5.3) Set FALSE/TRUE for Enabled to check for alerts.
		3.5.5) set TRUE if you want bot to start checking on start up.
		
	3.5) [Steam] Category
		3.5.1) Steam Client ID to check game data with steam command.
		3.5.2) Channel IDS from id file to read commands from.
		
	3.6) [Music] Category (Can only do this for one GUILD, limit of API)
		3.6.1) Set Guild ID, ID of the server to use.
		3.6.2) Set Audio Channel ID, ID of voice channel.
		3.6.3) Set Text Channel ID, ID of text channel to read commands.
		3.6.4) Set TRUE or FALSE to auto join channel default.
		3.6.5) Set TRUE or FALSE to allow summons.
			*** See Step 4 for format information. ***
		
	3.7) [Terms] Category
		3.7.1) Set configuration file location.
			*** See Step 4 for format information. ***
			
4) Category Formatting and Details

	4.1) Anime API Formatting Details
		4.1.1) Commands
			a) [Command("anime"), Summary("Searches MAL, finding the most relevant anime.")]
			
		4.1.2) Key Words List
			$id -> MAL ID.
			$title -> Show Title.
			$english -> English Title.
			$score -> MAL Score.
			$synonyms -> Words associated with.
			$type -> Show Type.
			$synopsis -> Description/Synopsis of show.
			$status -> Status of the show, airing/completed/etc.
			$start_date -> Show start date/release date.
			$end_date -> Shows finished airing date.
			$episodes -> number of episodes.
			
	4.2) Manga API Formatting Details
	
		4.2.1) Commands
			a) [Command("manga"), Summary("Searches MAL, finding the most relevant manga.")]
			
		4.2.2) Key Words List
			$id -> MAL ID.
			$title -> Published Title.
			$english -> English Title.
			$score -> MAL Score.
			$synonyms -> Words associated with.
			$type -> Manga Type.
			$synopsis -> Description/Synopsis of story.
			$status -> Status of the publishing, completed/etc.
			$start_date -> Publishing start date/release date.
			$end_date -> Publishing finished date.
			$chapters -> Published Chapters.
			$volumes -> Published volumes.
	
	4.3) Gamification Formatting Details
		
		4.3.1) Gamification Module Command List
			a) [Command("Level"), Summary("Lists Current Users Level.")]
			b) [Command("LevelUp"), Summary("Gets the requirements for leveling up.")]
			
		4.3.2) Gamification Configuration XML
			a) Root Element <Gamify>...</Gamify>
			b) Channel Element <Group guid="guild_id" sid="role_id" />
			c) Modify the attributes
				c.i) guid is the id of the Guild/Server
				c.ii) sid is the id of the roles that indicate subs.
			d) Add more elements per guild required.
			
	4.4) Twitch Formatting Details
	
		4.4.1) Twitch Module Command List
			a) [Command("TwitchSub"), Summary("Subscribe to twitch notifications.")] (DM)
			b) [Command("TwitchUnsub"), Summary("Unsubscribe to twitch notifications.")] (DM)
			c) [Command("TwitchSubs"), Summary("List of twitch notifications.")] (DM)
			
		4.4.2) Special Values Live Message
			%n% New Line
			%game% -> Channel Game
            %name% -> Channel Name
            %displayname% -> Channel Display Name
            %status% -> Channel Status Message
            %followers% -> Followers Count
            %views% -> TotalViews
            %viewers% -> Current Viewers
            %link% -> Stream Link
            %mature% -> Mature Stream" : Family Friendly
            %partner%" -> Partnered Stream" : Not a Partner
			
		4.4.3) Twitch Configuration XML
			a) Root Element <Twitch>...</Twitch>
			b) Channel Element <channel name="twitch_name" uid="channel_id" />
			c) Modify the attributes
				c.i) name is the name of the Twitch channel to check
				c.ii) uid is the id of the channels to post alerts in (seperated by commas).
			d) Add more elements per channel required.
			
	4.5) Mixer Formatting Details
	
		4.5.1) Special Values Live Message
			%username% -> Name of channel
			%viewers% -> Current Viewers
			%followers% -> Follower Count
			%audience% -> Audience Rating
			%description% -> User Description
			%game% -> Game Name
			%link% -> Stream Link
			%n% -> New Line
			
		4.5.2) Mixer Configuration XML
			a) Root Element <Mixer>...</Mixer>
			b) Channel Element <channel name="mixer_name" uid="channel_id" />
			c) Modify the attributes
				c.i) name is the name of the mixer channel to check
				c.ii) uid is the id of the channels to post alerts in (seperated by commas).
			d) Add more elements per channel required.
			
	4.6) Terms Formatting Details
	
		4.6.1) Terms Commands List
			a) [Command("Terms"), Summary("Changes the user role to the designated terms. Help to view options;")]
				a.i) [Remainder, Summary("Key Term")] 
					1) View
					2) Help
					3) Acceptance Key words (defined in config file)
					
		4.6.2) Terms Configuration XML
			a) Root Element <Terms>...</Terms>
			b) term Element <term guild="0" rid="0" keyterms="Agree" cid="0,0" message=""/>
			c) Modify the attributes
				c.i) guild is the id of the server.
				c.ii) rid is the role id of the bot will give on acceptance.
				c.iii) keyterms is the words after the term command to consider as acceptance.
				c.iv) cid is the channel ids to listen on.
				c.v) message is the terms to be given when the command is used.
			d) Add more elements per guild required.
			
	4.7) Audio Formatting Details
	
		4.7.1) Audio Commands List
			a) [Command("Song"), Summary("Adds a song to the queue!")]
			b) [Command("Skip"), Summary("Skips a song in the queue!")]
			c) [Command("StopQueue"), Summary("Stop the queue!")]
			d) [Command("StartQueue"), Summary("Start the queue!")]
			e) [Command("JoinQueue"), Summary("Join the designated server channel or default to user!")]
			f) [Command("SummonQueue"), Summary("Summon the bot to your channel!")]
			
		4.7.2) Audio Configuration XML
			a) Root Element <GroupDefinitions>...</GroupDefinitions>
			b) GroupDefinitions Element <GroupDefinition uid="0" >...</GroupDefinition>
			c) Modify the attributes
				c.i) uid is the id of the group/role.
			d) Commands Element <Commands>...</Commands>
				d.i) Commands element is in the Group Definition Element
				d.ii) Contains a element <Command value="command_name"/>
				d.iii) Command has a value attribute of the command allowed to be used.
			e) Add more elements per guild required.
			
	4.8) Steam Details
		4.8.1) Steam Module Commands List
			a) [Command("steaminv"), Summary("Searches Steam, finding the most relevant player and posting the invite to game.")]
			b) [Command("steam"), Summary("Searches Steam, finding the most relevant game and posting information")]

5) DEVELOPER LIBRARY
	5.1) Use your IDE
	5.2) Create new C# Project
	5.3) Link Discord.NET as a Nuget Package
		5.3.1) Dependancies too.
	5.4) Link EasyBot.DLL
	5.5) Use "Bot" class to create a bot.
	5.6) Use "Session" to configure Bot Modules.
	
	5.7) EXAMPLE FROM Discorsole
	
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
                if (file.KeyExists("OnStart","Twitch"))
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
                    _twitchComponent.SetMode(file.Read("OnStart", "Mixer").ToUpper() == "TRUE");
                }
                else
                {
                    _twitchComponent.SetMode(false);
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