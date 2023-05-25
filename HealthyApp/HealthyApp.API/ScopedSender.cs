using Azure.Core;

using MediatR;

namespace HealthyApp.API
{
    public record ScopedSender<TSender>(IServiceProvider Provider)
    : ISender where TSender : ISender
    {
        public async Task<TResponse> Send<TResponse>(
            IRequest<TResponse> request, CancellationToken ct)
        {
            using (var scope = Provider.CreateScope())
            {
                var sender = scope.ServiceProvider.GetRequiredService<TSender>();
                return await sender.Send(request, ct);
            }
        }

        public async IAsyncEnumerable<TResponse> CreateStream<TResponse>(
            IStreamRequest<TResponse> request, CancellationToken ct)
        {
            using (var scope = Provider.CreateScope())
            {
                var sender = scope.ServiceProvider.GetRequiredService<TSender>();
                yield return (TResponse)sender.CreateStream(request, ct);
            }
        }

        public async IAsyncEnumerable<object?> CreateStream(object request, CancellationToken ct)
        {
            using (var scope = Provider.CreateScope())
            {
                var sender = scope.ServiceProvider.GetRequiredService<TSender>();
                yield return sender.CreateStream(request, ct);
            }
        }

        public async Task<object?> Send(object request, CancellationToken cancellationToken = default)
        {
            using (var scope = Provider.CreateScope())
            {

                var sender = scope.ServiceProvider.GetRequiredService<TSender>();
                return await sender.Send(request, cancellationToken);
            }
        }
    }
}
