using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_MoveToFriend : BehaviourNode
{
    [SerializeField] 
    private Blackboard blackboard;
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.FRIEND, out Character point) ||
            !blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character unit))
        {
            Return(false);
            return;
        }

        unit.MoveNavmesh(point.transform);
        Return(true);
    }
}
