using Microsoft.EntityFrameworkCore;
using WebApiMySQL.Data;
using WebApiMySQL.Models;
namespace WebApiMySQL.Controllers;

public static class VideoCollectionEndpointsClass
{
    public static void MapVideoCollectionEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/VideoCollection", async (WebApiMySQLContext db) =>
        {
            return await db.Videos.ToListAsync();
        })
        .WithName("GetAllVideoCollections");

        routes.MapGet("/api/VideoCollection/{id}", async (int Id, WebApiMySQLContext db) =>
        {
            return await db.Videos.FindAsync(Id)
                is VideoCollection model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetVideoCollectionById");

        routes.MapPut("/api/VideoCollection/{id}", async (int Id, VideoCollection videoCollection, WebApiMySQLContext db) =>
        {
            VideoCollection? foundModel = await db.Videos.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateVideoCollection");

        routes.MapPost("/api/VideoCollection/", async (VideoCollection videoCollection, WebApiMySQLContext db) =>
        {
            db.Videos.Add(videoCollection);
            await db.SaveChangesAsync();
            return Results.Created($"/VideoCollections/{videoCollection.Id}", videoCollection);
        })
        .WithName("CreateVideoCollection");

        routes.MapDelete("/api/VideoCollection/{id}", async (int Id, WebApiMySQLContext db) =>
        {
            if (await db.Videos.FindAsync(Id) is VideoCollection videoCollection)
            {
                db.Videos.Remove(videoCollection);
                await db.SaveChangesAsync();
                return Results.Ok(videoCollection);
            }

            return Results.NotFound();
        })
        .WithName("DeleteVideoCollection");
    }
}
