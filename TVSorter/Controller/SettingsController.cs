﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="SettingsController.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The controller for the settings tab.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TVSorter.Controller
{
    #region Using Directives

    using TVSorter.View;

    using Settings = TVSorter.Settings;

    #endregion

    /// <summary>
    /// The controller for the settings tab.
    /// </summary>
    public class SettingsController : ControllerBase
    {
        #region Fields

        /// <summary>
        ///   The current settings.
        /// </summary>
        private Settings settings;

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets the settings.
        /// </summary>
        public Settings Settings
        {
            get
            {
                return this.settings;
            }

            private set
            {
                this.settings = value;
                this.OnPropertyChanged("Settings");
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initialises the controller.
        /// </summary>
        /// <param name="view">
        /// The view the controller is for. 
        /// </param>
        public override void Initialise(IView view)
        {
            this.Revert();
        }

        /// <summary>
        /// Reverts the settings.
        /// </summary>
        public void Revert()
        {
            this.Settings = new Settings();
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        public void Save()
        {
            this.settings.Save();
        }

        #endregion
    }
}