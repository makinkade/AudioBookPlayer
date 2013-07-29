// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioBookChooserViewModel.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Collections.ObjectModel;

using AudioBookPlayer.Resources;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Microsoft.Xna.Framework.Media;

#endregion Using Directives

namespace AudioBookPlayer.ViewModel
{
    /// <summary>
    ///     This class contains properties that the audio book chooser View can data bind to.
    ///     <para>
    ///         Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    ///     </para>
    ///     <para>
    ///         You can also use Blend to data bind with the tool's support.
    ///     </para>
    ///     <para>
    ///         See http://www.galasoft.ch/mvvm
    ///     </para>
    /// </summary>
    public class AudioBookChooserViewModel : ViewModelBase
    {
        #region Fields

        /// <summary> The albums on the phone </summary>
        private readonly ObservableCollection<Album> _albums = new ObservableCollection<Album>();

        /// <summary> The selected album </summary>
        private Album _selectedAlbum;

        #endregion Fields

        #region Properties

        /// <summary> Gets the application name. </summary>
        public static string ApplicationName
        {
            get
            {
                return AppResources.ApplicationTitle;
            }
        }

        /// <summary> Gets the main page name. </summary>
        public static string PageTitle
        {
            get
            {
                return AppResources.AudioBookChooserPageTitle;
            }
        }

        /// <summary> Gets the albums. </summary>
        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
        }

        /// <summary> Gets or sets the selected album. </summary>
        public Album SelectedAlbum
        {
            get
            {
                return _selectedAlbum;
            }

            set
            {
                _selectedAlbum = value;
                RaisePropertyChanged(() => SelectedAlbum);
            }
        }

        /// <summary> Gets the navigated to command. </summary>
        public RelayCommand NavigatedToCommand
        {
            get { return new RelayCommand(RefreshAlbums); }
        }

        #endregion Properties

        #region Private Methods

        /// <summary>
        /// The refresh albums.
        /// </summary>
        private void RefreshAlbums()
        {
            _albums.Clear();
            using (MediaLibrary mediaLibrary = new MediaLibrary())
            {
                foreach (Album album in mediaLibrary.Albums)
                {
                    _albums.Add(album);
                }
            }
        }

        #endregion Private Methds
    }
}