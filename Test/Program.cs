using MyMarket.DAL.Data;
using MyMarket.DAL.Models.Listings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.Text;

//downloading makes and models data
var driver = new ChromeDriver();
driver.Navigate().GoToUrl("");

var makeSelectElement = new SelectElement(driver.FindElement(By.Name("marka")));

int index = 1;
foreach (IWebElement option in makeSelectElement.Options.Skip(1))
{
    var makeOption = new StaticOption();
    using (var context = new ApplicationDbContext())
    {
        Console.WriteLine(option.Text);
        makeOption.Value = option.Text;
        makeOption.PropertyId = 4;

        context.StaticOptions.Add(makeOption);
        context.SaveChanges();
    }

    makeSelectElement.SelectByIndex(index);
    index++;

    var modelSelectElement = new SelectElement(driver.FindElement(By.Name("model")));

    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    wait.Until(drv => drv.FindElement(By.Name("model")).FindElements(By.TagName("option")).Count > 1);

    modelSelectElement = new SelectElement(driver.FindElement(By.Name("model")));

    foreach (IWebElement modelOption in modelSelectElement.Options.Skip(1))
    {
        Console.Write("-- ");
        Console.WriteLine(modelOption.Text);
        using(var context = new ApplicationDbContext())
        {
            var modelOption2 = new StaticOption()
            {
                Value = modelOption.Text,
                PropertyId = 5,
                ParentId = makeOption.Id
            };

            context.StaticOptions.Add(modelOption2);
            context.SaveChanges();
        }
    }
}

// Select the first option (after the default one)
//makeSelectElement.SelectByIndex(1); // Indices are zero-based and the first option is usually "-- select --" or similar

// Wait for the model options to load
// Here you might need to add some delay or intelligent wait for the element to refresh

//var modelSelectElement = new SelectElement(driver.FindElement(By.Name("model")));

// Get options
//List<string> modelOptions = new List<string>();
//foreach (IWebElement option in modelSelectElement.Options)
//{
// modelOptions.Add(option.Text);
// Here you can also add code to save this option to your database, using the previously selected make as parent
//}



//downloading categories data

//var homepage = browser.NavigateToPage(new Uri(""));

//var html = homepage.Html.CssSelect(".filled-blue .row");
//var categoriesHtml = html.First();

//var categorySubCategories = new Dictionary<string, Dictionary<string, List<string>>>();

//for (int i = 0; i < categoriesHtml.ChildNodes.Count; i++)
//{
//    var node = categoriesHtml.ChildNodes[i];
//    if (node.HasChildNodes)
//    {
//        for (int k = 0; k < node.ChildNodes.Count; k++)
//        {
//            var catNode = node.ChildNodes[k];
//            if (catNode.HasChildNodes)
//            {
//                var parent = "";
//                for (int j = 0; j < catNode.ChildNodes.Count; j++)
//                {
//                    var category = catNode.ChildNodes[j];
//                    if (category.OuterHtml.Contains("parentCat"))
//                    {
//                        parent = category.InnerText.Trim();
//                        if (!categorySubCategories.ContainsKey(parent))
//                        {
//                            categorySubCategories.Add(parent, new Dictionary<string, List<string>>());
//                        }
//                    }
//                    if (category.OuterHtml.Contains("childCat"))
//                    {
//                        if (category.ChildNodes.Count > 3)
//                        {
//                            string categoryName = category.CssSelect("a").First().InnerText.Trim();
//                            if (!categorySubCategories[parent].ContainsKey(categoryName))
//                            {
//                                categorySubCategories[parent].Add(categoryName, new List<string>());
//                            }

//                            for (int s = 0; s < category.ChildNodes.Count; s++)
//                            {
//                                var categorySubNode = category.ChildNodes[s];
//                                var text = categorySubNode.InnerText.Trim();
//                                if (text != "" && !categorySubCategories[parent][categoryName].Contains(text))
//                                {
//                                    categorySubCategories[parent][categoryName].Add(text);
//                                }
//                            }
//                        }
//                        else
//                        {
//                            var childCategoryName = category.InnerText.Trim();
//                            if (!categorySubCategories[parent].ContainsKey(childCategoryName))
//                            {
//                                categorySubCategories[parent].Add(childCategoryName, new List<string>());
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }
//}


//using (var context = new ApplicationDbContext())
//{
//    foreach (var kvp in categorySubCategories)
//    {
//        var category = context.Categories.FirstOrDefault(c => c.Name == kvp.Key);
//        if (category == null)
//        {
//            category = new Category() { Name = kvp.Key, ParentId = null };
//            context.Categories.Add(category);
//            context.SaveChanges();
//            Console.WriteLine(category.Name);
//        }

//        foreach (var subKvp in kvp.Value)
//        {
//            var subCategory = context.Categories.FirstOrDefault(c => c.Name == subKvp.Key);
//            if (subCategory == null)
//            {
//                subCategory = new Category() { Name = subKvp.Key, ParentId = category.Id };
//                context.Categories.Add(subCategory);
//                context.SaveChanges();
//            }

//            if (subKvp.Value.Count > 0)
//            {
//                foreach (var subValue in subKvp.Value)
//                {
//                    var subSubCategory = context.Categories.FirstOrDefault(c => c.Name == subValue);
//                    if (subSubCategory == null)
//                    {
//                        subSubCategory = new Category() { Name = subValue, ParentId = subCategory.Id };
//                        context.Categories.Add(subSubCategory);
//                        context.SaveChanges();
//                    }
//                }
//            }
//        }
//    }
//}


//foreach (var kvp in categorySubCategories)
//{
//    Console.WriteLine(kvp.Key);

//    foreach (var subKvp in kvp.Value)
//    {
//        Console.WriteLine($"-- {subKvp.Key}");

//        if (subKvp.Value.Count > 0)
//        {
//            foreach (var subSubKvp in subKvp.Value)
//            {
//                Console.WriteLine($"---- {subSubKvp}");
//            }
//        }
//    }
//}

//Console.WriteLine();