using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMap : MonoBehaviour
{
    public GameObject Tree;
    [TextArea(30, 30)]
    public string Map;
    public float TileSize;
    [ContextMenu("Generate")]
    public void Generate()
    {
        Map.Replace("\r", "");
        string[] rows = Map.Split('\n');
        int size = rows[0].Length;
        for (int i = 0; i < size; i++)
        {
            string column = rows[i];
            for (int j = 0; j < size; j++)
            {
                if (column[j] != '0')
                {
                    GameObject tree = Instantiate(Tree, new Vector3((-size / 2 + j) * TileSize, Tree.transform.position.y, (size / 2 - i) * TileSize), Tree.transform.rotation);
                    tree.transform.parent = transform;
                    tree.SetActive(true);
                }
            }
        }
    }
}
