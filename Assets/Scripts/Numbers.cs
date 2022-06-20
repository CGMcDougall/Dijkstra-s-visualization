using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Numbers : MonoBehaviour
{
    //public GameObject canvas;
    public GameObject prefab;
    //int val = -1;
    //public Text textVal;


    void Start()
    {
        
        GameObject canvas = GameObject.FindGameObjectWithTag("canvas");
       
         GameObject t = GameObject.Instantiate(prefab,new Vector3(0,0,0),prefab.transform.rotation) as GameObject;

        t.transform.SetParent(canvas.transform,true);
        t.transform.localScale = new Vector3(1,1,1);
        

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
