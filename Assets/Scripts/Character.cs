using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public sealed class Character : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    [ShowInInspector, ReadOnly]
    private bool moveRequired;

    [ShowInInspector, ReadOnly]
    private Vector3 moveDirection;

    [SerializeField] 
    private NavMeshAgent _navMeshAgent;
    
    [Button]
    public void Move(Vector3 direction)
    {
        moveRequired = true;
        moveDirection = direction;
    }
    
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