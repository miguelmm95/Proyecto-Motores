using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionController : MonoBehaviour
{
    public bool m_UseRelativeRotation = true;
    public Transform camara;

    private Quaternion m_RelativeRotation;

    void Start()
    {
        m_RelativeRotation = transform.parent.localRotation;
    }

    void Update()
    {

        if (m_UseRelativeRotation)
        {
            transform.rotation = m_RelativeRotation;
        }
    }
}
