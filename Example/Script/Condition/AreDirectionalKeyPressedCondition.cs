using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine.Example
{
    [CreateAssetMenu(menuName = "UniCraft/PFSM/Example/Condition/AreDirectionalKeyPressed")]
    public class AreDirectionalKeyPressedCondition : ACondition
    {
        public override bool IsConditionMet(Object[] datas)
        {
            return (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f);
        }
    }
}
