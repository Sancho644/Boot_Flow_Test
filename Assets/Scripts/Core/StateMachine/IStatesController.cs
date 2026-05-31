using System.Threading;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine
{
    public interface IStatesController<in TEnum>
    {
        public UniTask EnterStateAsync(TEnum code, CancellationToken ct);
    }
}