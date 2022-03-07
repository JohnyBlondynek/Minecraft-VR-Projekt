using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Staty : MonoBehaviour
{
    public int punkty;
    public TMP_Text Textpunkty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Textpunkty.text ="Punkty "+ punkty.ToString();
    }
}
