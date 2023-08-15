using Newtonsoft.Json.Linq;
using Novu.Models.Workflows.Step;
using Novu.Models.Workflows.Step.Message;

namespace Novu.JsonConverters;

/// <summary>
///     Converts the incoming JSON stream into <see cref="IMessageTemplate" /> polymorphic type
/// </summary>
/// <see cref="EmailMessageTemplate" />
/// <see cref="SmsMessageTemplate" />
/// <see cref="InAppMessageTemplate" />
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
                    StepTypeEnum.Email => new InAppMessageTemplate(),
                    StepTypeEnum.Sms => new SmsMessageTemplate(),
                    StepTypeEnum.Chat => new ChatMessageTemplate(),
                    StepTypeEnum.Push => new PushMessageTemplate(),
                    StepTypeEnum.Digest => new DigestMessageTemplate(),
                    StepTypeEnum.Trigger => new TriggerMessageTemplate(),
                    StepTypeEnum.Delay => new DelayMessageTemplate(),
                    _ => throw new InvalidOperationException($"Unknown type {typeEnum}"),
                };
            }
        }

        return default;
    }
}