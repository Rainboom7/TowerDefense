using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField]
    protected int _cost;
    [SerializeField]
    protected float _shotDelay;
    [SerializeField]
    protected int _damage;
    [SerializeField]
    protected BulletBehavoiur _bullet;
    protected List<Monster> _monsterInRange= new List<Monster>();
   


}
