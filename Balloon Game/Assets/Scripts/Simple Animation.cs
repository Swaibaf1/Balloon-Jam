using UnityEngine;

public class SimpleAnimation : MonoBehaviour
{
    [SerializeField] Sprite m_sprite1;
    [SerializeField] Sprite m_sprite2;
    [SerializeField] float m_intervalTime;

    SpriteRenderer m_spriteRenderer;
    float m_intervalCounter;
    bool m_spriteChange;

    
    void Awake()
    {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_intervalCounter > 0f)
        {
            m_intervalCounter -= Time.deltaTime;
        }
        else
        {
            ChangeSprite(!m_spriteChange);
            m_intervalCounter = m_intervalTime;
            m_spriteChange = !m_spriteChange;
        }

    }

    void ChangeSprite(bool _sprite1)
    {
        if(_sprite1)
        {
            m_spriteRenderer.sprite = m_sprite1; 
        }
        else
        {
            m_spriteRenderer.sprite = m_sprite2;
        }

    }



}
