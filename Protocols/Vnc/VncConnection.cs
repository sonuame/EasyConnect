﻿using System;
using System.Runtime.Serialization;

namespace EasyConnect.Protocols.Vnc
{
    /// <summary>
    /// Connection class for connecting to VNC servers.
    /// </summary>
    [Serializable]
    public class VncConnection : BaseConnection
    {
        /// <summary>
        /// Default constructor; initializes properties to default values.
        /// </summary>
        public VncConnection()
        {
            Port = 5900;
            ShareClipboard = true;
        }

        /// <summary>
        /// Serialization constructor required for <see cref="ISerializable"/>; reads connection data from <paramref name="info"/>.
        /// </summary>
        /// <param name="info">Serialization store that we are going to read our data from.</param>
        /// <param name="context">Streaming context to use during the deserialization process.</param>
        protected VncConnection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            foreach (SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case "Port":
                        if (Port == 0)
                            Port = (int)entry.Value;
                        break;

                    case "Display":
                        Display = (int)entry.Value;
                        break;

                    case "ViewOnly":
                        ViewOnly = (bool)entry.Value;
                        break;

                    case "ShareClipboard":
                        ShareClipboard = (bool)entry.Value;
                        break;
                }
            }
        }


        /// <summary>
        /// Number of the display on the host server that should be connected to.
        /// </summary>
        public int Display
        {
            get;
            set;
        }

        /// <summary>
        /// Flag indicating whether or not the connection should be established in view-only mode.
        /// </summary>
        public bool ViewOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Flag indicating whether or not to share the clipboard with the remote server.
        /// </summary>
	    public bool ShareClipboard
        {
            get;
            set;
        }

        /// <summary>
        /// Method required for <see cref="ISerializable"/>; serializes the connection data to <paramref name="info"/>.
        /// </summary>
        /// <param name="info">Serialization store that the connection's data will be written to.</param>
        /// <param name="context">Streaming context to use during the serialization process.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("Port", Port);
            info.AddValue("Display", Display);
            info.AddValue("ViewOnly", ViewOnly);
            info.AddValue("ShareClipboard", ShareClipboard);
        }
    }
}