using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Step {
    wait,
    movingBladeToThrowPoint,
    movingBladeToDestinationPoint,
    newBladeSpawn,
}

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    [SerializeField] GameObject circle;
    [SerializeField] GameObject panelPauseMenu;

    [SerializeField] Text textLevel;
    [SerializeField] Text textCounter;

    GameObject blade;

    public Step step;
    int counter;
    int level = 1;
    float bladeMoveSpeed = 20f;

    Vector3 bladeThrowPoint = new Vector3(0, -3, 0);
    Vector3 bladeSpawnPoint = new Vector3(0, -7, 0);
    Vector3 bladeDestinationPoint = new Vector3(0, 1, 0);

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        AnimatorTransitionController.instance.PlayEnd();
        Instantiate(circle, new Vector3(0, 1f, 0), Quaternion.identity); // get circle prefab
        textLevel.text = level.ToString();
        CreateScene();
    }

    // Update is called once per frame
    void Update() {
        if (Time.timeScale == 0) return;
        if (counter == 0) Win();

        // Using EventSystem.current.isPointerOverGameObject() you can check if Ui is clicked. If it is, dont do anything
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            step = Step.movingBladeToDestinationPoint;
        }
    }

    void FixedUpdate() {
        if (Time.timeScale == 0) return;
        switch (step) {
            case Step.movingBladeToThrowPoint:
                SetBladeToThrow(blade);
                break;
            case Step.movingBladeToDestinationPoint:
                blade.transform.position = Vector3.MoveTowards(blade.transform.position, bladeDestinationPoint, bladeMoveSpeed * Time.deltaTime);
                break;
            case Step.newBladeSpawn:
                GetBladeFromPool();
                step = Step.movingBladeToThrowPoint;
                break;
        }
    }

    public void StabbedBlade() {
        step = Step.newBladeSpawn;
        CounterDecrease();
    }

    GameObject GetBladeFromPool() {
        blade = BladePool.instance.GetPooledBlade();

        if (blade != null) {
            blade.transform.position = bladeSpawnPoint;
            blade.transform.rotation = Quaternion.identity;
            blade.SetActive(true);
        }

        return blade;
    }

    void SetBladeToThrow(GameObject blade) {
        if (blade.transform.position != bladeThrowPoint) {
            blade.transform.position = Vector3.MoveTowards(blade.transform.position, bladeThrowPoint, bladeMoveSpeed * Time.deltaTime);
        } else step = Step.wait;
    }

    public void GameOver() {
        Pause();
        step = Step.wait;

        panelPauseMenu.SetActive(true);
        PauseMenu.instance.ShowGameOverMenu();
    }

    void Win() {
        Pause();
        step = Step.wait;

        panelPauseMenu.SetActive(true);
        PauseMenu.instance.ShowWinMenu();
    }

    public void CreateScene() {
        RandomBladeCounter();
        GetBladeFromPool();
        step = Step.movingBladeToThrowPoint;
    }

    public void Pause() {
        Time.timeScale = 0f; 
    }

    public void Resume() {
        Time.timeScale = 1f;
    }

    void CounterDecrease() {
        counter--;
        textCounter.text = counter.ToString();
    }

    public void LevelIncrease() {
        level++;
        textLevel.text = level.ToString();
    }

    public void ClearScene() {
        GameObject circle = GameObject.FindGameObjectWithTag("Circle");
        circle.transform.rotation = new Quaternion(0, 0, 0, 0);
        circle.transform.DetachChildren();

        GameObject[] blades = GameObject.FindGameObjectsWithTag("Blade");

        foreach (var item in blades) {
            item.SetActive(false);
        }
    }

    public void RandomBladeCounter() {
        counter = Random.Range(8, 12);
        textCounter.text = counter.ToString();
    }
}