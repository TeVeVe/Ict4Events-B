﻿using System;
using ProductRentalApplication.Views;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ProductRentalApplication.Controller
{
    public class ControllerProductDetail : ControllerMVC<ViewProductDetail>
    {
        public ControllerProductDetail(Product product = null)
        {
            View.Product = product;
            View.ButtonCancelClick += ViewOnButtonCancelClick;
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}