using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPeriodically : MonoBehaviour
{
	public float delay = 3;

	IEnumerator AttackFunc()
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);

			SendMessage("OnAttack", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnActivate()
	{
		StartCoroutine(AttackFunc());
	}
	void OnDeactivate()
	{
		StopAllCoroutines();
	}
}
