using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Stats", fileName = "New Stats")]
public class StatsSO : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; }
    
    [field: SerializeField]
    public int Health { get; private set; }
    
    [field: SerializeField] 
    public int Damage { get; private set; }

}
