using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class BalloonMovement : MonoBehaviour
{

    //balloon movement stuff
    [SerializeField] float m_horizontalBalloonVelocity;
    [SerializeField] float m_verticalBalloonVelocity;
    [SerializeField] float m_balloonDownwardVelocity;
    [SerializeField] float m_balloonDeathSpeed;

    //misc
    [SerializeField] LayerMask m_hittableLayer;
    float m_balloonVerticalInput;
    Rigidbody2D m_rb;



    // Serialized for now so we can test air control / movement stuff in editor 
    [SerializeField] int m_activeHoles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = this.GetComponent<Rigidbody2D>();
        m_activeHoles = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        CheckForEnemies();


        

        // TO DO:
        // multiply velocity y by 1 / number of holes IF the input is > 0f 
        // more holes = fall down quickler


        Vector2 _finalVelocity = Vector2.zero;

        int _holesMultiplier = Mathf.Clamp(m_activeHoles, 1, 5);

        if(m_activeHoles != 5)
        {
            switch(m_balloonVerticalInput)
            {
                case > 0f:
                    _finalVelocity.y = m_balloonVerticalInput * m_verticalBalloonVelocity;
                    _finalVelocity.y = _finalVelocity.y * (1 / _holesMultiplier);
                    break;
                case 0f:
                    _finalVelocity.y = -m_balloonDownwardVelocity * _holesMultiplier;
                    break;
                case < 0f:
                    _finalVelocity.y =
                     m_balloonVerticalInput
                    * m_balloonDownwardVelocity
                    * m_verticalBalloonVelocity
                    * _holesMultiplier;
                    break;
            }
            
            _finalVelocity.x = m_horizontalBalloonVelocity;
        }
        else
        {
            _finalVelocity.y = -m_balloonDeathSpeed;
            _finalVelocity.x = 0;
        }

      
            m_rb.linearVelocity = _finalVelocity;
    }

    void CheckForEnemies()
    {
        if(Physics2D.OverlapCircle(this.transform.position, 3f, m_hittableLayer))
        {
            if (m_activeHoles < 5)
            {
                m_activeHoles++;
            }
            else
            {
                print("boom crash bang");
            }

        }
    }
    public void OnBalloonUpDown(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            m_balloonVerticalInput = _context.ReadValue<float>();
        }

        if(_context.canceled)
        {
            m_balloonVerticalInput = 0f;
        }
    }

    
}
