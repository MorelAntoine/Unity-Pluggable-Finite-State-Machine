using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Base ScriptableObject to create state for the finite state machine
    /// </summary>
    public abstract class AState : ScriptableObject
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [Header("Configuration")]
        [SerializeField] private Transition[] _transitions = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /////////////////////////
        ////////// API //////////
        
        /// <summary>
        /// Attempt to return the next state based on the transitions
        /// </summary>
        public AState AttemptToGetNextState(Object[] datas)
        {
            foreach (var transition in _transitions)
            {
                var resultingState = transition.Simulate(datas);
                if ( resultingState != null )
                {
                    return (resultingState);
                }
            }
            return (null);
        }
        
        //////////////////////////////
        ////////// Callback //////////

        /// <summary>
        /// Call once the state is loaded
        /// </summary>
        public abstract void Begin(Object[] datas);

        /// <summary>
        /// Call every Fixed Update
        /// </summary>
        public abstract void Tick(Object[] datas);
    }
}
