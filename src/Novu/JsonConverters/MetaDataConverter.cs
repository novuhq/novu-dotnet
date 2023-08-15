using Newtonsoft.Json.Linq;
using Novu.Models.Workflows.Step;

namespace Novu.JsonConverters;

/// <summary>
///     Converts the incoming JSON stream into <see cref="IWorkflowMetaData" /> polymorphic type
/// </summary>
/// <see cref="DigestRegularMetadata" />
/// <see cref="DigestTimedMetadata" />
/// <see cref="DelayRegularMetadata" />
/// <see cref="DelayScheduledMetadata" />
/// <remarks>
///     TODO: link—Specified in step/index.ts
/// </remarks>
public class MetaDataConverter : JsonCreationConverter<IWorkflowMetaData>
{
    protected override IWorkflowMetaData Create(Type objectType, JObject jObject)
    {
        if (jObject == null)
        {
            throw new ArgumentNullException(nameof(jObject));
        }

        // All the types have the discriminator 'type' although the actual enum is different and hence not on the interface
        var typeVal = jObject.SelectToken(nameof(DelayRegularMetadata.Type).ToLower());
        if (typeVal is not null)
        {
            var val = typeVal.ToString();
            var couldBeDigest = val.TryParseEnumMember<DigestTypeEnum>(out var digestTypeEnum);
            var couldBeDelay = val.TryParseEnumMember<DelayTypeEnum>(out var delayTypeEnum);

            if (couldBeDigest && digestTypeEnum == DigestTypeEnum.Timed)
            {
                return new DigestTimedMetadata();
            }

            if (couldBeDelay && delayTypeEnum == DelayTypeEnum.Scheduled)
            {
                return new DelayScheduledMetadata();
            }

            // delay detection of 'regular' with the required 'amount' MUST be before digest (below)
            if (couldBeDelay &&
                delayTypeEnum == DelayTypeEnum.Regular &&
                jObject.SelectToken(nameof(DelayRegularMetadata.Amount).ToLower()) is not null)
            {
                return new DelayRegularMetadata();
            }

            // Given all other forms are detected the ambiguous 'regular' of digest is the only version left

            // 1. unique if backoff
            // 2. detect regular with other attributes (backoff (amount & unit) or updateModel)
            if (couldBeDigest && digestTypeEnum is DigestTypeEnum.Backoff or DigestTypeEnum.Regular)
            {
                return new DigestRegularMetadata();
            }
        }

        // but actually what's happening isn't quite this so now start the hacks

        // detected 'timed' because there is no type
        if (jObject.SelectToken(nameof(DigestTimedMetadata.Timed).ToLower()) is not null)
        {
            return new DigestTimedMetadata();
        }

        // TODO: what to do if not detected?
        return new DigestTimedMetadata();
    }
}