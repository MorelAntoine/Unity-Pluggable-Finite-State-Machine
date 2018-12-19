using System.Linq;
using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// ScriptableObject to create transition for the finite state machine
    /// </summary>
    [CreateAssetMenu(menuName = "UniCraft/PFSM/Transition")]
    public class Transition : ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private ACondition[] _conditions = null;
        
        [Header("State")]
        [SerializeField] private AState _stateOnSuccess = null;
        [SerializeField] private AState _stateOnFailure = null;

        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /// <summary>
        /// Return the resulting state based on the simulation
        /// </summary>
        public AState Simulate(Object[] datas)
        {
            return (_conditions.All(condition => condition.IsConditionMet(datas)) ? _stateOnSuccess : _stateOnFailure);
        }
    }
}
