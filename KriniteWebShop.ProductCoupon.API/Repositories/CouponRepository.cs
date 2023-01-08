using Dapper;
using KriniteWebShop.ProductCoupon.API.Entities;
using Npgsql;

namespace KriniteWebShop.ProductCoupon.API.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly string _connectionString;

    public CouponRepository(IConfiguration configuration)
    {
        _connectionString = configuration?.GetRequiredSection("ConnectionStrings")?.GetValue<string>("CouponDb")
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<Coupon> GetCoupon(string productName)
    {
        using NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString);

        Coupon coupon = await npgsqlConnection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
        if (coupon == default)
        {
            return new Coupon
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
            new { ProductName = coupon?.ProductName, Description = coupon?.Description, Amount = coupon?.Amount });

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
            new { ProductName = coupon?.ProductName, Description = coupon?.Description, Amount = coupon?.Amount});

        return updated > 0;
    }
}
