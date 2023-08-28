using Novu.DTO.Integrations;

namespace Novu.Models;

public static class IntegrationExtensions
{
    public static IntegrationEditData ToEditData(
        this Integration integration,
        Action<IntegrationEditData>? overrides = null)
    {
        var editData = new IntegrationEditData
        {
            Name = integration.Name,
            Credentials = integration.Credentials,
            Channel = integration.Channel,
            EnvironmentId = integration.EnvironmentId,
            Identifier = integration.Identifier,
            Active = integration.Active,
        };

        overrides?.Invoke(editData);

        return editData;
    }
}