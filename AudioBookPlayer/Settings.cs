// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.IO.IsolatedStorage;

using Microsoft.Xna.Framework.Media;

namespace AudioBookPlayer
{
    /// <summary> The settings. </summary>
    public sealed class Settings
    {
        #region Constants

        /// <summary> The current book key. </summary>
        private const string CurrentBookKey = "CurrentBookKey";

        #endregion Constants

        #region Fields

        /// <summary> The _instance. </summary>
        private static readonly Settings _instance = new Settings();

        /// <summary> The _app settings. </summary>
        private readonly IsolatedStorageSettings _appSettings = IsolatedStorageSettings.ApplicationSettings;

        /// <summary> Backing field for CurrentBook </summary>
        private Album _currentbook;

        #endregion Fields

        #region Constructors

        /// <summary> Prevents a default instance of the <see cref="Settings"/> class from being created. </summary>
        private Settings()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary> Gets the instance. </summary>
        public static Settings Instance
        {
            get { return _instance; }
        }

        /// <summary> Gets or sets the current book. </summary>
        public Album CurrentBook
        {
            get
            {
                if (_currentbook == null && _appSettings.Contains(CurrentBookKey))
                {
                    string bookName = _appSettings[CurrentBookKey] as string;
                    if (bookName != null)
                    {
                        using (MediaLibrary mediaLibrary = new MediaLibrary())
                        {
                            foreach (Album album in mediaLibrary.Albums)
                            {
                                if (album.Name == bookName)
                                {
                                    _currentbook = album;
                                    break;
                                }
                            }
                        }
                    }
                }

                return _currentbook;
            }

            set
            {
                _currentbook = value;
                _appSettings[CurrentBookKey] = value.Name;
                _appSettings.Save();
            }
        }

        #endregion Properties
    }
}