using System;

namespace Activities.Models
{
    public class Activity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Activity()
        {
        }

        public Activity(Guid id, string name, string category, string description, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}