// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;

using AudioBookPlayer.Navigation;
using AudioBookPlayer.Resources;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using Microsoft.Practices.ServiceLocation;

#endregion Using Directives

namespace AudioBookPlayer.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
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
    public class MainViewModel : ViewModelBase
    {
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
        public static string MainPageTitle
        {
            get
            {
                return AppResources.MainPageTitle;
            }
        }

        /// <summary> Gets the back button text. </summary>
        public static string BackText
        {
            get
            {
                return AppResources.BackButtonText;
            }
        }

        /// <summary> Gets the back button text. </summary>
        public static string PlayPauseText
        {
            get
            {
                return AppResources.PlayButtonText;
            }
        }

        /// <summary> Gets the next button text. </summary>
        public static string NextText
        {
            get
            {
                return AppResources.NextButtonText;
            }
        }
        
        /// <summary> Gets the select audio book text. </summary>
        public static string SelectAudioBookText
        {
            get
            {
                return AppResources.SelectAudioBookText;
            }
        }

        /// <summary> Gets the open chooser page. </summary>
        public RelayCommand OpenChooserPage
        {
            get { return new RelayCommand(OpenChooser); }
        }

        /// <summary> Gets the navigated to command. </summary>
        public RelayCommand NavigatedToCommand
        {
            get { return new RelayCommand(RefreshPage); }
        }

        /// <summary> Gets the current book name. </summary>
        public string CurrentBookName
        {
            get
            {
                if (Settings.Instance.CurrentBook != null)
                {
                    return Settings.Instance.CurrentBook.ToString();
                }

                return AppResources.NoCurrentBook;
            }
        }

        #endregion Properties

        #region Private Methods

        /// <summary> The open chooser page. </summary>
        private void OpenChooser()
        {
            Messenger.Default.Send(new NavigationMessage(new Uri("/View/AudioBookChooser.xaml", UriKind.Relative)));
        }

        /// <summary> The refresh page. </summary>
        private void RefreshPage()
        {
            AudioBookChooserViewModel audioBookChooserViewModel = ServiceLocator.Current.GetInstance<AudioBookChooserViewModel>();
            if (audioBookChooserViewModel.SelectedAlbum != null && audioBookChooserViewModel.SelectedAlbum != Settings.Instance.CurrentBook)
            {
                Settings.Instance.CurrentBook = audioBookChooserViewModel.SelectedAlbum;
                RaisePropertyChanged(() => CurrentBookName);
            }
        }

        #endregion Private Methods
    }
}