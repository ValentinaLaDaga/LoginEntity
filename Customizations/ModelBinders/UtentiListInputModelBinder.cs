using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginEntity.Models.InputModels;
using LoginEntity.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace LoginEntity.Customizations.ModelBinders
{
    public class UtentiListInputModelBinder : IModelBinder
    {
        public UtentiListInputModelBinder()
        {

        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            
            //Recuperiamo i valori grazie ai value provider
            string nome = bindingContext.ValueProvider.GetValue("Nome").FirstValue;
            string email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            string nazione = bindingContext.ValueProvider.GetValue("Nazione").FirstValue;
            string password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
            //int id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Id").FirstValue);
            
            
            int id;
            try
            {
                id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Id").FirstValue);
            }
            catch
            {
                id = 0;
            }
            
            
            //int id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Id").FirstValue);
 
            //Creiamo l'istanza del CourseListInputModel
            var inputModel = new UtentiListInputModel(id,nome,email,nazione,password);

            //Impostiamo il risultato per notificare che la creazione è avvenuta con successo
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            //Restituiamo un task completato
            return Task.CompletedTask;
        }
    }
}