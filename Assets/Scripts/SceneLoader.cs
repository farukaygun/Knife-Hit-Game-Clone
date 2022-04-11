using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader instance = null;

	public Animator transition;

	void Awake()
	{
		instance = this;
	}

	public void LoadNextScene() => StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

	public void LoadPreviousScene() => StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex - 1));

	IEnumerator LoadScene(int sceneIndex)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSecondsRealtime(0.25f);

		SceneManager.LoadScene(sceneIndex);
	}
}
