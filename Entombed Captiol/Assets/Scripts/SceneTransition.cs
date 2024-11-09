using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    private void OnTriggerEnter(Collider other)
    {
        TransitionScene(_sceneName);
    }

    private void TransitionScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
