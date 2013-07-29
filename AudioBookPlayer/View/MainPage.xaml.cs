// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Windows.Navigation;

using AudioBookPlayer.ViewModel;

#endregion Using Directives

namespace AudioBookPlayer.View
{
    /// <summary> The main page. </summary>
    public partial class MainPage
    {
        // Constructor

        #region Constructors

        /// <summary> Initializes a new instance of the <see cref="MainPage"/> class. </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary> The on navigated to. </summary>
        protected override void OnNavigatedTo(NavigationEventArgs eventArgs)
        {
            base.OnNavigatedTo(eventArgs);
            ((MainViewModel)DataContext).NavigatedToCommand.Execute(eventArgs);
        }

        #endregion Methods
    }
}