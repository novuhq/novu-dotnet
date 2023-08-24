using Newtonsoft.Json;
using Novu.DTO;
using Refit;

namespace Novu.Extensions;

public static class ApiExceptionExtensions
{
    /// <summary>
    ///     Process a Refit exception, noting that Novu does not return types
    ///     where Refit throws a <see cref="ValidationApiException" />
    ///     see https://github.com/reactiveui/refit#handling-exceptions
    /// </summary>
    public static ErrorData ToErrorMessage(this ApiException apiException)
    {
        switch (apiException.HasContent)
        {
            case true:
            {
                var error = JsonConvert.DeserializeObject<ErrorData>(apiException.Content!);
                if (error is not null)
                {
                    return error;
                }

                break;
            }
        }

        return new ErrorData();
    }
}