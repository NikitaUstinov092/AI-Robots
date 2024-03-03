using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_Target : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;

    [SerializeField] 
    private bool requiredValue;
    protected override void Run()
    {
        var target = blackboard.HasVariable(BlackboardKeys.TARGET);
        Return(target == requiredValue);
    }
}
