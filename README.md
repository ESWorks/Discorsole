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
