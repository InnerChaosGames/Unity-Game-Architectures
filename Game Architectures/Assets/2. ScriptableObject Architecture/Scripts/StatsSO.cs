using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Stats/Create Stats", fileName = "New Stats")]
public class StatsSO : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; }
    
    [field: SerializeField]
    public int Health { get; private set; }
    
    [field: SerializeField] 
    public int CurrentHealth { get; private set; }
    
    [field: SerializeField] 
    public int Damage { get; private set; }

    public event UnityAction<int> HealthChangedEvent;
    public event UnityAction DeathEvent;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        CurrentHealth = Health;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthChangedEvent?.Invoke(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            DeathEvent?.Invoke();
        }
    }
}
