using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PizzaShop.WebUI.Models;
using System.Globalization;

namespace PizzaShop.WebUI.TagHelpers
{
    [HtmlTargetElement("pizza-details")]
    public class PizzaDetailsTagHelper : TagHelper
    {
        public PizzaViewModel? Pizza { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "container");

            var row = new TagBuilder("div");
            row.AddCssClass("row");

            var imageColumn = new TagBuilder("div");
            imageColumn.AddCssClass("col-md-6");

            var image = new TagBuilder("img");
            image.Attributes["src"] = Pizza.ImageUrl;
            image.Attributes["alt"] = Pizza.Name;
            image.AddCssClass("img-fluid");
            imageColumn.InnerHtml.AppendHtml(image);

            var detailsColumn = new TagBuilder("div");
            detailsColumn.AddCssClass("col-md-6");

            var name = new TagBuilder("h2");
            name.InnerHtml.Append(Pizza.Name);

            var description = new TagBuilder("p");
            description.InnerHtml.Append(Pizza.Description);

            var price = new TagBuilder("h3");
            price.InnerHtml.Append(Pizza.Price.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));

            var form = new TagBuilder("form");
            form.Attributes["action"] = "/Order/AddToCart";
            form.Attributes["method"] = "post";

            var pizzaIdInput = new TagBuilder("input");
            pizzaIdInput.Attributes["type"] = "hidden";
            pizzaIdInput.Attributes["name"] = "PizzaId";
            pizzaIdInput.Attributes["value"] = Pizza.Id.ToString();
            form.InnerHtml.AppendHtml(pizzaIdInput);

            var quantityFormGroup = new TagBuilder("div");
            quantityFormGroup.AddCssClass("form-group");

            var quantityLabel = new TagBuilder("label");
            quantityLabel.Attributes["for"] = "quantity";
            quantityLabel.InnerHtml.Append("Quantity");

            var quantityInput = new TagBuilder("input");
            quantityInput.Attributes["type"] = "number";
            quantityInput.Attributes["name"] = "Quantity";
            quantityInput.Attributes["class"] = "form-control";
            quantityInput.Attributes["value"] = "1";
            quantityInput.Attributes["min"] = "1";
            quantityInput.Attributes["max"] = "10";
            quantityInput.Attributes["required"] = "required";
            quantityFormGroup.InnerHtml.AppendHtml(quantityLabel);
            quantityFormGroup.InnerHtml.AppendHtml(quantityInput);

            var addToCartButton = new TagBuilder("button");
            addToCartButton.Attributes["type"] = "submit";
            addToCartButton.AddCssClass("btn btn-primary");
            addToCartButton.InnerHtml.Append("Add to cart");

            form.InnerHtml.AppendHtml(quantityFormGroup);
            form.InnerHtml.AppendHtml(addToCartButton);

            detailsColumn.InnerHtml.AppendHtml(name);
            detailsColumn.InnerHtml.AppendHtml(description);
            detailsColumn.InnerHtml.AppendHtml(price);
            detailsColumn.InnerHtml.AppendHtml(form);

            row.InnerHtml.AppendHtml(imageColumn);
            row.InnerHtml.AppendHtml(detailsColumn);

            output.Content.AppendHtml(row);
        }
    }
}
