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

    public void Restart()
    {
        SceneManager.LoadScene("GameMenu");
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
        yield return fbScript.downloadGreenPieces("whitePawn");
        yield return fbScript.downloadGreenPieces("whiteKing");
        yield return fbScript.downloadGreenPieces("whiteKnight");
        yield return fbScript.downloadGreenPieces("whiteRook");
        yield return fbScript.downloadGreenPieces("whiteQueen");
        yield return fbScript.downloadGreenPieces("whiteBishop");

    }

    IEnumerator downloadPiecesPink()
    {
        yield return fbScript.downloadPinkPieces("whitePawn");
        yield return fbScript.downloadPinkPieces("whiteKing");
        yield return fbScript.downloadPinkPieces("whiteKnight");
        yield return fbScript.downloadPinkPieces("whiteRook");
        yield return fbScript.downloadPinkPieces("whiteQueen");
        yield return fbScript.downloadPinkPieces("whiteBishop");

    }
}



