using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class Tower : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 1000)]
        protected int _cost;
        [SerializeField]
        [Range(0, 10)]
        protected float _shotDelay;
        [SerializeField]
        [Range(0, 30)]
        protected int _damage;
        [SerializeField]
        protected BulletBehavoiur _bullet;
        public int GetCost()
        {
            return _cost;
        }
        public abstract String GetName();



    }

