﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{


    public GameObject Chesspiece;
    // Start is called before the first frame update
    void Start()
    {
        //Instatiating the prefab
        Instantiate(Chesspiece, new Vector3(0,0,-1),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
