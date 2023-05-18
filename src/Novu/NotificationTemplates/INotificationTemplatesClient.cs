using Novu.DTO;
using Refit;

namespace Novu.NotificationTemplates;

public record NovuResponse<T>(T Data);
public interface INotificationTemplatesClient
{
    [Get("/notification-templates")]
    public Task<PaginatedResponseDto<NotificationTemplate>> GetTemplates([Query] int page = 0, [Query] int limit = 10);

    [Delete("/notification-templates/{templateId}")]
    public Task DeleteTemplate(string templateId);
    
    [Get("/notification-templates/{templateId}")]
    public Task<NovuResponse<NotificationTemplate>> GetTemplate(string templateId);

    [Put("/notification-templates/{templateId}/status")]
    public Task<NovuResponse<NotificationTemplate>> UpdateStatus(string templateId, [Body]UpdateTemplateStatusRequest request);
}