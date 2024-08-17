﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ShowSelectDialog.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Dialog for selecting a show.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVSorter.Model;

namespace TVSorter.View
{
    /// <summary>
    ///     Dialog for selecting a show.
    /// </summary>
    public partial class ShowSelectDialog : Form
    {
        /// <summary>
        ///     The list of shows.
        /// </summary>
        private readonly List<TvShow> shows;

        /// <summary>
        /// The filtered tv shows
        /// </summary>
        private List<TvShow> filteredTvShows;

        /// <summary>
        ///     Initialises a new instance of the <see cref="ShowSelectDialog" /> class.
        /// </summary>
        /// <param name="shows">
        ///     The shows.
        /// </param>
        public ShowSelectDialog(List<TvShow> shows)
        {
            this.shows = shows;
            this.filteredTvShows = [.. this.shows.OrderBy(x => x.Name)];
            InitializeComponent();
        }

        /// <summary>
        ///     Gets SelectedShow.
        /// </summary>
        public TvShow SelectedShow { get; private set; }

        /// <summary>
        ///     Handles the Close button being clicked.
        /// </summary>
        /// <param name="sender">
        ///     The sender of the event.
        /// </param>
        /// <param name="e">
        ///     The arguments of the event.
        /// </param>
        private void CloseButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        ///     Handles the Select button being clicked.
        /// </summary>
        /// <param name="sender">
        ///     The sender of the event.
        /// </param>
        /// <param name="e">
        ///     The arguments of the event.
        /// </param>
        private void SelectButtonClick(object sender, EventArgs e)
        {
            SelectedShow = (TvShow)showList.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///     Handles the dialog loading.
        /// </summary>
        /// <param name="sender">
        ///     The sender of the event.
        /// </param>
        /// <param name="e">
        ///     The arguments of the event.
        /// </param>
        private void ShowSelectDialogLoad(object sender, EventArgs e)
        {
            showList.DisplayMember = "Name";
            showList.DataSource = filteredTvShows;
        }

        /// <summary>
        /// Filters the text box changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FilterTextBoxChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if(textBox.Text.Length >= 3)
            {
                filteredTvShows = [.. shows.Where(t => t.Name.Contains(filterTextBox.Text, StringComparison.InvariantCultureIgnoreCase)).OrderBy(x => x.Name)];
                showList.DataSource = filteredTvShows;
            }
            else
            {
                showList.DataSource = shows.OrderBy(x => x.Name).ToList();
            }
        }
    }
}
