using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ContoAuthApi.Accounts.Repositories.Models;

public class AccountModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
