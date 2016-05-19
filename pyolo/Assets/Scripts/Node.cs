using UnityEngine;
using System.Collections;
public class Node : MonoBehaviour
{

    public int state;
    public Vector3 worldPosition;
    public float diameter;
    public int gCost;
    public int hCost, x, y;
    public Sprite node;
    public Sprite nodeS;
    SpriteRenderer spriteRenderer;
    public int fCost
    {
        get { return gCost + hCost; }
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = node;
        state = 1;
    }
    public void setProperty(int prop)
    {
        if(prop!=-2&&prop!=-1)state = prop;
        updateSprite();
        if(prop==-1&&state!=0)spriteRenderer.sprite = nodeS;

    }
    void updateSprite()
    {
        switch (state)
        {
            case 0:
                spriteRenderer.sprite = null;
                break;
            case 1:
                spriteRenderer.sprite = node;
                break;
        }
    }
   
}
