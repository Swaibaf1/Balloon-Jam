using UnityEngine;

public class LerpToPosition : MonoBehaviour
{
    Vector2 m_startPosition;
    Vector2 m_endPosition;
    

    [SerializeField] bool m_useLocalPosition;
    [SerializeField] bool m_useAwakePosition;
   

    bool m_lerping = false;
    float m_counter;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(m_useAwakePosition)
        {
            m_startPosition = this.transform.position;
        }
        
    } 

    // Update is called once per frame
    void Update()
    {
        if(m_lerping)
        {
            m_counter += Time.deltaTime;
            
        }
        else
        {

        }


    }


}
