using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public string cardName;
    bool flipped = false;
    public Sprite backSide;
    public Sprite front;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsClicked(Vector2 clickedPos)
    {
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        if (clickedPos[0] < positionX + 1.5f && clickedPos[0] > positionX + -1.5f && clickedPos[1] < positionY + 1.5f && clickedPos[1] > positionY + -1.5f)
        {
            return true;
        }

        return false;
    }

    public void Flip ()
    {
        if (flipped)
        {
            sprite.sprite = backSide;
        }
        else
        {
            sprite.sprite = front;
        }
        flipped = !flipped;
    }
}  
















