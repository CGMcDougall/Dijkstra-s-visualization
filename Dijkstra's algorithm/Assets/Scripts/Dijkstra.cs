using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dijkstra : MonoBehaviour
{   

    public int start;
    public int end;

    // List<Node> visited = new List<Node>();
    // int vSize = 0;

    // List<Node> unvisited = new List<Node>();
    // int uSize = 0;

    List<Node> Nodes = new List<Node>();
    int Size = 0;

    ArrayList unvisited = new ArrayList();

    
    Stack path = new Stack();
    int pSize = 0;

    private class Node {

        public int vertex;
        public int path;
        public int prev;

        public Node(int v, int p, int pr) {
            vertex = v;
            path = p;
            prev = pr;
        }

        public void printout(){
            print("Vertex: " + vertex + " shortest path is " + path + " from Node " + prev);
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        //list 1 visited
        //list 2 unvisited
       


        //example graph
        int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

        double len = Math.Sqrt(Convert.ToDouble(graph.Length));

        for(int i = 0; i < len; i++){
            unvisited.Add(i);
            Node n = new Node(i,1000,1000);
            Nodes.Add(n);
            Size++;
        }

        Nodes[start].path = 0;
        Nodes[start].prev = -1;
    

        int next = start;
        while(unvisited.Count != 0){

            for(int i = 0; i < len; i++){

                if(graph[next,i] != 0){
                    
                    if(Nodes[i].path > (Nodes[next].path + graph[next,i])){
                        Nodes[i].path = (Nodes[next].path + graph[next,i]);
                        Nodes[i].prev = next;
                    }


                }


            }

            unvisited.Remove(next);
            if(unvisited.Count == 0)break;
            next = getSmallestVert();

        }


        foreach (Node n in Nodes){
            n.printout();
        }

        next = end;
        while(next >= 0){
            path.Push(Nodes[next].vertex);
            pSize++;
            next = Nodes[next].prev;
        }

    
        printPath();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //return the smallest node that is still in unvisisted
    private int getSmallestVert(){
        
        int small = 10000;

        foreach(Node n in Nodes){
            if(n.vertex < small && unvisited.Contains(n.vertex))small = n.vertex;
        }

        return small;

    }

    //prints path, deleting it in the process
    public void printPath(){

        while(pSize > 0){
            pSize--;
            print(path.Pop());
            
        }

    }

}
