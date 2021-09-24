using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject couchPrefab;

    private void Start()
    {
        Instantiate(couchPrefab);
    }

    private void RestartTheScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
