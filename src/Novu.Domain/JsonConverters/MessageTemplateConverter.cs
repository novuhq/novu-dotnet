using Newtonsoft.Json.Linq;
using Novu.Domain.Models.Workflows.Step;
using Novu.Domain.Models.Workflows.Step.Message;
using Novu.Domain.Utils;

namespace Novu.Domain.JsonConverters;

/// <summary>
///     Converts the incoming JSON stream into <see cref="IMessageTemplate" /> polymorphic type
/// </summary>
/// <example>
///     <code>
///        [JsonProperty("template")]
///        [JsonConverter(typeof(MessageTemplateConverter))]
///        public IMessageTemplate Template { get; set; }
///     </code>
/// </example>
/// <see cref="EmailMessageTemplate" />
/// <see cref="SmsMessageTemplate" />
/// <see cref="ChatMessageTemplate" />
/// <see cref="PushMessageTemplate" />
/// <see cref="DigestMessageTemplate" />
/// <see cref="TriggerMessageTemplate" />
/// <see cref="DelayMessageTemplate" />
public class MessageTemplateConverter : JsonCreationConverter<IMessageTemplate>
{
    protected override IMessageTemplate Create(Type objectType, JObject jObject)
    {
        if (jObject == null)
        {
            throw new ArgumentNullException(nameof(jObject));
        }

        // All the types have the discriminator 'type' although the actual enum is different and hence not on the interface
        var typeVal = jObject.SelectToken(nameof(IMessageTemplate.Type).ToLower());
        if (typeVal is not null)
        {
            var isEnum = typeVal.ToString().TryParseEnumMember<StepTypeEnum>(out var typeEnum);
            if (isEnum)
            {
                return typeEnum switch
                {
                    StepTypeEnum.InApp => new InAppMessageTemplate(),
                    StepTypeEnum.Email => new EmailMessageTemplate(),
                    StepTypeEnum.Sms => new SmsMessageTemplate(),
                    StepTypeEnum.Chat => new ChatMessageTemplate(),
                    StepTypeEnum.Push => new PushMessageTemplate(),
                    StepTypeEnum.Digest => new DigestMessageTemplate(),
                    StepTypeEnum.Trigger => new TriggerMessageTemplate(),
                    StepTypeEnum.Delay => new DelayMessageTemplate(),
                    // important to throw to alert for new types
                    _ => throw new InvalidOperationException($"Unknown type {typeEnum}"),
                };
            }
        }

        return default;
    }
}