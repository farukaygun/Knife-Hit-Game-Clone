using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {
    [SerializeField] GameObject panelPause;
    [SerializeField] Text textCounter;
    [SerializeField] Text textLevel;
    [SerializeField] Button buttonPause;

    // Start is called before the first frame update
    void Start() {
        buttonPause.onClick.AddListener(() => Pause());
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        if (Time.timeScale == 0) return; // for pause game
        //RotateTextCounter();
    }

    void RotateTextCounter() {
        textCounter.transform.Rotate(0, 0, Circle.instance.rotationSpeed); // rotate with circle
    }

    public void Pause() {
        GameManager.instance.Pause();
        GameManager.instance.step = Step.wait;

        panelPause.SetActive(true);
        PauseMenu.instance.ShowPauseMenu();
    }
}