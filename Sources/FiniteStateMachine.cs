using UniCraft.AttributeCollection;
using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine
{
    /// <inheritdoc/>
    /// <summary>
    /// Module to manage a finite state machine (states and transitions)
    /// </summary>
    [AddComponentMenu("UniCraft/PFSM")]
    [DisallowMultipleComponent]
    public class FiniteStateMachine : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        /////////////////////////////////////
        ////////// Default Setting //////////

        private const string ErrorMessageNoEntryState = "[Finite State Machine] There is no entry state!";
        
        ///////////////////////////////////
        ////////// Configuration //////////
        
        [Header("Configuration")]
        [SerializeField] protected Object[] Datas = null;
        [SerializeField] protected AState EntryState = null;
        
        /////////////////////////////////
        ////////// Information //////////
        
        [Header("Information")]
        [SerializeField, DisableInInspector] protected AState CurrentState = null;
        [SerializeField, DisableInInspector] protected AState PreviousState = null;
        
        /////////////////////////////
        ////////// Setting //////////
        
        [Header("Setting")]
        [SerializeField] protected bool DisplayDebugLog = false;
        [SerializeField] protected bool PauseMachine = false;
        
        //////////////////////////////
        ////////// Property //////////
        //////////////////////////////
        
        public AState GetCurrentState => CurrentState;
        public AState GetPreviousState => PreviousState;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        ///////////////////////////////
        ////////// Mechanism //////////

        /// <summary>
        /// Initialize the finite state machine
        /// </summary>
        protected virtual void Initialize()
        {
            CurrentState = EntryState;
            if ( CurrentState == null )
            {
                Debug.LogError(ErrorMessageNoEntryState);
            }
        }

        /// <summary>
        /// Execute the current state action
        /// </summary>
        protected virtual void Execute()
        {
            if ( (CurrentState != null) && (!PauseMachine) )
            {
                CurrentState.Tick(Datas);
            }
        }

        /// <summary>
        /// Attempt to transit to the next state
        /// </summary>
        protected virtual void UpdateCurrentState()
        {
            if ( (CurrentState != null) && (!PauseMachine) )
            {
                var nextState = CurrentState.AttemptToGetNextState(Datas);
                if ( nextState != null )
                {
                    PreviousState = CurrentState;
                    CurrentState = nextState;
                    CurrentState.Begin(Datas);
                    if ( DisplayDebugLog )
                    {
                        DisplayTransitionLog();
                    }
                }
            }
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour Callback //////////

        private void Awake()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            Execute();
        }

        private void Update()
        {
            UpdateCurrentState();
        }
        
        /////////////////////////////
        ////////// Service //////////

        /// <summary>
        /// Display the registered transition: previous to current
        /// </summary>
        public void DisplayTransitionLog()
        {
            Debug.Log(PreviousState.GetType().Name + " --> " + CurrentState.GetType().Name);
        }
    }
}
