using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public GameObject pieces;
    public GameObject board;
    public int sira = 0;
    public new List<GameObject> map = new List<GameObject>();
    public GameObject redKing;
    public GameObject blueKing;
    public GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.ToString() == "SampleScene")
        {
            blueKing = GameObject.Find("Blue");
            blueKing = blueKing.transform.GetChild(16).gameObject;
            redKing = GameObject.Find("Red");
            redKing = redKing.transform.GetChild(16).gameObject;
            //Tahtadaki her altıgeni mape ekliyor.
            for (int i = 0; i < board.transform.childCount; i++)
            {
                map.Add(board.transform.GetChild(i).gameObject);
            }
            //Oyundaki her taşı kontrol ediyor. Hangi altıgenin üstünde duruyorsa, altıgenin içine üstünde duran taşı yolluyor.
            for (int i = 0; i < pieces.transform.childCount; i++)
            {
                for (int j = 0; j < pieces.transform.GetChild(i).childCount; j++)
                {
                    foreach (var item in map)
                    {
                        if (item.GetComponent<Click>().x == pieces.transform.GetChild(i).transform.GetChild(j).GetComponent<Piece>().positionX && item.GetComponent<Click>().y == pieces.transform.GetChild(i).transform.GetChild(j).GetComponent<Piece>().positionY)
                        {
                            item.GetComponent<Click>().onIt = pieces.transform.GetChild(i).transform.GetChild(j).GetComponent<Piece>();
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < board.transform.childCount; i++)
            {
                map.Add(board.transform.GetChild(i).gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.ToString() == "SampleScene")
        {
            if (redKing == null || blueKing==null)
            {
                StartCoroutine(ifDestroyed());
            }
        }
    }
    IEnumerator ifDestroyed()
    {
        if (sira == 1)
        {
            prefab.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = "Kazanan\nKirmizi Takim";
        }
        else
        {
            prefab.transform.GetChild(0).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = "Kazanan\nMavi Takim";
        }
        Instantiate(prefab).transform.SetParent(this.transform);
        enabled = false;
        yield return null;
    }
}
