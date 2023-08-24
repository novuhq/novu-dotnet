namespace Novu.DTO;

public static class Pagination
{
    public static async Task<IList<T>> GetAll<T>(
        Func<PaginationQueryParams, Task<NovuPaginatedResponse<T>>> getFunc,
        PaginationQueryParams queryParams = null,
        IList<T> subscribers = null)
    {
        queryParams ??= new PaginationQueryParams();
        subscribers ??= new List<T>();

        var next = await getFunc(queryParams);

        foreach (var dto in next.Data)
        {
            subscribers.Add(dto);
        }

        if (next.HasMore)
        {
            queryParams.PageSize = queryParams.PageSize++;
            await GetAll(getFunc, queryParams, subscribers);
        }

        return subscribers;
    }
}