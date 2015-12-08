﻿using Sandbox.Common;

using Oxide.Core;
using Oxide.Core.Libraries;
using Oxide.Core.Plugins;

namespace Oxide.Game.SpaceEngineers
{
    /// <summary>
    /// The core Space Engineers plugin
    /// </summary>
    public class SpaceEngineersCore : CSPlugin
    {
        // The permission library
        private readonly Permission permission = Interface.Oxide.GetLibrary<Permission>();
        private static readonly string[] DefaultGroups = { "default", "moderator", "admin" };

        // Track when the server has been initialized
        private bool serverInitialized;
        private bool loggingInitialized;

        /// <summary>
        /// Initializes a new instance of the SpaceEngineersCore class
        /// </summary>
        public SpaceEngineersCore()
        {
            // Set attributes
            Name = "spaceengineerscore";
            Title = "Space Engineers Core";
            Author = "Oxide Team";
            Version = new VersionNumber(1, 0, 0);
        }

        /// <summary>
        /// Called when the plugin is initializing
        /// </summary>
        [HookMethod("Init")]
        private void Init()
        {
            // Configure remote logging
            RemoteLogger.SetTag("game", "space engineers");
            RemoteLogger.SetTag("version", MyFinalBuildConstants.APP_VERSION.ToString());
        }

        /// <summary>
        /// Called when the server is first initialized
        /// </summary>
        [HookMethod("OnServerInitialized")]
        private void OnServerInitialized()
        {
            if (serverInitialized) return;
            serverInitialized = true;

            // Configure the hostname after it has been set
            //RemoteLogger.SetTag("hostname", );
        }

        /// <summary>
        /// Called when the server is shutting down
        /// </summary>
        [HookMethod("OnServerShutdown")]
        private void OnServerShutdown() => Interface.Oxide.OnShutdown();

        /// <summary>
        /// Called when a plugin is loaded
        /// </summary>
        /// <param name="plugin"></param>
        [HookMethod("OnPluginLoaded")]
        private void OnPluginLoaded(Plugin plugin)
        {
            if (serverInitialized) plugin.CallHook("OnServerInitialized");
            if (!loggingInitialized) InitializeLogging();
        }

        /// <summary>
        /// Starts the logging
        /// </summary>
        private void InitializeLogging()
        {
            loggingInitialized = true;
            CallHook("InitLogging", null);
        }

        /// <summary>
        /// Disables the original console
        /// </summary>
        [HookMethod("IDisableConsole")]
        private bool IDisableConsole() => false;
    }
}
