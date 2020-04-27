using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
        [Range(0, 1000)]
        [SerializeField]
        private int _cost;
        public int Cost
    {
        get { return _cost; }
    }
        [SerializeField]
        [Range(0, 10)]
        protected float _shotDelay;
        [SerializeField]
        [Range(0, 30)]
        protected int _damage;
       
        public abstract String GetName();
        


    }

