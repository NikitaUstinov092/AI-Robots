using System.Collections;
using System.Collections.Generic;
using Plugins.Blackboard;
using UnityEngine;

public class CloseToFreindSensor : MonoBehaviour
{
    [SerializeField] 
    private Blackboard _blackboardCurrentUnit;

    [SerializeField] 
    private DistanceFriendChecker _distanceFriendChecker;
    
    private void OnEnable()
    {
        _blackboardCurrentUnit.OnVariableChanged += CheckValue;
    }
   
    private void OnDisable()
    {
        _blackboardCurrentUnit.OnVariableChanged -= CheckValue;
    }

    private void CheckValue(string key, object type)
    {
        if (!_blackboardCurrentUnit.HasVariable(BlackboardKeys.FRIEND_NEED_NOTICE))
            return;

        if (_blackboardCurrentUnit.HasVariable(BlackboardKeys.TARGET))
        {
            _distanceFriendChecker.enabled = false;
            return;
        }
        
        _distanceFriendChecker.enabled = true;
    }
}
