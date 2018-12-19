using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine.Example
{
    [CreateAssetMenu(menuName = "UniCraft/PFSM/Example/Condition/AreDirectionalKeyReleased")]
    public class AreDirectionalKeyReleasedCondition : ACondition
    {
        public override bool IsConditionMet(Object[] datas)
        {
            return (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f);
        }
    }
}
