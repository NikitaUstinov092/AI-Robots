using Nodes;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_MoveToFriend : BehaviourNode_Move
{
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.FRIEND, out Character point) ||
            !blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character unit))
        {
            Return(false);
            return;
        }
        coroutine = StartCoroutine(MoveToPosition(unit, point.transform));
    }
}
