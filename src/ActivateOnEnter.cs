using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateOnEnter : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != PlayerController.instance.gameObject)
			return;

		SendMessage("OnActivate");
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject != PlayerController.instance.gameObject)
			return;

		SendMessage("OnDeactivate");
	}
}
