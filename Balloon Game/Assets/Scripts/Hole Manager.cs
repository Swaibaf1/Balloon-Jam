using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{

    // 0, 1, 2, 3, 4
    //br tr tl bl mid

    [SerializeField] GameObject[] m_holes;
    [SerializeField] int m_activeHoles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetAllHolesActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    

    void SetAllHolesActive(bool _active)
    {
        for (int i = 0; i < m_holes.Length; i++)
        {
            m_holes[i].SetActive(_active);
        }
    }

    public void SetHoleActive(int _holesToSet, bool _active)
    {
        for(int i = 0; i < _holesToSet; i++)
        {
            for(int j = 0;  j < m_holes.Length; j++)
            {
                if (m_holes[j].activeSelf != _active)
                {
                     m_holes[j].SetActive(_active);
                    break;
                }
                else
                {
                    
                }
            }
        }
    }

    public int CalculateActiveHoles()
    {
        int _activeHoles = 0;

        for (int i = 0; i < m_holes.Length; i++)
        {
            if (m_holes[i].activeSelf)
            {
                _activeHoles++;
            }
            else
            {
                break;
            }
        }


        return _activeHoles;
    }
}
