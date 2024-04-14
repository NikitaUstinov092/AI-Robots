using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNone_TargetVisual : BehaviourNode
{
    [SerializeField]
    private bool requiredValue;

    [SerializeField]
    private Blackboard blackboard;
    protected override void Run()
    {
        blackboard.TryGetVariable<bool>(BlackboardKeys.OBJECT_VISUAL, out var value);
        Return(value == requiredValue);
    }
}
