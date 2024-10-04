﻿using CleanArchitecture.Domain.Common.App;
using MediatR;

namespace CleanArchitecture.Domain.Messaging.Query
{
    public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, ApplicationResult> where TQuery : IQuery
    {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        new Task<ApplicationResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
