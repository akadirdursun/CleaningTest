using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject couchPrefab;

    private void Start()
    {
        Instantiate(couchPrefab);
    }
}