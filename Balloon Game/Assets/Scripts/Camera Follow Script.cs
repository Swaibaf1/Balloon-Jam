using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    Camera m_cam;
    [SerializeField] GameObject m_target;
    Vector2 m_offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        m_offset = this.transform.position - m_target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            m_target.transform.position.x + m_offset.x,
            this.transform.position.y,
            this.transform.position.z);
    }

    void OnGameStart()
    {
        
    }
}
