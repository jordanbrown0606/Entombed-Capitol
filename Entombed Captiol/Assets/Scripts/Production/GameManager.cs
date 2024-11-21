using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this && Instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }
}
