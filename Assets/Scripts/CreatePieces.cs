using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatePieces : MonoBehaviour
{
    #region prefabs
    [SerializeField]
    private GameObject Rabble;
    [SerializeField]
    private GameObject Spearman;
    [SerializeField]
    private GameObject Elephant;
    [SerializeField]
    private GameObject LightHorse;
    [SerializeField]
    private GameObject HeavyHorse;
    [SerializeField]
    private GameObject Crossbowman;
    [SerializeField]
    private GameObject Catapult;
    [SerializeField]
    private GameObject Trebuchet;
    [SerializeField]
    private GameObject Dragon;
    [SerializeField]
    private GameObject King;
    [SerializeField]
    private GameObject Mountain;
    #endregion

    [SerializeField]
    private PieceType[] piecesForEach;
    [SerializeField]
    private GameObject game;
    public List<GameObject> blueTeam = new List<GameObject>();
    public List<GameObject> redTeam = new List<GameObject>();
    public static int x = 0; //sıra
    // Start is called before the first frame update
    void Start()
    {
        int a = 0;
        //setup sahnesi
        if (SceneManager.GetActiveScene().name.ToString() == "SetupScene")
        {
            if (x == 0) {
                foreach (var item in piecesForEach)
                {
                    GameObject g = founder(item);
                    g.GetComponent<Piece>().positionY = 0;
                    blueTeam.Add(g);
                }
                foreach (var item in blueTeam)
                {
                    item.GetComponent<Piece>().team = Teams.Blue.ToString();
                    Instantiate(item, new Vector3(-7.1f + (a * 0.8f), 5f, -1), Quaternion.identity).transform.SetParent(this.transform);
                    a += 1;
                }
            }
            else
            {
                foreach (var item in piecesForEach)
                {
                    GameObject g = founder(item);
                    g.GetComponent<Piece>().positionY = 0;
                    redTeam.Add(founder(item));
                }
                foreach (var item in redTeam)
                {
                    item.GetComponent<Piece>().team = Teams.Red.ToString();
                    Instantiate(item, new Vector3(-7.1f + (a * 0.8f), 5f, -1), Quaternion.identity).transform.SetParent(this.transform);
                    a += 1;
                }
            }
        }
        //oyun sahnesi
        else 
        {
            foreach (var item in piecesForEach)
            {
                blueTeam.Add(founder(item));
                redTeam.Add(founder(item));
            }

            foreach (var item in blueTeam)
            {
                item.GetComponent<Piece>().team = Teams.Blue.ToString();
                item.GetComponent<Piece>().positionX = Layout.blue[a][0];
                item.GetComponent<Piece>().positionY = Layout.blue[a][1];
                Instantiate(item, new Vector3(Layout.blue[a][0] * 0.9f + (Layout.blue[a][1] * 0.45f), Layout.blue[a][1] * 0.75f, -1),
                    Quaternion.identity).transform.SetParent(this.transform.GetChild(0));
                a += 1;
            }
            a = 0;
            foreach (var item in redTeam)
            {
                item.GetComponent<Piece>().team = Teams.Red.ToString();
                item.GetComponent<Piece>().positionX = Layout.red[a][0];
                item.GetComponent<Piece>().positionY = Layout.red[a][1];
                Instantiate(item, new Vector3(Layout.red[a][0] * 0.9f + (Layout.red[a][1] * 0.45f), Layout.red[a][1] * 0.75f, -1),
                    Quaternion.identity).transform.SetParent(this.transform.GetChild(1));
                a += 1;
            }
            GameObject obj = GameObject.Find("layout");
            Destroy(obj);
        }
    }
    private GameObject founder(PieceType p)
    {
        switch (p)
        {
            case PieceType.Rabble:
                return Rabble;
            case PieceType.Spearman:
                return Spearman;
            case PieceType.Catapult:
                return Catapult;
            case PieceType.Crossbowman:
                return Crossbowman;
            case PieceType.Dragon:
                return Dragon;
            case PieceType.King:
                return King;
            case PieceType.Trebuchet:
                return Trebuchet;
            case PieceType.Mountain:
                return Mountain;
            case PieceType.LightHorse:
                return LightHorse;
            case PieceType.HeavyHorse:
                return HeavyHorse;
            case PieceType.Elephant:
                return Elephant;
            default:
                return Rabble;
        }
    }
}
