using UnityEngine;

public class DeathObserver : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _player;
    
    [SerializeField]
    private GameObject _deathPunnel;
    private void Awake()
    {
        _player.OnDeath += ActivatePunnel;
    }

    private void OnDestroy()
    {
        _player.OnDeath -= ActivatePunnel;
    }

    private void ActivatePunnel()
    {
        _deathPunnel.SetActive(true);
    }
}
