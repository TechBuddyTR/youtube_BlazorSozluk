using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Infrastructure.Persistence.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BlazorSozlukContext dbContext) : base(dbContext)
    {
    }
}
