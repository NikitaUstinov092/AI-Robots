
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;


public class BehavirNode_MoveToDetected : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.OBJECT_DETECTED, out Transform target) ||
            !blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character unit))
        {
            Return(false);
            return;
        }
        unit.Move(target.position);
        Return(true);
    }
}
