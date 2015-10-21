using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using MovieStoreUserUI.Models;
using IModelBinder = System.Web.Mvc.IModelBinder;
using ModelBindingContext = System.Web.ModelBinding.ModelBindingContext;

namespace MovieStoreAdminUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "ShoppingCart";

        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            ShoppingCart cart = null;
            if (controllerContext.HttpContext.Session!=null)
            {
                cart = (ShoppingCart) controllerContext.HttpContext.Session[sessionKey];
            }

            if (cart == null)
            {
                cart = new ShoppingCart();
                if (controllerContext.HttpContext.Session !=null)
                {
                    {
                        controllerContext.HttpContext.Session[sessionKey] = cart;
                    }
                }
            }
            return cart;
        }
    }
}