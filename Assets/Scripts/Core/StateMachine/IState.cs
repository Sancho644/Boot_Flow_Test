using System.Threading;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine
{
    public interface IState
    {
        public UniTask EnterAsync(CancellationToken ct);
        public UniTask ExitAsync(CancellationToken ct);
    }
}