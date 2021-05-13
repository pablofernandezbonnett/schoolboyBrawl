using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{

     [SerializeField] private GameObject enemy;

    public void NewEnemy()
    {
        Instantiate(this.enemy, this.transform.position, this.transform.rotation);

    }
}