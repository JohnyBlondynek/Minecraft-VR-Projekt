using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZombie : MonoBehaviour
{
    public GameObject[] gameObjects;
    public float time;
    public int ograniczenia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        if (time > 3&&ograniczenia<10)
        {
            var Nowy = Instantiate(gameObjects[1]) as GameObject;
            Nowy.transform.position = gameObjects[0].transform.position;
            time = 0;
            ograniczenia++;
        } 
    }
}
