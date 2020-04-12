﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMonster : Monster
{
    private void Start()
    {
        Debug.Log(_health);
    }
    public override void ChangeHealth(int damage)
    {
        _health -=damage;
        if (_health <= 0)
            Destroy(gameObject);
    }
}
