using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void OnSceneChanged(int _scene)
    {
        SceneManager.LoadScene(_scene);

    }
}
