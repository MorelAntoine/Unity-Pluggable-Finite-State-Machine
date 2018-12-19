using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine.Example
{
    [CreateAssetMenu(menuName = "UniCraft/PFSM/Example/State/Idle")]
    public class IdleState : AState
    {
        public override void Begin(Object[] datas)
        {}

        public override void Tick(Object[] datas)
        {}
    }
}
