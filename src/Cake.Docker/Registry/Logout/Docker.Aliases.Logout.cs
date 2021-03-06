﻿using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with logout command.
    partial class DockerAliases
    {
        /// <summary>
        /// Logout from a Docker registry.
        /// If no server is specified, the docker engine default is used.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The server.</param>
        [CakeMethodAlias]
        public static void DockerLogout(this ICakeContext context, string server = null)
        {
            DockerLogout(context, new DockerRegistryLogoutSettings(), server);
        }

        /// <summary>
        /// Logout from a Docker registry.
        /// If no server is specified, the docker engine default is used.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="server">The server.</param>
        [CakeMethodAlias]
        public static void DockerLogout(this ICakeContext context, DockerRegistryLogoutSettings settings, string server = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            var runner = new GenericDockerRunner<DockerRegistryLogoutSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("logout", settings, server != null ? new[] { server } : new string[]{ });
        }
    }
}
