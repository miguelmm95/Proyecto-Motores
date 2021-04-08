using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionController : MonoBehaviour
{
    public bool m_UseRelativeRotation = true;
    public Transform camara;

    private Quaternion m_RelativeRotation;

    // Start is called before the first frame update
    void Start()
    {
        m_RelativeRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(camara);

        if (m_UseRelativeRotation)
        {
            transform.rotation = m_RelativeRotation;
        }
    }
}