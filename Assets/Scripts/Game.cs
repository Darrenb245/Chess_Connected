﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject chessPiece;
    public firebaseScript fbScript;
    private GameObject[,] positions = new GameObject [8,8];
    private GameObject[] playerBlack = new GameObject [16];
    private GameObject[] playerWhite = new GameObject [16];

    public static string currentPlayer = "white";
    private bool gameOver = false;
    public string playerWinner;


    public float p1time, p2time;

    [SerializeField] Text p1Timer, p2Timer;
    // Start is called before the first frame update
    void Start()
    {
        p1time = 300f;
        p2time = 300f;

        playerWhite = new GameObject[]
        {

            Create ("whiteRook", 0,0), Create ("whiteKnight", 1,0), Create ("whiteBishop", 2,0), Create ("whiteQueen", 3,0),
            Create ("whiteKing", 4,0), Create ("whiteBishop", 5,0), Create ("whiteKnight", 6,0), Create ("whiteRook", 7,0),
            Create ("whitePawn", 0,1), Create ("whitePawn", 1,1), Create ("whitePawn", 2,1), Create ("whitePawn", 3,1),
            Create ("whitePawn", 4,1), Create ("whitePawn", 5,1), Create ("whitePawn", 6,1), Create ("whitePawn", 7,1) 
        };

        playerBlack = new GameObject[]
    {
            Create ("blackRook", 0,7), Create ("blackKnight", 1,7), Create ("blackBishop", 2,7), Create ("blackQueen", 3,7),
            Create ("blackKing", 4,7), Create ("blackBishop", 5,7), Create ("blackKnight", 6,7), Create ("blackRook", 7,7),
            Create ("blackPawn", 0,6), Create ("blackPawn", 1,6), Create ("blackPawn", 2,6), Create ("blackPawn", 3,6),
            Create ("blackPawn", 4,6), Create ("blackPawn", 5,6), Create ("blackPawn", 6,6), Create ("blackPawn", 7,6)
    };

        for (int i = 0; i < playerBlack.Length; i ++)
        {
            setPos(playerBlack[i]);
            setPos(playerWhite[i]);
        }
    }

    public GameObject Create (string name, int x, int y)
    {
        GameObject obj = Instantiate(chessPiece, new Vector3(0, 0, -1), Quaternion.identity);
        ChessMan cm = obj.GetComponent<ChessMan>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }


    public void surrender()
    {
        if (currentPlayer == "white")
        {
            SceneManager.LoadScene("P2Victory");
        }
        else
        {
            SceneManager.LoadScene("P1Victory");
        }
    }
    public void setPos(GameObject obj)
    {
        ChessMan cm = obj.GetComponent<ChessMan>();
        positions[cm.GetXBoard(), cm.getYBoard()] = obj;
    }

    public void SetPositionEmpty (int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition (int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard (int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) {
            return false;
        } else
        {
            return true;
        }
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "white")
        {
            currentPlayer = "black";
        }

        else
        {
            currentPlayer = "white";
        }
    }

    public void Update()
    {
        //Winner(playerWinner);
        if (gameOver == true)
        {
            StartCoroutine(LoadMainMenu()); 
        }

        if(currentPlayer == "white" && gameOver == false)
        {
            p1time -= 1 * Time.deltaTime;
        } 
        else if (currentPlayer == "black" && gameOver == false)
        {
            p2time -= 1 * Time.deltaTime;
        }

        if(p1time == 0 || p1time <= 0)
        {
            p1time = 0;
            gameOver = true;
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " is the winner";
        }

        else if(p2time == 0 || p2time <= 0)
        {
            p2time = 0;
            gameOver = true;
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
            GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " is the winner";
        }

        p1Timer.text = p1time.ToString("0");
        p2Timer.text = p2time.ToString("0");
    }

    public void Winner (string playerWinner)
    {
        gameOver = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " is the winner";
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5f); 
        SceneManager.LoadScene("GameMenu");
    }
}
