﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessscript : MonoBehaviour

{
    public GameObject controller;
    public GameObject movement;

    private int xBoard = -1;
    private int yBoard = -1;


    private string player;

    public Sprite black_king, black_rook, black_pawn, black_queen,black_bishop,black_knight;
    public Sprite white_king, white_rook, white_pawn, white_queen,white_bishop,white_knight;


    public void Starting()
    {

        controller = GameObject.FindGameObjectWithTag("GameController");

        SettingCoordinates();

        switch (this.name)
        {
            case "black_queen": this.GetComponent<SpriteRenderer>().sprite = black_queen; break;
            case "black_knight": this.GetComponent<SpriteRenderer>().sprite = black_knight; break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; break;
            case "black_pawn": this.GetComponent<SpriteRenderer>().sprite = black_pawn; break;
            case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = black_bishop; break;
            case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king; break;


            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; break;
            case "white_knight": this.GetComponent<SpriteRenderer>().sprite = white_knight; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; break;
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn; break;
            case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = white_bishop; break;
            case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king; break;




        }

       
    }

    public void SettingCoordinates()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }




}
