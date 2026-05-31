using System.Threading;
using Cysharp.Threading.Tasks;

namespace Core.Services
{
    public abstract class AbstractService : IService
    {
        protected CancellationTokenSource ServiceCts;

        public virtual UniTask InitializeAsync(CancellationToken ct)
        {
            ServiceCts = CancellationTokenSource.CreateLinkedTokenSource(ct);

            return UniTask.CompletedTask;
        }

        public virtual UniTask ReleaseAsync(CancellationToken ct)
        {
            ServiceCts?.Cancel();
            ServiceCts?.Dispose();

            return UniTask.CompletedTask;
        }
    }
}