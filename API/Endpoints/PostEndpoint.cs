using API.Abstractions;
using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints;

public class PostEndpoint : IEndpointDefination
{
    public void registerEndpoints(WebApplication app)
    {
        var post = app.MapGroup("api/posts");

        post.MapGet("", async (IMediator mediator) => {
            return Results.Ok(await mediator.Send(new GetPosts()));
        });

        post.MapGet("/{id}", async (IMediator mediator, int id) =>
        {
            var post = await mediator.Send(new GetPostById { Id = id });
            return Results.Ok(post);
        }).WithName("GetPostById");

        post.MapPost("", async (IMediator mediator, [FromBody] string content) => {
            CreatePost postCommand = new CreatePost { postContent = content };
            var CreatedPost = await mediator.Send(postCommand);
            return Results.CreatedAtRoute("GetPostById", new { CreatedPost.Id }, CreatedPost);
        });

        post.MapPut("/{id}", async (IMediator mediator, int id, [FromBody] string Content) => {
            UpdatePost postCommand = new UpdatePost { content = Content, postId = id };
            return Results.Ok(await mediator.Send(postCommand));
        });

        post.MapDelete("/{id}", async (IMediator mediator, int id) => {
            await mediator.Send(new DeletePost { postId = id });
            Results.NoContent();
        });

    }
}
