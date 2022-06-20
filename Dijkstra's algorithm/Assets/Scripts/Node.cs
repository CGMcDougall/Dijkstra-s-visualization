using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Node : MonoBehaviour
{
    // Start is called before the first frame update

  

    public List<Node> linked = new List<Node>();
    public GameObject prefab;

    public GameObject text;

    void Start()
    {
        
        foreach (Node n in linked){
            
            makeLink(n);
            if(n.linked.Contains(this) == false)n.linked.Add(this);
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public int getNum(){
        String hold = this.name;
        
        //print(hold.IndexOf('(') + " - " + hold.IndexOf(')'));   
        int ind = hold.IndexOf('(');
        int len = hold.IndexOf(')') - hold.IndexOf('(');
        hold = hold.Substring(ind+1,len-1);

         //print("num : " + hold);

        return int.Parse(hold);

    }

    public float getDist(Node n){

        double x = n.transform.position.x - this.transform.position.x;
        double y = n.transform.position.y - this.transform.position.y;

        
        float c = (float)Math.Sqrt((x*x) + (y*y));

        return c;

    }

    public Vector3 getLinkPos(float Ox, float Oy){

        float x = transform.position.x;
        float y = transform.position.y;

        return new Vector3(x-Ox,y-Oy,1);
    }


    public void makeLink(Node n){

        float c = getDist(n);

        float thisX = this.transform.position.x;
        float thisY = this.transform.position.y;

        float nX = n.transform.position.x;
        float nY = n.transform.position.y;

        float x = 0;
        
        float y = 0;

        if(thisX < nX){
            x = thisX + Math.Abs(thisX-nX)/2;
            
        }
        else {
            x = nX + Math.Abs(nX-thisX)/2;
        }

        if(thisY < nY)y = thisY + Math.Abs(thisY-nY)/2;
        else y = nY + Math.Abs(nY-thisY)/2;

        double distX = nX-thisX;
        double distY = nY-thisY;

        double ang = Math.Atan2(distY,distX) * (180/Math.PI);

        print(distX + " and " + distY + " equal ang : "+ ang);
        
        //if(Math.Abs(ang) > 360)ang = ang/360;
        
        //print(ang);


      
        
        GameObject link = GameObject.Instantiate(prefab,new Vector3(x, y, 0), prefab.transform.rotation) as GameObject;
        link.transform.localScale = new Vector3(c,0.1f,0);
        link.transform.rotation = Quaternion.Euler(0f,0f,(float)ang);

        //make text for path val 
        //makeLink(0,new Vector3(0,0,0));
        Vector3 pos = new Vector3(x,y,0);
        int val = (int)Math.Round(c);
        makePath(val,pos);

}

void makePath(int val,Vector3 pos){
        
        GameObject canvas = GameObject.FindGameObjectWithTag("canvas");
        GameObject t = GameObject.Instantiate(text,pos,text.transform.rotation) as GameObject;

        t.transform.SetParent(canvas.transform,true);
        t.transform.localScale = new Vector3(0.5f,0.5f,1);
    
        t.GetComponent<Text>().color = Color.red;
        t.GetComponent<Text>().text = val.ToString();

    }



}