
using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents a command for a specific platform.");

            descriptor
                .Field(e => e.Platform)
                .ResolveWith<Resolvers>(e => e.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform of the command.");
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
                => context.Platforms.FirstOrDefault(e => e.Id == command.PlatformId);
        }
    }
}