using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginEntity.Models.ViewModels;


namespace LoginEntity.Customizations.ViewComponents
{
    public class DatiUtente : ViewComponent
    {
        public IViewComponentResult Invoke(UtentiListViewModel model)
        {
            return View(model);
        }
    }
}