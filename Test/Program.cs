using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Listings;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.Text;

//downloading categories data

var browser = new ScrapingBrowser();
browser.Encoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

var homepage = browser.NavigateToPage(new Uri(""));

var html = homepage.Html.CssSelect(".filled-blue .row");
var categoriesHtml = html.First();

var categorySubCategories = new Dictionary<string, Dictionary<string,List<string>>>();

for (int i = 0; i < categoriesHtml.ChildNodes.Count; i++)
{
    var node = categoriesHtml.ChildNodes[i];
    if (node.HasChildNodes)
    {
        for (int k = 0; k < node.ChildNodes.Count; k++)
        {
            var catNode = node.ChildNodes[k];
            if (catNode.HasChildNodes)
            {
                var parent = "";
                for (int j = 0; j < catNode.ChildNodes.Count; j++)
                {
                    var category = catNode.ChildNodes[j];
                    if (category.OuterHtml.Contains("parentCat"))
                    {
                        parent = category.InnerText.Trim();
                        if (!categorySubCategories.ContainsKey(parent))
                        {
                            categorySubCategories.Add(parent, new Dictionary<string, List<string>>());
                        }
                    }
                    if (category.OuterHtml.Contains("childCat"))
                    {
                        if (category.ChildNodes.Count > 3)
                        {
                            string categoryName = category.CssSelect("a").First().InnerText.Trim();
                            if (!categorySubCategories[parent].ContainsKey(categoryName))
                            {
                                categorySubCategories[parent].Add(categoryName, new List<string>());
                            }

                            for (int s = 0; s < category.ChildNodes.Count; s++)
                            {
                                var categorySubNode = category.ChildNodes[s];
                                var text = categorySubNode.InnerText.Trim();
                                if (text != "" && !categorySubCategories[parent][categoryName].Contains(text))
                                {
                                    categorySubCategories[parent][categoryName].Add(text);
                                }
                            }
                        }
                        else
                        {
                            var childCategoryName = category.InnerText.Trim();
                            if (!categorySubCategories[parent].ContainsKey(childCategoryName))
                            {
                                categorySubCategories[parent].Add(childCategoryName, new List<string>());
                            }
                        }
                    }
                }
            }
        }
    }
}


using (var context = new ApplicationDbContext())
{
    foreach (var kvp in categorySubCategories)
    {
        var category = context.Categories.FirstOrDefault(c => c.Name == kvp.Key);
        if (category == null)
        {
            category = new Category() { Name = kvp.Key, ParentId = null };
            context.Categories.Add(category);
            context.SaveChanges();
            Console.WriteLine(category.Name);
        }

        foreach (var subKvp in kvp.Value)
        {
            var subCategory = context.Categories.FirstOrDefault(c => c.Name == subKvp.Key);
            if (subCategory == null)
            {
                subCategory = new Category() { Name = subKvp.Key, ParentId = category.Id };
                context.Categories.Add(subCategory);
                context.SaveChanges();
            }

            if (subKvp.Value.Count > 0)
            {
                foreach (var subValue in subKvp.Value)
                {
                    var subSubCategory = context.Categories.FirstOrDefault(c => c.Name == subValue);
                    if (subSubCategory == null)
                    {
                        subSubCategory = new Category() { Name = subValue, ParentId = subCategory.Id };
                        context.Categories.Add(subSubCategory);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}


foreach (var kvp in categorySubCategories)
{
    Console.WriteLine(kvp.Key);

    foreach (var subKvp in kvp.Value)
    {
        Console.WriteLine($"-- {subKvp.Key}");

        if (subKvp.Value.Count > 0)
        {
            foreach (var subSubKvp in subKvp.Value)
            {
                Console.WriteLine($"---- {subSubKvp}");
            }
        }
    }
}

Console.WriteLine();