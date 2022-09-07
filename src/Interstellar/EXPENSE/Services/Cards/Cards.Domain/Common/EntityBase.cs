
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cards.Domain.Common;

public abstract class EntityBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CardId { get; protected set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
