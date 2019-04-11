using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class TurretController : MonoBehaviour
{
    public int m_playerNumber;
    public GameObject m_bulletPrefab;
    public float m_bulletSpeed;
    public Team m_team;
    public Transform m_parent;
    public float m_rotationSpeed;
    public float m_fireRate;

    private Vector3 m_offset;
    private float m_rotation;
    private float m_targetRotation;
    private float m_fireTimer;
	// Use this for initialization
	void Start ()
    {
        m_offset = transform.position - m_parent.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = m_parent.position + m_offset;

        m_fireTimer -= Time.deltaTime;

        if (m_playerNumber != -1)
        {
            XboxController controller = XboxController.All;
            XboxAxis stickX = XboxAxis.LeftStickX;
            XboxAxis stickY = XboxAxis.LeftStickY;
            XboxButton activate = XboxButton.LeftBumper;

            switch (m_playerNumber)
            {
                case 1:
                    controller = XboxController.First;
                    stickX = XboxAxis.LeftStickX;
                    stickY = XboxAxis.LeftStickY;
                    activate = XboxButton.LeftBumper;
                    break;
                case 2:
                    controller = XboxController.First;
                    stickX = XboxAxis.RightStickX;
                    stickY = XboxAxis.RightStickY;
                    activate = XboxButton.RightBumper;
                    break;
                case 3:
                    controller = XboxController.Second;
                    stickX = XboxAxis.LeftStickX;
                    stickY = XboxAxis.LeftStickY;
                    activate = XboxButton.LeftBumper;
                    break;
                case 4:
                    controller = XboxController.Second;
                    stickX = XboxAxis.RightStickX;
                    stickY = XboxAxis.RightStickY;
                    activate = XboxButton.RightBumper;
                    break;
            }

            //Quaternion rotation = Quaternion.Euler(0, XCI.GetAxisRaw(stickX, controller) * m_rotationSpeed, 0);
            //transform.rotation *= rotation;

            Vector3 facing = new Vector3(XCI.GetAxisRaw(stickX, controller), 0, XCI.GetAxisRaw(stickY, controller));
            if (facing.sqrMagnitude != 0)
                transform.forward = facing;

            if (XCI.GetButton(activate, controller))
            {
                if (m_fireTimer <= 0)
                {
                    GameObject bullet = Instantiate(m_bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * m_bulletSpeed;
                    bullet.GetComponent<Bullet>().m_team = m_team;
                    m_fireTimer = m_fireRate;
                }
            }
        }
    }
}
