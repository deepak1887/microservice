using Marten.Pagination;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductQueryHandler was called with {@query}", query);
        var products = await session.Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10);
        return new GetProductResult(products);
    }
}
