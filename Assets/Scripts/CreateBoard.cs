using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CreateBoard : MonoBehaviour
{
    public GameObject tile;
    private Dictionary<int[], GameObject> tiles = new Dictionary<int[], GameObject>();
    public Material mtr;
    public GameObject game;

    //silicem burayı
    public int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Oyun sahnesi
        if (SceneManager.GetActiveScene().name.ToString() == "SampleScene")
        {
            for (int j = -5; j <= 5; j++)
            {
                for (int i = -5; i <= 5; i++)
                {
                    if (j < 0 && i < 0 && Math.Abs(i) + Math.Abs(j) > 5)
                    {
                        continue;
                    }
                    else if (j > 0 && i > 0 && i + j > 5)
                    {
                        continue;
                    }
                    else
                    {
                        tiles.Add(new int[] { i, j }, tile);
                        count++;
                    }
                }
            }

            foreach (var item in tiles)
            {
                item.Value.GetComponent<Click>().x = item.Key[0];
                item.Value.GetComponent<Click>().y = item.Key[1];
                GameObject newobj = Instantiate(item.Value, new Vector3(item.Key[0] * 0.9f + (item.Key[1] * 0.45f), item.Key[1] * 0.75f, 1), Quaternion.identity);
                newobj.transform.SetParent(this.transform);
                newobj.GetComponent<Renderer>().material.SetColor("_Color", mtr.color);
            }
        }
        //Setup sahnesi
        if (SceneManager.GetActiveScene().name.ToString() == "SetupScene")
        {
            for (int j = -5; j <= -1; j++)
            {
                for (int i = -5; i <= 5; i++)
                {
                    if (j < 0 && i < 0 && Math.Abs(i) + Math.Abs(j) > 5)
                    {
                        continue;
                    }
                    else if (j > 0 && i > 0 && i + j > 5)
                    {
                        continue;
                    }
                    else
                    {
                        tiles.Add(new int[] { i, j }, tile);
                        count++;
                    }
                }
            }

            foreach (var item in tiles)
            {
                item.Value.GetComponent<Click>().x = item.Key[0];
                item.Value.GetComponent<Click>().y = item.Key[1];
                GameObject newobj = Instantiate(item.Value, new Vector3(item.Key[0] * 0.9f + (item.Key[1] * 0.45f), item.Key[1] * 0.75f, 1), Quaternion.identity);
                newobj.transform.SetParent(this.transform);
                newobj.GetComponent<Renderer>().material.SetColor("_Color", mtr.color);
            }
        }
    }
}
