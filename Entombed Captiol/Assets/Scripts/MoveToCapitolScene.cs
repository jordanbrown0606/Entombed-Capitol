using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToCapitolScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.Instance.hasKey == true)
        {
            TransitionScene(_sceneName);
        }
    }

    private void TransitionScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
