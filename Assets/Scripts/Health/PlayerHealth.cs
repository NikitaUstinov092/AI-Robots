using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
   public event Action OnDeath;
   
   [SerializeField]
   private float health;

   void IDamagable.TakeDamage(float damage)
   {
      if (health > 0)
      {
         health -= damage;
      }

      if (health <= 0)
      {
         health = 0;
         OnDeath?.Invoke();
      }
   }
}


public interface IDamagable
{
   void TakeDamage(float damage);
}
