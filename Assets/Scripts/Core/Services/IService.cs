using System.Threading;
using Cysharp.Threading.Tasks;

namespace Core.Services
{
    public interface IService
    {
        public UniTask InitializeAsync(CancellationToken ct);
        public UniTask ReleaseAsync(CancellationToken ct);
    }
}