
using Labb3API.Data;
using Labb3API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<PersonInterestDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //Return all persons
            app.MapGet("/persons", async (PersonInterestDbContext context) =>
            {
                var persons = await context.Persons.ToListAsync();
                if (persons == null || !persons.Any())
                {
                    return Results.NotFound("Could not find any persons");
                }
                return Results.Ok(persons);
            });

            //Create a new person
            app.MapPost("/persons", async (Person person, PersonInterestDbContext context) =>
            {
                context.Persons.Add(person);
                await context.SaveChangesAsync();
                return Results.Created($"/persons/{person.PersonId}", person);

            });
           

            //Return all interests
            app.MapGet("/interests", async (PersonInterestDbContext context) =>
            {
                var interests = await context.Interests.ToListAsync();
                if (interests == null || !interests.Any())
                {
                    return Results.NotFound("Could not find any interests");
                }
                return Results.Ok(interests);
            });

            //Create a new interest
            app.MapPost("/interests", async (Interest interest, PersonInterestDbContext context) =>
            {
                context.Interests.Add(interest); 
                await context.SaveChangesAsync();
                return Results.Created($"/interests/{interest.InterestId}", interest); // Uppdatera också URL:en
            });

            // Endpoint för att hämta alla intressen för en specifik person
            app.MapGet("/persons/{personId}/interests", async (int personId, PersonInterestDbContext context) =>
            {

                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Could not find the specified person");
                }
                var personInterests = await context.PersonInterests
                                                    .Where(pi => pi.FkPersonId == personId)
                                                    .ToListAsync();
                var interests = new List<Interest>();
                foreach (var personInterest in personInterests)
                {
                    var interest = await context.Interests.FindAsync(personInterest.FkInterestId);
                    if (interest != null)
                    {
                        interests.Add(interest);
                    }
                }
                if (!interests.Any())
                {
                    return Results.NotFound("Could not find any interests for the specified person");
                }

                return Results.Ok(interests);
            });
            app.MapPost("/persons/{personId}/interests", async (int personId, Interest newInterest, PersonInterestDbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Could not find the specified person");
                }
                var existingInterest = await context.Interests.FirstOrDefaultAsync(i => i.Title == newInterest.Title);
                if (existingInterest == null)
                {
                    context.Interests.Add(newInterest);
                    await context.SaveChangesAsync();
                    existingInterest = newInterest;
                }
                var personInterest = new PersonInterest
                {
                    FkPersonId = personId,
                    FkInterestId = existingInterest.InterestId
                };
                context.PersonInterests.Add(personInterest);
                await context.SaveChangesAsync();
                return Results.Created($"/persons/{personId}/interests/{existingInterest.InterestId}", personInterest);
            });
            app.MapPost("/person/{personId}/interests/{interestId}", async (int personId, int interestId, PersonInterestDbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);
                var interest = await context.Interests.FindAsync(interestId);

                if (person == null || interest == null)
                {
                    return Results.NotFound("Person or interest not found.");
                }
                var existingInterest = await context.PersonInterests
                                                    .Where(pi => pi.FkPersonId == personId && pi.FkInterestId == interestId)
                                                    .FirstOrDefaultAsync();

                if (existingInterest != null)
                {
                    return Results.Conflict("Person already has this interest.");
                }
                var personInterest = new PersonInterest
                {
                    FkPersonId = personId,
                    FkInterestId = interestId
                };
                context.PersonInterests.Add(personInterest);
                await context.SaveChangesAsync();
                return Results.Created($"/person/{personId}/interests/{interestId}", personInterest);
            });
            app.MapGet("/links", async (PersonInterestDbContext context) =>
            {
                var links = await context.Links.ToListAsync();
                if (links == null || !links.Any())
                {
                    return Results.NotFound("Could not find any links");
              }
               return Results.Ok(links);
            });
            app.MapPost("/links", async (Link link, PersonInterestDbContext context) =>
            {
               context.Links.Add(link);
                await context.SaveChangesAsync();
               return Results.Created($"/interests/{link.LinkId}", link);
            });
            app.MapGet("/persons/{personId}/links", async (int personId, PersonInterestDbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Could not find the specified person");
                }
                var personInterests = await context.PersonInterests
                                                    .Where(pi => pi.FkPersonId == personId)
                                                    .ToListAsync();
                var links = new List<Link>();
                foreach (var personInterest in personInterests)
                {
                    var interestLinks = await context.Links
                                                    .Where(link => link.FkInterestId == personInterest.FkInterestId)
                                                    .ToListAsync();
                    links.AddRange(interestLinks);
                }

                if (!links.Any())
                {
                    return Results.NotFound("Could not find any links for the specified person");
                }

                return Results.Ok(links);
            });
            app.MapPost("/persons/{personId}/interests/{interestId}/links", async (int personId, int interestId, Link link, PersonInterestDbContext context) =>
            {
                var person = await context.Persons.FindAsync(personId);
                var interest = await context.Interests.FindAsync(interestId);

                if (person == null || interest == null)
                {
                    return Results.NotFound("Person or interest not found.");
                }
                link.FkInterestId = interestId;
                context.Links.Add(link);
                await context.SaveChangesAsync();
                return Results.Created($"/persons/{personId}/interests/{interestId}/links/{link.LinkId}", link);
            });

            app.Run();
        }
    }
}
