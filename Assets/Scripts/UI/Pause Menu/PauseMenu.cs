using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance = null;

    public Text textGameOver;
    public Text textWin;
    public Text textPause;

    public Button buttonExit;
    public Button buttonRestart;
    public Button buttonResume;
    public Button buttonNextLevel;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonResume.onClick.AddListener(() => Resume());
        buttonNextLevel.onClick.AddListener(() => StartCoroutine(NextLevel()));
        buttonRestart.onClick.AddListener(() => StartCoroutine(Restart()));
        buttonExit.onClick.AddListener(() => StartCoroutine(Exit()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Resume() {
        buttonResume.interactable = false;

        GameManager.instance.Resume();
        gameObject.SetActive(false);
    }

    IEnumerator NextLevel() {
        buttonNextLevel.interactable = false;

        AnimatorTransitionController.instance.PlayStart();

        yield return new WaitForSecondsRealtime(0.25f);

        GameManager.instance.LevelIncrease();
        GameManager.instance.ClearScene();
        GameManager.instance.RandomKnifeCounter();
        GameManager.instance.CreateScene();
        GameManager.instance.Resume();
        gameObject.SetActive(false);

        AnimatorTransitionController.instance.PlayEnd();
    }

    IEnumerator Restart() {
        buttonRestart.interactable = false;

        AnimatorTransitionController.instance.PlayStart();

        yield return new WaitForSecondsRealtime(0.25f); // animation duration

        GameManager.instance.ClearScene();
        GameManager.instance.CreateScene();
        GameManager.instance.Resume();

        gameObject.SetActive(false);

        AnimatorTransitionController.instance.PlayEnd();
    }

    IEnumerator Exit() {

        AnimatorTransitionController.instance.PlayStart();

        yield return new WaitForSecondsRealtime(0.25f); // animation duration

        SceneLoader.instance.LoadPreviousScene();
    }

    /// <summary>
    /// UI show hide panels
    /// </summary>

    public void ShowPauseMenu() {
        HideAll();

        textPause.gameObject.SetActive(true);
        buttonResume.gameObject.SetActive(true);
    }

    public void ShowWinMenu() {
        HideAll();

        textWin.gameObject.SetActive(true);
        buttonNextLevel.gameObject.SetActive(true);
    }

    public void ShowGameOverMenu() {
        HideAll();

        textGameOver.gameObject.SetActive(true);
        buttonRestart.gameObject.SetActive(true);
    }

    void HideAll() {
        textWin.gameObject.SetActive(false);
        textPause.gameObject.SetActive(false);
        textGameOver.gameObject.SetActive(false);

        buttonResume.gameObject.SetActive(false);
        buttonRestart.gameObject.SetActive(false);
        buttonNextLevel.gameObject.SetActive(false);

        buttonResume.interactable = true;
        buttonRestart.interactable = true;
        buttonNextLevel.interactable = true;
    }
}
