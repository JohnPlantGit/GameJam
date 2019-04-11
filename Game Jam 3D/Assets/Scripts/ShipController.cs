using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class ShipController : MonoBehaviour
{
    public int m_playerNumber = -1;
    public float m_speed = 50;
    public float m_rotationSpeed = 10;
    public float m_rotationDrag = 10;

    private Rigidbody m_rigidbody;
    private float m_rotationVelocity;
	// Use this for initialization
	void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_playerNumber != -1)
        {
            XboxController controller = XboxController.All;
            XboxAxis stick = XboxAxis.LeftStickX;
            XboxButton activate = XboxButton.LeftBumper;

            switch (m_playerNumber)
            {
                case 1:
                    controller = XboxController.First;
                    stick = XboxAxis.LeftStickX;
                    activate = XboxButton.LeftBumper;
                    break;
                case 2:
                    controller = XboxController.First;
                    stick = XboxAxis.RightStickX;
                    activate = XboxButton.RightBumper;
                    break;
                case 3:
                    controller = XboxController.Second;
                    stick = XboxAxis.LeftStickX;
                    activate = XboxButton.LeftBumper;
                    break;
                case 4:
                    controller = XboxController.Second;
                    stick = XboxAxis.RightStickX;
                    activate = XboxButton.RightBumper;
                    break;
            }

            m_rotationVelocity += XCI.GetAxisRaw(stick, controller) * m_rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0, m_rotationVelocity, 0);
            transform.rotation *= rotation;

            m_rotationVelocity -= m_rotationDrag * m_rotationVelocity * Time.deltaTime;

            if (XCI.GetButton(activate, controller))
            {
                m_rigidbody.AddForce(transform.forward * m_speed);
            }
        }
	}
}
