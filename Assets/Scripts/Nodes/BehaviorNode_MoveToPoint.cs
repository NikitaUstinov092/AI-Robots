using Nodes;
using Plugins.Blackboard;
using UnityEngine;


public class BehaviorNode_MoveToPoint : BehaviourNode_Move
{
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.POINT_PATROL, out Transform point) 
            || !blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character unit))
        {
            Return(false);
            return;
        }
        unit.Move(point.position);
        Return(true);
    }
    
}
