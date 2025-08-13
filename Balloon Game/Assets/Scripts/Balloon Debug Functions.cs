using UnityEngine;
using UnityEngine.InputSystem;

public class BalloonDebugFunctions : MonoBehaviour
{
    HoleManager m_holeManager;

    private void Start()
    {
        m_holeManager = this.GetComponent<HoleManager>();   
    }

    public void OnDebugHolePressed(InputAction.CallbackContext _context)
   {
        if(_context.started)
        {
            switch(_context.ReadValue<float>())
            {
                case -1:
                    m_holeManager.SetHoleActive(1, true);
                    break;
                case 0:
                    break;
                case 1:
                    m_holeManager.SetHoleActive(1, false);
                    break;
            }


        }
    
    
    }


}
