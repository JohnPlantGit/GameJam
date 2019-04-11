using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class RepairShip : MonoBehaviour
{
    public ShipHealth m_shipHealth;
    public int m_playerNumber;
    public int m_healAmount;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        XboxButton activate = XboxButton.LeftBumper;
        XboxController controller = XboxController.First;
        switch (m_playerNumber)
        {
            case 1:
                activate = XboxButton.LeftBumper;
                controller = XboxController.First;
                break;
            case 2:
                activate = XboxButton.RightBumper;
                controller = XboxController.First;
                break;
            case 3:
                activate = XboxButton.LeftBumper;
                controller = XboxController.Second;
                break;
            case 4:
                activate = XboxButton.RightBumper;
                controller = XboxController.Second;
                break;
        }

        if (XCI.GetButtonDown(activate, controller))
        {
            m_shipHealth.Health += m_healAmount;
        }
    }
}
