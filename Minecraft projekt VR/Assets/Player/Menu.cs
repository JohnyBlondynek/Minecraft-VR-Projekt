using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject lodidingscene;
    public Slider slider;
    public TMP_Text Progresstext;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int loadScene;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") StartCoroutine(loadAsynchosly(loadScene));
    }
    IEnumerator loadAsynchosly(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            Progresstext.text = progress * 100f + "%";

            yield return null;
        }
    }
}
