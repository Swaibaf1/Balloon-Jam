using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem;

public class BalloonMovement : MonoBehaviour
{

    //balloon movement stuff
    [SerializeField] float m_horizontalBalloonSpeed;
    [SerializeField] float m_verticalBalloonSpeed;
    [SerializeField] float m_balloonDownwardVelocity;
    [SerializeField] float m_balloonDeathSpeed;

    //timing stuff
    [SerializeField] float m_hitShieldTime;
    [SerializeField] Color m_hitShieldColor;


    float m_hitShieldCounter;
    bool m_hitShieldOn = false;


    [SerializeField] float m_hitIntervalTime;
    float m_hitIntervalCounter;
    bool m_balloonTransparent;

    //misc
    [SerializeField] LayerMask m_hittableLayer;
    [SerializeField] LayerMask m_gameOverLayer;
    [SerializeField] GameEvent m_gameOverEvent;

    Vector2 m_startPosition;

    float m_balloonVerticalInput;
    Rigidbody2D m_rb;


    float m_activeHoles;
    SpriteRenderer m_spriteRenderer;

    HoleManager m_holeManager;
    HingeJoint2D m_hingeJoint;

    public bool m_canMove;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
        m_rb = this.GetComponent<Rigidbody2D>();
        m_holeManager = this.GetComponent<HoleManager>();
        m_hingeJoint = this.GetComponent <HingeJoint2D>();
        m_startPosition = this.transform.position;
        StartGame();
    }


    // Update is called once per frame
    void Update()
    {
        if (m_hitShieldOn)
        {
            if(m_hitShieldCounter > 0f && m_activeHoles != 5)
            {
               m_hitShieldCounter -= Time.deltaTime;

               if(m_hitIntervalCounter > 0f)
               {
                    
                    m_hitIntervalCounter -= Time.deltaTime;
               }
               else
               {
                    ChangeBalloonIntervalColor(!m_balloonTransparent);
                    m_balloonTransparent = !m_balloonTransparent;

                    m_hitIntervalCounter = m_hitIntervalTime;
               }

            }
            else
            {
                EndHitShieldTimer();
                ChangeBalloonIntervalColor(false);
                
            }
        }
    }


    void ChangeBalloonIntervalColor(bool _transparent)
    {
        if(_transparent)
        {
            m_spriteRenderer.color = m_hitShieldColor;
        }
        else
        {
            m_spriteRenderer.color = Color.white;
        }
    }

    public void StartHitShieldTimer()
    {
        m_hitShieldCounter = m_hitShieldTime;
        m_hitShieldOn = true;

    }

    void EndHitShieldTimer()
    {
        m_hitShieldOn = false;
        m_hitShieldCounter = -1f;
    }

    private void FixedUpdate()
    {

        if(m_canMove)
        {
            CheckForEnemies();

            m_activeHoles = m_holeManager.CalculateActiveHoles();

            Vector2 _finalVelocity = Vector2.zero;

            float _holesMultiplier = Mathf.Clamp(m_activeHoles, 1, 5);

            if (m_activeHoles != 5)
            {
                switch (m_balloonVerticalInput)
                {
                    case > 0f:
                        _finalVelocity.y = m_balloonVerticalInput * m_verticalBalloonSpeed;
                        _finalVelocity.y = _finalVelocity.y * (1 / _holesMultiplier);
                        break;
                    case 0f:
                        _finalVelocity.y = -m_balloonDownwardVelocity * _holesMultiplier;
                        break;
                    case < 0f:

                        _finalVelocity.y =
                         m_balloonVerticalInput
                        * m_balloonDownwardVelocity
                        * m_verticalBalloonSpeed
                        * _holesMultiplier;
                        break;
                }

                _finalVelocity.x = m_horizontalBalloonSpeed;
            }
            else
            {
                CheckForDeathTrigger();
                _finalVelocity.y = -m_balloonDeathSpeed;
                _finalVelocity.x = 0f;
                m_rb.freezeRotation = false;
            }

            m_rb.linearVelocity = _finalVelocity;
        }
        else
        {
         
            m_rb.linearVelocity = Vector2.zero;
        }
       
    }

    public void StartGame()
    {
        m_rb.SetRotation(0);
        m_rb.freezeRotation = true;
        m_rb.bodyType = RigidbodyType2D.Dynamic;
        m_holeManager.SetHoleActive(5,false);
        this.transform.position = m_startPosition;

        m_canMove = true;
    }

    void CheckForEnemies()
    {
        if(Physics2D.OverlapCircle(this.transform.position, 2f, m_hittableLayer))
        {
            if (m_activeHoles < 5 && !m_hitShieldOn)
            {
                HitSomething();
            }

        }
    }

    void CheckForDeathTrigger()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 0.5f, m_gameOverLayer)) 
        {
            m_gameOverEvent.Raise(this, 1);
            TogglePause();
        }
    }

    public void HitSomething()
    {
        StartHitShieldTimer();
        m_holeManager.SetHoleActive(1, true);
        
    }


    public void TogglePause()
    {
        if(m_canMove)
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            m_canMove = false;
        }
        else
        {
            m_rb.bodyType = RigidbodyType2D.Dynamic;
            m_canMove = true;
        }
    }
    public void StopGame()
    {
        
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
