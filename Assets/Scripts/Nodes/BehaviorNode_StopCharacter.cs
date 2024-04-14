using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_StopCharacter : BehaviourNode
{
    [SerializeField] 
    private bool requiredValue;
    
    [SerializeField]
    private Blackboard blackboard;
    protected override void Run()
    {
        var character = blackboard.GetVariable<Character>(BlackboardKeys.UNIT);
        blackboard.TryGetVariable<bool>(BlackboardKeys.CLOSE_TO_OBJECT, out var value);
        if (value != requiredValue)
        {
            Return(true);
        }
        else
        {
            character.Stop();
            Return(false);
        }
    }
}