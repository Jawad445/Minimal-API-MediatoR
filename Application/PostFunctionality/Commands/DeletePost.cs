using Domain.Model;
using MediatR;
using System;

namespace Application.Commands;

public class DeletePost : IRequest
{
    public int postId { get; set; }
}
