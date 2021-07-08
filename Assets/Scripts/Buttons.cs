using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class Buttons : MonoBehaviour
{
    public GameObject pieces;
    public void startgame()
    {
        SceneManager.LoadScene("SetupScene");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void closegame()
    {
        Application.Quit();
    }
    public void tutorial()
    {
        SceneManager.LoadScene("Howto");
    }
    public void ready()
    {
        bool ass = true;
        GameObject asd;
        if (CreatePieces.x == 0)
        {
            asd = GameObject.Find("Pieces");
            for (int i = 1; i < asd.transform.childCount; i++)
            {
                if (asd.transform.GetChild(i).GetComponent<Piece>().positionY == 0)
                {
                    ass = false;
                    break;
                }
                int[] x = { asd.transform.GetChild(i).GetComponent<Piece>().positionX, asd.transform.GetChild(i).GetComponent<Piece>().positionY };
                Layout.blue.Add(x);
            }
            if (ass == true)
            {
                SceneManager.LoadScene("SetupScene");
                CreatePieces.x++;
            }
        }
        else
        {
            asd = GameObject.Find("Pieces");
            for (int i = 1; i < asd.transform.childCount; i++)
            {
                if (asd.transform.GetChild(i).GetComponent<Piece>().positionY == 0)
                {
                    ass = false;
                    break;
                }
                int[] x = { asd.transform.GetChild(i).GetComponent<Piece>().positionX *-1, Math.Abs(asd.transform.GetChild(i).GetComponent<Piece>().positionY) };
                Layout.red.Add(x);
            }
            if (ass == true)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void random()
    {
        Random rnd = new Random();
        bool ass = true;
        bool varmı = false;
        GameObject asd;
        Random asdasd = new Random();
        List<int[]> deneme = new List<int[]>();
        if (CreatePieces.x == 0)
        {
            asd = GameObject.Find("Pieces");
            for (int i = 1; i < asd.transform.childCount; i++)
            {
                int y, x;
                int[] xy= {0,0};
                do{
                    varmı = false;
                    y = Random.Range(-1, -6);
                    x = Random.Range(-5 - y, 6);
                    xy[0] = x; 
                    xy[1] = y;
                    for (int j = 0; j < deneme.Count; j++)
                    {
                        if (deneme[j][0] == xy[0] && deneme[j][1] == xy[1])
                        {
                            varmı = true;
                        }
                    }
                } while (varmı) ;
                deneme.Add(xy);
                Layout.blue.Add(xy);
            }
            if (ass == true)
            {
                SceneManager.LoadScene("SetupScene");
                CreatePieces.x=1;
            }
        }
        else
        {
            asd = GameObject.Find("Pieces");
            for (int i = 1; i < asd.transform.childCount; i++)
            {
                int y, x;
                int[] xy = { 0, 0 };
                do
                {
                    varmı = false;
                    y = Random.Range(-1, -6);
                    x = Random.Range(-5 - y, 6);
                    xy[0] = x*-1;
                    xy[1] = Math.Abs(y);
                    for (int j = 0; j < deneme.Count; j++)
                    {
                        if (deneme[j][0] == xy[0] && deneme[j][1] == xy[1])
                        {
                            varmı = true;
                        }
                    }
                } while (varmı);
                deneme.Add(xy);
                Layout.red.Add(xy);
                CreatePieces.x = 0;
            }
            if (ass == true)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
