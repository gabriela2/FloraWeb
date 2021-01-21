using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.FlowerCategories.Any())
                {
                    var categoriesData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");

                    var categories = JsonSerializer.Deserialize<List<FlowerCategory>>(categoriesData);

                    foreach (var item in categories)
                    {
                        context.FlowerCategories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.FlowerTypes.Any())
                {
                    var typesData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<FlowerType>>(typesData);

                    foreach (var item in types)
                    {
                        context.FlowerTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/flowers.json");

                    var flowers = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in flowers)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}