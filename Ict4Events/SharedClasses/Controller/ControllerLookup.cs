using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedClasses.Data;
using SharedClasses.Extensions;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace SharedClasses.Controller
{
    public class ControllerLookup<T> : ControllerMVC<ViewLookup> where T : DataModel, new()
    {
        public ControllerLookup()
        {
            View.SaveClick += ViewOnSaveClick;
            View.CancelClick += ViewOnCancelClick;
            View.CellDoubleClick += ViewOnCellDoubleClick;
        }

        public DialogResult DialogResult { get; set; }

        public IEnumerable<T> SelectedRows
        {
            get
            {
                return
                    View.DataGridView.SelectedCells.Cast<DataGridViewCell>()
                        .Select(c => c.OwningRow)
                        .Distinct()
                        .Select(r => r.DataBoundItem)
                        .Cast<T>();
            }
        }

        private void ViewOnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewOnSaveClick(sender, e);
        }

        private void ViewOnCancelClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ViewOnSaveClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public override void Activate()
        {
            var data = Values.SafeGetValue<IEnumerable<T>>("Data");

            // If no data is specified. Get all data from this DataModel.
            if (data == null)
                data = DataModel<T>.Select();

            // ToList to execute the LINQ statement.
            View.DataGridView.DataSource = data.ToList();

            // Set the description.
            var description = Values.SafeGetValue<string>("Description");
            if (!string.IsNullOrWhiteSpace(description))
                View.Description = description;
            else
                View.Description = "Selecteer een rij om verder te gaan.";
        }
    }
}