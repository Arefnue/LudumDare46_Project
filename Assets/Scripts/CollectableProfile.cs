using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectables",fileName = "Collectable")]
public class CollectableProfile : ScriptableObject
{
    public float value;
    public bool isEnergy;
}
