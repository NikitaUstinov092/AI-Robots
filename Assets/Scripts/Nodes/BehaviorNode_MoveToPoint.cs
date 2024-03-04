using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;


public class BehaviorNode_MoveToPoint : BehaviourNode
{
    [SerializeField] 
    private Blackboard blackboard;
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.POINT_PATROL, out Transform point) 
            || !blackboard.TryGetVariable(BlackboardKeys.ROBOT, out Character unit))
        {
            Return(false);
            return;
        }
        unit.MoveNavmesh(point.transform);
        Return(true);
    }
    
}
