using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SharedClasses.Data;
using SharedClasses.Extensions;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace SharedClasses.Controller
{
    public class LookupController<T> : ControllerMVC<ViewLookup> where T : DataModel, new()
    {
        public override void Activate()
        {
            var data = Values.SafeGetValue<IEnumerable<T>>("Data");

            // If no data is specified. Get all data from this DataModel.
            if (data == null)
                data = DataModel<T>.Select();

            View.DataGridView.DataSource = data.ToList();

            // Set the description.
            View.Description = Values.SafeGetValue<string>("Description");
        }
    }
}