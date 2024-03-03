using Sirenix.OdinInspector;
using UnityEngine;

public sealed class Character : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    [ShowInInspector, ReadOnly]
    private bool moveRequired;

    [ShowInInspector, ReadOnly]
    private Vector3 moveDirection;
    
    [Button]
    public void Move(Vector3 direction)
    {
        moveRequired = true;
        moveDirection = direction;
    }
    
    public void Turn(Transform objectDetected)
    {
        transform.LookAt(objectDetected.position);
    }
    private void FixedUpdate()
    {
        if (!moveRequired) 
            return;
        
        transform.position += moveSpeed * Time.fixedDeltaTime * moveDirection;
        transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        moveRequired = false;
    }
}