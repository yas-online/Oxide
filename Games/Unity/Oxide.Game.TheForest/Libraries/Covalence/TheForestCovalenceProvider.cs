﻿using Oxide.Core.Libraries.Covalence;

namespace Oxide.Game.TheForest.Libraries.Covalence
{
    /// <summary>
    /// Provides Covalence functionality for the game "The Forest"
    /// </summary>
    public class TheForestCovalenceProvider : ICovalenceProvider
    {
        /// <summary>
        /// Gets the name of the game for which this provider provides
        /// </summary>
        public string GameName => "The Forest";

        /// <summary>
        /// Gets the singleton instance of this provider
        /// </summary>
        internal static TheForestCovalenceProvider Instance { get; private set; }

        public TheForestCovalenceProvider()
        {
            Instance = this;
        }

        /// <summary>
        /// Gets the player manager
        /// </summary>
        public TheForestPlayerManager PlayerManager { get; private set; }

        /// <summary>
        /// Gets the command system provider
        /// </summary>
        public TheForestCommandSystem CommandSystem { get; private set; }

        /// <summary>
        /// Creates the game-specific server object
        /// </summary>
        /// <returns></returns>
        public IServer CreateServer() => new TheForestServer();

        /// <summary>
        /// Creates the game-specific player manager object
        /// </summary>
        /// <returns></returns>
        public IPlayerManager CreatePlayerManager() => PlayerManager = new TheForestPlayerManager();

        /// <summary>
        /// Creates the game-specific command system provider object
        /// </summary>
        /// <returns></returns>
        public ICommandSystem CreateCommandSystemProvider() => CommandSystem = new TheForestCommandSystem();
    }
}
