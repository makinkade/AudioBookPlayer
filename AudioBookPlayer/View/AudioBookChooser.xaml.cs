// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioBookChooser.xaml.cs" company="Kinkade Consulting Inc.">
//   All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Windows.Navigation;

using AudioBookPlayer.ViewModel;

#endregion Using Directives

namespace AudioBookPlayer.View
{
    /// <summary> The audio book chooser. </summary>
    public partial class AudioBookChooser
    {
        #region Constructors

        /// <summary> Initializes a new instance of the <see cref="AudioBookChooser"/> class. </summary>
        public AudioBookChooser()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary> The on navigated to. </summary>
        protected override void OnNavigatedTo(NavigationEventArgs eventArgs)
        {
            base.OnNavigatedTo(eventArgs);
            ((AudioBookChooserViewModel)DataContext).NavigatedToCommand.Execute(eventArgs);
        }

        #endregion Methods
    }
}