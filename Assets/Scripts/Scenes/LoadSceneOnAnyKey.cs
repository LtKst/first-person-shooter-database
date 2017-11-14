using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnAnyKey : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
