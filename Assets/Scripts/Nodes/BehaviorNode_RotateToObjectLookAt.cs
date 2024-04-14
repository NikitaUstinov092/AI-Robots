
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_RotateToObjectLookAt : BehaviorNode_RotateToObject
{
  protected override void Run()
  {
    if (!blackboard.HasVariable(BlackboardKeys.OBJECT_DETECTED))
    {
      Return(false);
      return;
    }
    
    if (blackboard.TryGetVariable<bool>(BlackboardKeys.OBJECT_VISUAL, out var value))
    { 
      if (value) 
      { 
        Return(false);
        return; 
      }
    }
    
    var robot = blackboard.GetVariable<Character>(BlackboardKeys.UNIT);
    var target = blackboard.GetVariable<Transform>(BlackboardKeys.OBJECT_DETECTED);
        
    robot.Turn(target);
    Return(true);
  }
}
