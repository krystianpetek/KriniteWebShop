using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace KriniteWebShop.Catalog.NoSQL.API.Entities;

public record Product : IProduct<string>
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; init; }

	[BsonElement("Name")]
	public string Name { get; init; }

	public string Category { get; init; }

	public string Description { get; init; }

	public decimal Price { get; init; }
}
