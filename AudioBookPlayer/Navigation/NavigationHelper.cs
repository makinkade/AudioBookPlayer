// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationHelper.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using GalaSoft.MvvmLight.Messaging;

using Microsoft.Phone.Controls;

#endregion Using Directives

namespace AudioBookPlayer.Navigation
{
    /// <summary> The navigation helper. </summary>
    public class NavigationHelper
    {
        #region Fields

        /// <summary> The phene application frame. </summary>
        private PhoneApplicationFrame _frame;

        #endregion Fields

        #region Constructors

        /// <summary> Initializes a new instance of the <see cref="NavigationHelper"/> class. </summary>
        public NavigationHelper(PhoneApplicationFrame frame)
        {
            _frame = frame;
            Messenger.Default.Register<NavigationMessage>(this, uri => _frame.Navigate(uri.Content));
        }

        #endregion Constructors
    }
}
