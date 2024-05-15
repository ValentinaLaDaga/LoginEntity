using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginEntity.Models.ViewModels;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LoginEntity.Customizations.TagHelpers
{
    public class DatiUtenteTagHelper : TagHelper
    {
        public UtentiViewModel Utente {get;set;}
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
             output.TagName = "tr";
             output.Content.AppendHtml($"<td>{Utente.Id}</td>");
             output.Content.AppendHtml($"<td>{Utente.Nome}</td>");
             output.Content.AppendHtml($"<td>{Utente.Email}</td>");
             output.Content.AppendHtml($"<td>{Utente.Nazione}</td>");
             output.Content.AppendHtml($"<td>{Utente.Password}</td>");
             output.Content.AppendHtml($"<td><a href=\"Update\\{Utente.Id}\">updateUser</a></td>");
             output.Content.AppendHtml($"<td><a href=\"DeleteRecord\\{Utente.Id}\">deleteUser</a></td>");

            /*
				@foreach (UtentiViewModel utente in Model.Utenti)
				{
					<tr>
						<td>@utente.Id</td>
						<td>@utente.Nome</td>
						<td>@utente.Email</td>
						<td>@utente.Nazione</td>
						<td>@utente.Password</td>
						<td><a asp-controller="Utenti" asp-action="Update" asp-route-id="@utente.Id">updateUser</a></td>
						<td><a asp-controller="Utenti" asp-action="DeleteRecord" asp-route-id="@utente.Id">deleteUser</a></td>
					</tr>
				}
            */
        }
        
    }
}