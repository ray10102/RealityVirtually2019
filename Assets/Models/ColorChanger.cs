using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private MeshRenderer[] renderers;
    [SerializeField]
    private bool shouldLerp;
    [SerializeField]
    private Color lerpTo;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int rendererCount;

    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
        shouldLerp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLerp)
        {
            for (int i = 0; i < rendererCount; i++)
            {
                renderers[i].material.color = Color.Lerp(renderers[i].material.color, lerpTo, speed * Time.deltaTime);
            }
        }
    }
   
    public void ChangeColor(Color color)
    {
        shouldLerp = true;
        lerpTo = color;
    }
 
}
