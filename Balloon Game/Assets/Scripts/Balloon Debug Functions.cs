using UnityEngine;
using UnityEngine.InputSystem;

public class BalloonDebugFunctions : MonoBehaviour
{
    HoleManager m_holeManager;
    BalloonMovement m_balloonMovement;

    private void Start()
    {
        m_holeManager = this.GetComponent<HoleManager>();   
        m_balloonMovement = this.GetComponent<BalloonMovement>();
    }

    public void OnDebugHolePressed(InputAction.CallbackContext _context)
   {
        if(_context.started)
        {
            switch(_context.ReadValue<float>())
            {
                case -1:
                    m_balloonMovement.HitSomething();

                    break;
                case 0:
                    break;
                case 1:
                    m_holeManager.SetHoleActive(1, false);
                    break;
            }


        }
    
    
    }

    public void OnRestartLevel(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            m_balloonMovement.StartGame();
        }
    }
}
