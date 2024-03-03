using Nodes;
using Plugins.Blackboard;
using UnityEngine;


public class BehavirNode_MoveToTarget : BehaviourNode_Move
{
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.TARGET, out Transform point) ||
            !blackboard.TryGetVariable(BlackboardKeys.ROBOT, out Character unit))
        {
            Return(false);
            return;
        }
        coroutine = StartCoroutine(MoveToPosition(unit, point));
    }
}
