
using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has command line interface.");

            descriptor
                .Field(e => e.LicenseKey)
                .Ignore();

            descriptor
                .Field(e => e.Commands)
                .ResolveWith<Resolvers>(e => e.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of the available commands for this platform.");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
                => context.Commands.Where(e => e.PlatformId == platform.Id);
        }
    }
}