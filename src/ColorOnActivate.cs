using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnActivate : MonoBehaviour
{
	public string paramName = "_Color";
	public Color colorOnActive = Color.white;
	public Color colorOnInactive = Color.gray;

	private Material mat;

	void Start () {
		var r = GetComponentInChildren<Renderer>();
		mat = new Material(r.material);
		r.material = mat;

		mat.SetColor(paramName, colorOnInactive);
	}

	void OnActivate()
	{
		StopAllCoroutines();
		StartCoroutine(FadeFunc(colorOnActive));
	}
	void OnDeactivate()
	{
		StopAllCoroutines();
		StartCoroutine(FadeFunc(colorOnInactive));
	}

	IEnumerator FadeFunc(Color to)
	{
		var c = mat.GetColor(paramName);
		for (int i = 0; i < 30; i++)
		{
			c += (to - c) * 0.15f;
			mat.SetColor(paramName, c);

			yield return null;
		}
		mat.SetColor(paramName, to);
	}
}
