using ErrorOr;
using Fahrschule.Domain.LehrerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Application.Lehrers.Queries.GetAllLehrer
{
    public record GetAllLehrerQuery() : IRequest<ErrorOr<List<Lehrer>>>
    { }
}