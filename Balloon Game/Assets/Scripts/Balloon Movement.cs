using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class BalloonMovement : MonoBehaviour
{

    //balloon movement stuff
    [SerializeField] float m_horizontalBalloonVelocity;
    [SerializeField] float m_verticalBalloonVelocity;
    [SerializeField] float m_balloonDownwardVelocity;
    

    //misc
    [SerializeField] LayerMask m_hittableLayer;
    float m_balloonVerticalInput;
    Rigidbody2D m_rb;



    // Serialized for now so we can test air control / movement stuff in editor 
    [SerializeField] float m_currentHolesActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        CheckForEnemies();


        m_rb.linearVelocityX = m_horizontalBalloonVelocity;

        // TO DO:
        // multiply velocity y by 1 / number of holes IF the input is > 0f 
        // more holes = fall down quickler


        float _finalVelocity;

        if (m_balloonVerticalInput > 0f)
        {
            _finalVelocity = m_balloonVerticalInput * m_verticalBalloonVelocity;
        }
        else if (m_balloonVerticalInput == 0f)
        {
            _finalVelocity = -m_balloonDownwardVelocity;
        }
        else
        {
            _finalVelocity = m_balloonVerticalInput * m_balloonDownwardVelocity * m_verticalBalloonVelocity;
        }

        m_rb.linearVelocityY = _finalVelocity;
    }

    void CheckForEnemies()
    {
        if(Physics2D.OverlapCircle(this.transform.position, 3f, m_hittableLayer))
        {
            print("HIT SOMETHING");
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
