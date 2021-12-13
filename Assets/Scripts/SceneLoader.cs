using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance = null;

    public Animator transition;
    public float transitionTime = 0.5f;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextScene() => StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

    public void LoadPreviousScene() => StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex - 1));

    IEnumerator LoadScene(int sceneIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
