﻿using System;
using System.IO;
using System.Linq;
using Database.Models.Songs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var isOk = true;
            var configuration = GetAppConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<SongsDbContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("SongsDbConnection"));

            using (var dbContext = new SongsDbContext(optionsBuilder.Options))
            {
                var argumentParser = new ArgumentParser(dbContext);
                argumentParser.Parse(args);

                if (argumentParser.AreAttributesCorrect)
                {
                    foreach (var command in argumentParser.Commands)
                    {
                        var isSuccess = command.Execute();
                        if (isSuccess == false)
                        {
                            isOk = false;
                            break;
                        }
                    }

                    foreach (var song in dbContext.Songs.ToList())
                    {
                        Console.WriteLine($"{song.Title}");
                    }
                }

                if (isOk)
                {
                    dbContext.SaveChanges();
                }
            }
        }


        static IConfigurationRoot GetAppConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            return builder.Build();
        }
    }
}