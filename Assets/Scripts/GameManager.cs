using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Step {
    wait,
    movingKnifeToThrowPoint,
    movingKnifeToDestinationPoint,
    newKnifeSpawn,
}

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    [SerializeField] GameObject circle;
    [SerializeField] GameObject panelPauseMenu;

    [SerializeField] Text textLevel;
    [SerializeField] Text textCounter;

    GameObject knife;

    public Step step;
    int counter;
    int level = 1;
    float knifeMoveSpeed = 90f;

    Vector3 knifeThrowPoint = new Vector3(0, -6, 0);
    Vector3 knifeSpawnPoint = new Vector3(0, -12, 0);

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        AnimatorTransitionController.instance.PlayEnd();
        Instantiate(circle, new Vector3(0, 2f, 0), Quaternion.identity); // get circle prefab
        textLevel.text = level.ToString();
        CreateScene();
    }

    // Update is called once per frame
    void Update() {
        if (Time.timeScale == 0) return;
        if (counter == 0) StartCoroutine(Win());

        // Using EventSystem.current.isPointerOverGameObject() you can check if Ui is clicked. If it is, dont do anything
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            step = Step.movingKnifeToDestinationPoint;
        }
    }

    void FixedUpdate() {
        if (Time.timeScale == 0) return;

        switch (step) {
            case Step.movingKnifeToThrowPoint:
                SetKnifeToThrow(knife);
                break;
            case Step.movingKnifeToDestinationPoint:
                ThrowKnife();
                step = Step.newKnifeSpawn;
                break;
            case Step.newKnifeSpawn:
                GetKnifeFromPool();
                step = Step.movingKnifeToThrowPoint;
                break;
        }
    }

    // Throwing knife to wood
    void ThrowKnife() {
        Rigidbody2D rb = knife.transform.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0, (knifeMoveSpeed * Time.deltaTime) * 20, 0), ForceMode2D.Impulse);
    }

    GameObject GetKnifeFromPool() {
        knife = KnifePool.instance.GetPooledKnife();

        if (knife != null) {
            knife.transform.position = knifeSpawnPoint;
            knife.transform.rotation = Quaternion.identity;
            knife.SetActive(true);
        }
        return knife;
    }

    void SetKnifeToThrow(GameObject knife) {
        if (knife.transform.position != knifeThrowPoint) {
            knife.transform.position = Vector3.MoveTowards(knife.transform.position, knifeThrowPoint, knifeMoveSpeed * Time.deltaTime);
        }
    }

    public IEnumerator GameOver() {
        Pause();
        step = Step.wait;

        yield return new WaitForSecondsRealtime(1f);

        panelPauseMenu.SetActive(true);
        PauseMenu.instance.ShowGameOverMenu();
    }

    IEnumerator Win() {
        Pause();
        step = Step.wait;
            
        yield return new WaitForSecondsRealtime(1f);

        panelPauseMenu.SetActive(true);
        PauseMenu.instance.ShowWinMenu();
    }

    public void CreateScene() {
        RandomKnifeCounter();
        GetKnifeFromPool();

        step = Step.movingKnifeToThrowPoint;
    }

    public void Pause() {
        Time.timeScale = 0f; 
    }

    public void Resume() {
        Time.timeScale = 1f;
    }

    public void CounterDecrease() {
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

        GameObject[] knives = GameObject.FindGameObjectsWithTag("Knife");

        foreach (var item in knives) {
            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.SetActive(false);
        }
    }

    public void RandomKnifeCounter() {
        counter = Random.Range(8, 12);
        textCounter.text = counter.ToString();
    }
}