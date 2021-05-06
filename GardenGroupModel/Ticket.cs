using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace GardenGroupModel
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReportedBy { get; set; }
        public DateTime ReportedDate { get; set; }
        public DateTime Deadline { get; set; }
        public TypeOfIncident Type { get; set; }

        public Priority Priority { get; set; }

        public bool IsSolved { get; set; }

        [BsonConstructor]
        public Ticket(string subject, string description, string reportedBy, DateTime reportedDate, DateTime deadline, TypeOfIncident type, Priority priority)
        {
            Subject = subject;
            Description = description;
            ReportedBy = reportedBy;
            ReportedDate = reportedDate;
            Deadline = deadline;
            Type = type;
            Priority = priority;
            IsSolved = false;
        }

        public Ticket() { }
    }
}
