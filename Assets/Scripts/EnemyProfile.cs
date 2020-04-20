using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies",fileName = "Enemy")]
public class EnemyProfile : ScriptableObject
{
    public float damage;
    public float speed;
    public float attackRange;

}
