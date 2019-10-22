using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IService
    {
        void RegisterService(IServiceCollection services, IConfiguration configuration);
    }
}
