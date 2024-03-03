using Nodes;
using Plugins.Blackboard;
using UnityEngine;


public class BehaviorNode_MoveToPoint : BehaviourNode_Move
{
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.POINT_PATROL, out Transform point) 
            || !blackboard.TryGetVariable(BlackboardKeys.ROBOT, out Character unit))
        {
            Return(false);
            return;
        }
        coroutine = StartCoroutine(MoveToPosition(unit, point));
    }
    
}
