using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeGroup : MonoBehaviour
{
    private ColorChanger[] children;

    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<ColorChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad % 2 < .2 )
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].ChangeColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            }
        }
    }
}
