using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] Button buttonNextLevel;
    [SerializeField] Button buttonExit;

    // Start is called before the first frame update
    void Start()
    {

        buttonNextLevel.onClick.AddListener(() => NextLevel());
        buttonExit.onClick.AddListener(() => Exit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextLevel() {
        GameManager.instance.LevelIncrease();
        GameManager.instance.ClearScene();
        GameManager.instance.RandomBladeCounter();
        GameManager.instance.CreateScene();
        GameManager.instance.Resume();
        gameObject.SetActive(false);
    }

    // TODO: Create a main menu scene
    void Exit() {
        print("exit");

        GameManager.instance.Resume();
    }
}
