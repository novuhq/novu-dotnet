namespace Novu.NET.DTO;

public record Template
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public bool Active { get; set; }
    
    public bool Draft { get; set; }
    
    public PreferenceSettings PreferenceSettings { get; set; }
    
    public bool Critical { get; set; }
    
    public List<string> Tags { get; set; }
    
    public List<TemplateSteps> Steps { get; set; }
    
    public string OrganizationId { get; set; }
    
    public string CreatorId { get; set; }

    public string EnvironmentId { get; set; }
    
    public List<TemplateTrigger> Triggers { get; set; }
    
    public string NotificationGroupId { get; set; }
    
    public string ParentId { get; set; }
    
    public bool Deleted { get; set; }
    
    public DateTimeOffset DeletedAt { get; set; }
    
    public string DeletedBy { get; set; }
    
    public dynamic NotificationGroup { get; set; }
    
    public string TemplateIdentifier { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public string TransactionId { get; set; }
    
    public string Channel { get; set; }
    
    public bool Seen { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    public string DirectWebhookurl { get; set; }
    public string ProviderId { get; set; }
    
    public List<string> DeviceTokens { get; set; }
    
    public string Title { get; set; }
    
    public DateTimeOffset LastSeenDate { get; set; }
    
    public dynamic Cta { get; set; }
    
    public string FeedId { get; set; }
    
    public string Status { get; set; }
    
    public string ErrorId { get; set; }
    
    public string ErrorText { get; set; }
    
    public dynamic Payload { get; set; }
    
    public dynamic Overrides { get; set; }
    
    public string Subject { get; set; }
}

public record PreferenceSettings
{
    public bool Email { get; set; }
    
    public bool Sms { get; set; }
    
    public bool InApp { get; set; }

    public bool Chat { get; set; } 
    
    public bool Push { get; set; }
}

public record TemplateSteps
{
    public string Id { get; set; }
    
    public string TemplateId { get; set; }
    
    public bool Active { get; set; }
    
    public bool ShouldStopOnFail { get; set; }
    
    public Template Template { get; set; }
    
    // TODO: Get typing
    public List<dynamic> Filters { get; set; }
    
    public string ParentId { get; set; }
    
    // TODO: Get typing
    public dynamic Metadata { get; set; }
    
    // TODO: Get typing
    public dynamic ReplyCallback { get; set; }
}

public record TemplateTrigger
{
    public string Type { get; set; }
    
    public string Identifier { get; set; }
    
    public List<dynamic> Variables { get; set; }
    
    public List<dynamic> SubscriberVariables { get; set; }
}