using Plugins.Blackboard;
using UnityEngine;

public class BlackboardInstallerAttackScene : MonoBehaviour
{
    [SerializeField]
    private Character unit;
    
    [SerializeField]
    private int stopDistance = 4;
    private void Awake()
    {
        var blackboard = GetComponent<Blackboard>();
        blackboard.SetVariable(BlackboardKeys.REQUIRED_DISTANCE, stopDistance);
        blackboard.SetVariable(BlackboardKeys.UNIT, unit);
    }
}
