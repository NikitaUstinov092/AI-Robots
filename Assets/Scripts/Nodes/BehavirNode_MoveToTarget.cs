using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;


public class BehavirNode_MoveToTarget : BehaviourNode
{
    [SerializeField] 
    private Blackboard blackboard;
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.TARGET, out Transform point) ||
            !blackboard.TryGetVariable(BlackboardKeys.ROBOT, out Character unit))
        {
            Return(false);
            return;
        }
        unit.MoveNavmesh(point.transform);
        Return(true);
    }
}
