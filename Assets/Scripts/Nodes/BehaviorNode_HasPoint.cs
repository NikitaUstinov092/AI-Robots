using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_HasPoint : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;
    
    protected override void Run()
    {
        blackboard.TryGetVariable(BlackboardKeys.POINT_PATROL, out Transform point);
        Return(point != null);
    }
}
