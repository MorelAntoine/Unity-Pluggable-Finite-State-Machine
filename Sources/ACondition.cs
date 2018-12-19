using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Base ScriptableObject to create condition for the finite state machine
    /// </summary>
    public abstract class ACondition : ScriptableObject
    {
        /// <summary>
        /// Verify if the condition is met or not
        /// </summary>
        public abstract bool IsConditionMet(Object[] datas);
    }
}
