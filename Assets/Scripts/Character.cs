using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public sealed class Character : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField] 
    private Animator animator;

    private static readonly int State = Animator.StringToHash("state");

    public void Move(Vector3 direction)
    {
        navMeshAgent.speed = moveSpeed;
        animator.SetInteger(State, 1);
        navMeshAgent.SetDestination(direction);
        Turn(direction);
    }

    public void Stop()
    {
        animator.SetInteger(State, 0);
        navMeshAgent.speed = 0;
    }
    
    [Button]
    public void Attack()
    {
        animator.SetInteger(State, 2);
    }
    
    public void Turn(Transform objectDetected)
    {
        Turn(objectDetected.position);
    }
    
    private void Turn(Vector3 direction)
    {
        transform.LookAt(direction);
    }
}