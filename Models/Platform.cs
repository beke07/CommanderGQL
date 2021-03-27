using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents any software or service that has command line interface.")]
    public class Platform
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [GraphQLDescription("Represents a purchased, valid license for the platform.")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}