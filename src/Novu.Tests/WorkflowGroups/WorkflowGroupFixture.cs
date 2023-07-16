using Novu.Models;

namespace Novu.Tests.WorkflowGroups
{
    public class WorkflowGroupFixture : IDisposable
    {
        public NovuClient NovuClient { get; }

        public WorkflowGroupFixture()
        {
            var novuConfiguration = new NovuClientConfiguration
            {
                ApiKey = Environment.GetEnvironmentVariable("NOVU_API_KEY") ?? throw new InvalidOperationException(),
            };
            var novu = new NovuClient(novuConfiguration);

            NovuClient = novu;
        }

        public async void Dispose()
        {
            //Delete resources created
        }

    }
}
