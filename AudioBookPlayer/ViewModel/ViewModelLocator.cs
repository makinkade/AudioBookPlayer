// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

#endregion Using Directives

namespace AudioBookPlayer.ViewModel
{
    /// <summary>
    ///     This class contains static references to all the view models in the
    ///     application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region Constructors

        /// <summary> Initializes a new instance of the ViewModelLocator class. </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AudioBookChooserViewModel>();
        }

        #endregion Constructors

        #region Public Properties

        /// <summary> Gets the main. </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary> Gets the audio book chooser view model. </summary>
        public AudioBookChooserViewModel AudioBookChooser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AudioBookChooserViewModel>();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary> The cleanup. </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        #endregion Public Methods
    }
}