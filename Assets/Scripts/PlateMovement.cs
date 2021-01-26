using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeMovement : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;


    int matrixX;
    int matrixY;

    public bool attack = false;

    public void Start()
    {
        if(attack)
        {
            //Changing color to red (plate)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f); 
        }


    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if(attack)
        {
            GameObject cs = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            Destroy(cs);
        }

        controller.GetComponent<Game>().SetposEmpty(reference.GetComponent<Chessscript>().GetXBoard(),
            reference.GetComponent<Chessscript>().GetYBoard());

        reference.GetComponent<Chessscript>().SetXBoard(matrixX);
        reference.GetComponent<Chessscript>().SetYBoard(matrixY);
        reference.GetComponent<Chessscript>().SettingCoordinates();

        controller.GetComponent<Game>().SetPos(reference);
        reference.GetComponent<Chessscript>().DestroyMovePlates();

    }

    public void SettingCoordinates(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void Setref(GameObject obj)
    {
        reference = obj;
    }

    public GameObject Getref()
    {
        return reference;
    }

}
