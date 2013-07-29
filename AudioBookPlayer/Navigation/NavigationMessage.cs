// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationMessage.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using GalaSoft.MvvmLight.Messaging;

#endregion Using Directives

namespace AudioBookPlayer.Navigation
{
    using System;

    /// <summary> The navigation message. </summary>
    public class NavigationMessage : GenericMessage<Uri>
    {
        /// <summary> Initializes a new instance of the <see cref="NavigationMessage"/> class. </summary>
        public NavigationMessage(Uri content) : base(content)
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NavigationMessage"/> class. </summary>
        public NavigationMessage(object sender, Uri content) : base(sender, content)
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NavigationMessage"/> class. </summary>
        public NavigationMessage(object sender, object target, Uri content) : base(sender, target, content)
        {
        }
    }
}