using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
	[SerializeField] GameObject panelPause;
	[SerializeField] Text textCounter;
	[SerializeField] Text textLevel;
	[SerializeField] Button buttonPause;

	void Start()
	{
		buttonPause.onClick.AddListener(() => Pause());
	}

	void FixedUpdate()
	{
		if (Time.timeScale == 0)
			return; // for pause game
	}

	void RotateTextCounter()
	{
		textCounter.transform.Rotate(0, 0, Circle.instance.rotationSpeed); // rotate with circle
	}

	public void Pause()
	{
		GameManager.instance.Pause();
		GameManager.instance.step = Step.wait;

		panelPause.SetActive(true);
		PauseMenu.instance.ShowPauseMenu();
	}
}