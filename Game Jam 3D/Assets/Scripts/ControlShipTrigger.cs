using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShipTrigger : MonoBehaviour
{  
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {		

	}

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {

        }
    }
}
