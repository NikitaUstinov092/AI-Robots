using Plugins.Blackboard;
using UnityEngine;

public class DistanceFriendChecker : MonoBehaviour
{
    [SerializeField] 
    private Blackboard _blackboardCurrentUnit;
    
    [SerializeField] 
    private Blackboard _blackboardFriendUnit;

    [SerializeField] 
    private Transform _box;

    private void Update()
    {
        if (!_blackboardCurrentUnit.TryGetVariable<Character>( BlackboardKeys.ROBOT,out var robot1) ||
            !_blackboardFriendUnit.TryGetVariable<Character>(BlackboardKeys.ROBOT, out var robot2) ||
            !_blackboardFriendUnit.TryGetVariable<int>(BlackboardKeys.REQUIRED_DISTANCE, out var distance))
        {
            return;
        }

        if (Vector3.Distance(robot1.transform.position, robot2.transform.position) < distance)
        {
           _blackboardCurrentUnit.SetVariable(BlackboardKeys.TARGET,_box);
           _blackboardCurrentUnit.RemoveVariable(BlackboardKeys.FRIEND_NEED_NOTICE);
           _blackboardFriendUnit.SetVariable(BlackboardKeys.TARGET,_box);
           enabled = false;
        }
    }
}
