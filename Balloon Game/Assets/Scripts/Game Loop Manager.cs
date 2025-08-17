using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] float m_meters;
    [SerializeField] BalloonMovement m_balloonMovement;
    [SerializeField] Image m_gameOverImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver(Component _sender, object _data)
    {
        LerpToPosition _script = m_gameOverImage.GetComponent<LerpToPosition>();
        
        if(_script != null )
        {
            
        }
    }

    public void LoadScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }

}
