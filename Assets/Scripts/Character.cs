using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public sealed class Character : MonoBehaviour
{
    [SerializeField] 
    private NavMeshAgent _navMeshAgent;
    
    [Button]
    public void MoveNavmesh(Transform direction)
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(direction.position);
    }
    
    public void Turn(Transform objectDetected)
    {
        _navMeshAgent.isStopped = true;
        transform.LookAt(objectDetected.position);
    }
   
}