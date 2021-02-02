using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public firebaseScript fbScript;
    string path = "https://darrenbutt-14f73-default-rtdb.firebaseio.com/";

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Camera.main.gameObject.AddComponent<firebaseScript>();
        fbScript = Camera.main.GetComponent<firebaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadScene()
    {
        StartCoroutine(initDB(path));
        SceneManager.LoadScene("Game");
        StartCoroutine(fbScript.downloadAndSaveImage());
        StartCoroutine(downloadPieces());
        
    }

    public void LoadScenePink()
    {
        StartCoroutine(initDB(path));
        SceneManager.LoadScene("Game");
        StartCoroutine(fbScript.downloadAndSaveImage());
        StartCoroutine(downloadPiecesPink());
        
    }

    public void onClickQuit()
    {
        Application.Quit();
    }


   

    IEnumerator clearDB()
    {
        yield return fbScript.clearFirebase();
        Application.Quit();
    }

    IEnumerator initDB(string path)
    {
        yield return fbScript.initFirebase(path);
    }


    IEnumerator downloadPieces()
    {
        yield return fbScript.downloadGreenPieces("blackPawn");
        yield return fbScript.downloadGreenPieces("blackKing");
        yield return fbScript.downloadGreenPieces("blackKnight");
        yield return fbScript.downloadGreenPieces("blackRook");
        yield return fbScript.downloadGreenPieces("blackQueen");
        yield return fbScript.downloadGreenPieces("blackBishop");

    }

    IEnumerator downloadPiecesPink()
    {
        yield return fbScript.downloadPinkPieces("blackPawn");
        yield return fbScript.downloadPinkPieces("blackKing");
        yield return fbScript.downloadPinkPieces("blackKnight");
        yield return fbScript.downloadPinkPieces("blackRook");
        yield return fbScript.downloadPinkPieces("blackQueen");
        yield return fbScript.downloadPinkPieces("blackBishop");

    }
}



