using Plugins.Blackboard;
using UnityEngine;

[RequireComponent(typeof(Blackboard))]
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField] 
        private Character unit;
        [SerializeField] 
        private Character friend;
        private void Awake()
        {
            var blackboard = GetComponent<Blackboard>();
            blackboard.SetVariable(BlackboardKeys.ROBOT, unit);
            blackboard.SetVariable(BlackboardKeys.FRIEND, friend);
            blackboard.SetVariable(BlackboardKeys.REQUIRED_DISTANCE, 2);
        }
    }


