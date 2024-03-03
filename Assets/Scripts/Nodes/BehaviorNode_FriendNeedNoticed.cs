using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_FriendNeedNoticed : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;

    [SerializeField] 
    private bool requiredValue;
    protected override void Run()
    {
        var friend = blackboard.HasVariable(BlackboardKeys.FRIEND_NEED_NOTICE);
        Return(friend == requiredValue);
    }
}
