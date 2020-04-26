using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class Tower : MonoBehaviour
    {
        [SerializeField]
        public int Cost { get; }
        [SerializeField]
        [Range(0, 10)]
        protected float _shotDelay;
        [SerializeField]
        [Range(0, 30)]
        protected int _damage;
       
        public abstract String GetName();



    }

