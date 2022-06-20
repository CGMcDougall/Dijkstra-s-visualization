using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph : MonoBehaviour
{


    public GameObject Node;
    private int[,] graph;
    private int length;
    private GameObject[] arr;

    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {

        arr = GameObject.FindGameObjectsWithTag("GridObj");

        //print("Len " + arr.Length);
        
        graph = new int[arr.Length,arr.Length];
        length = arr.Length;
       


        //  int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
        //                               { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
        //                               { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
        //                               { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
        //                               { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
        //                               { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
        //                               { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
        //                               { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
        //                               { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };


        foreach (GameObject g in arr){
            Node n = g.GetComponent<Node>();
            int index = n.getNum();
            //init text 
            print(index);
            makeNum(index,n.transform.position);

        }


    }

    // Update is called once per frame
    void Update()
    {
         foreach (GameObject g in arr){
            Node n = g.GetComponent<Node>();
            int index = n.getNum();
            //print("In Graph " + index);

           
            


            foreach(Node e in n.linked){
                graph[index,e.getNum()] = (int)n.getDist(e);
            }

        }


        for(int y = 0; y < length; y++){
            string s = "";

            for(int x = 0; x < length; x++){
                s += graph[y,x].ToString() + " ";
            }
            print(s);
        }
    }


    void makeNum(int val,Vector3 pos){

        GameObject canvas = GameObject.FindGameObjectWithTag("canvas");
       
        GameObject t = GameObject.Instantiate(text,pos,text.transform.rotation) as GameObject;

        t.transform.SetParent(canvas.transform,true);
        t.transform.localScale = new Vector3(0.5f,0.5f,1);
        

        t.GetComponent<Text>().text = val.ToString();

    }

    
}
