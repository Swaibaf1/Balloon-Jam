using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] float m_meters;
    [SerializeField] BalloonMovement m_balloonMovement;
    [SerializeField] GameObject m_gameOverImage;
    [SerializeField] TextMeshProUGUI m_gameplayMeters;
    [SerializeField] TextMeshProUGUI m_gameOverMeters;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gameOverImage.SetActive(false);
        m_gameplayMeters.text = "0m";

    }


    public void RestartGame()
    {
        m_gameOverImage.SetActive(false);
        m_gameplayMeters.text = "0m";

        LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver(Component _sender, object _data)
    {
        m_gameOverImage.SetActive(true);
        m_gameOverMeters.text = m_gameplayMeters.text;
    }

    public void LoadScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }

}
