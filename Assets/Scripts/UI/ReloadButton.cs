using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : MonoBehaviour
{
    public void Reload(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
