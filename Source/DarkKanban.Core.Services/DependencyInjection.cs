using System;
using System.Linq;
using DarkKanban.Core.Contracts.Interfaces.Services;
using DarkKanban.Core.Services.Board;
using DarkKanban.Core.Services.BoardView;
using DarkKanban.Core.Services.Column;
using DarkKanban.Core.Services.Record;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DarkKanban.Core.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            var domainAssemblies =
                AppDomain.CurrentDomain.GetAssemblies()
                    .Where(arg =>
                    {
                        var name = arg.GetName().Name;
                        return name != null && name.StartsWith("DarkKanban");
                    }).ToArray();

            services.AddAutoMapper(domainAssemblies);
            services.AddMediatR(domainAssemblies);
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IColumnService, ColumnService>();
            services.AddScoped<IRecordService, RecordService>();
            services.AddScoped<IBoardViewService, BoardViewService>();
            
            return services;
        }
    }
}