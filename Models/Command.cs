using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents a command for a specific platform.")]
    public class Command
    {
        public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        public string CommandLine { get; set; }

        [Required]
        public int PlatformId { get; set; }
        
        [GraphQLDescription("Represents a platform for this command.")]
        public Platform Platform { get; set; }
    }
}