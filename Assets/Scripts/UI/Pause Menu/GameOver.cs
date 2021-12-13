using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button buttonExit;
    [SerializeField] Button buttonRestart;

    // Start is called before the first frame update
    void Start()
    {
        buttonRestart.onClick.AddListener(() => StartCoroutine(Restart()));
        buttonExit.onClick.AddListener(() => StartCoroutine(Exit()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Restart() {
        AnimatorTransitionController.instance.PlayStart();

        // WaitForSecondsRealtime does not effect by timescale = 0
        yield return new WaitForSecondsRealtime(0.5f); // animation duration

        GameManager.instance.ClearScene();
        GameManager.instance.CreateScene();
        GameManager.instance.Resume();

        gameObject.SetActive(false);

        AnimatorTransitionController.instance.PlayEnd();
    }

    IEnumerator Exit() {
        AnimatorTransitionController.instance.PlayStart();

        yield return new WaitForSecondsRealtime(0.5f); // animation duration

        SceneLoader.instance.LoadPreviousScene();
    }
}
