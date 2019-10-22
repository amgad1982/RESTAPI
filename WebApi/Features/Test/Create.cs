using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Features.Test
{
    public static class Index
    {
        public class Query : IRequest<Response>
        {

        }

        public class Response
        {
            public string Result { get; set; }
        }
        public class Handler : IRequestHandler<Query, Response>
        {
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(new Response { Result = "this is a response message" });
            }
        }
    }
}
