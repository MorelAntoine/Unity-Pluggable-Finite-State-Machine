using UnityEngine;

namespace UniCraft.PluggableFiniteStateMachine.Example
{
    [CreateAssetMenu(menuName = "UniCraft/PFSM/Example/State/Walk")]
    public class WalkState : AState
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        /////////////////////////////////////
        ////////// Default Setting //////////

        private const string ErrorMessageNoTransform = "There is no Transform in datas[0]!";
        
        /////////////////////////////
        ////////// Setting //////////
        
        [Header("Setting")]
        [SerializeField] private float _angularSpeed = 180f;
        [SerializeField] private float _walkSpeed = 2f;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        public override void Begin(Object[] datas)
        {}

        public override void Tick(Object[] datas)
        {
            var transform = datas[0] as Transform;
            var direction = new Vector3(0f, Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (transform != null)
            {
                transform.Rotate(0f, direction.y * _angularSpeed * Time.deltaTime, 0f, Space.Self);
                transform.Translate(0f, 0f, direction.z * _walkSpeed * Time.deltaTime, Space.Self);
            }
            else
            {
                Debug.LogError(ErrorMessageNoTransform);
            }
        }
    }
}
