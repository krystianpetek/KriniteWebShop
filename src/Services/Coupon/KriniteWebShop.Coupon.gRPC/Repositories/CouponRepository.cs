using Dapper;
using KriniteWebShop.Coupon.gRPC.Entities;
using Npgsql;

namespace KriniteWebShop.Coupon.gRPC.Repositories;

public class CouponRepository : ICouponRepository
{
	private readonly string _connectionString;

	public CouponRepository(IConfiguration configuration)
	{
		_connectionString = configuration?.GetRequiredSection("ConnectionStrings")?.GetValue<string>("CouponDb")
			?? throw new ArgumentNullException(nameof(configuration));
	}

	public async Task<Entities.CouponEntity> GetCoupon(string productName)
	{
		using NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString);

		Entities.CouponEntity coupon = await npgsqlConnection.QueryFirstOrDefaultAsync<Entities.CouponEntity>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
		if (coupon == default)
		{
			return new Entities.CouponEntity
			{
				ProductName = "No coupon",
				Description = "No discount description",
				Amount = 0
			};
		}
		return coupon;
	}

	public async Task<bool> CreateCoupon(RestCoupon coupon)
	{
		using NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString);

		var created = await npgsqlConnection.ExecuteAsync(
			"INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
			new { coupon?.ProductName, coupon?.Description, coupon?.Amount });

		return created > 0;
	}

	public async Task<bool> DeleteCoupon(string productName)
	{
		using NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString);

		var deleted = await npgsqlConnection.ExecuteAsync(
			"DELETE FROM Coupon WHERE ProductName = @ProductName",
			new { ProductName = productName });

		return deleted > 0;
	}

	public async Task<bool> UpdateCoupon(RestCoupon coupon)
	{
		using NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString);

		var updated = await npgsqlConnection.ExecuteAsync(
			"UPDATE Coupon SET Description = @Description, Amount = @Amount WHERE ProductName = @ProductName",
			new { coupon?.ProductName, coupon?.Description, coupon?.Amount });

		return updated > 0;
	}
}
