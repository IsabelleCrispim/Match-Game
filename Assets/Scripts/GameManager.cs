using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    public Card card_1;
    public Card card_2;
    public Canvas canvas;
    // Lista de las cartas
    List<Card> baralho;
    bool checkingMatch;
    // Start is called before the first frame update
    public void Start()
    {
        baralho = Embaralhar(FindObjectsOfType<Card>().ToList());
        MoveCards();
        checkingMatch = false;
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !checkingMatch)
        {
            var clickedPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach ( Card card in baralho)
            {
                if (card.IsClicked(clickedPos))
                {
                    card.Flip();
                    if (card_1 == null)
                    {
                        card_1 = card;
                    }
                    else if (card_2 == null)
                    {
                        card_2 = card;
                    }

                    if (card_1 != null && card_2 != null )
                    {
                        StartCoroutine(CheckMatch());
                    }
                }
            }
        }

    }

    List<Card> Embaralhar(List<Card> baralho)
    {

        Card[] tempBaralho = baralho.ToArray();
        System.Random random = new System.Random();

        for (int i = 0; i < tempBaralho.Length; i++)
        {
            int randomIndex = random.Next(tempBaralho.Length);
            Card firstCard = tempBaralho[i];
            Card secondCard = tempBaralho[randomIndex];

            tempBaralho[i] = secondCard;
            tempBaralho[randomIndex] = firstCard;
        }

        return tempBaralho.ToList();

    }

    void MoveCards()
    {
        float x = -4.8f;
        float y = 3.2f;

        for (int i=1; i <= baralho.ToArray().Length; i++)
        {
            baralho[i - 1].gameObject.transform.Translate(x, y, 0);
            x += 3.2f;
            if (i % 4 == 0)
            {
                x = -4.8f;
                y -= 3.2f;
            }
        }
    }

     IEnumerator CheckMatch()
    {
        int seconds = 1;
        checkingMatch = true;
        for ( int count = 0; count < seconds; count++)
        {
            yield return new WaitForSeconds(1f);
        }

        if (card_1.cardName == card_2.cardName)
        {
            card_1.gameObject.SetActive(false);
            card_2.gameObject.SetActive(false);
            if(CheckForWinner())
            {
                canvas.gameObject.SetActive(true);
            }
        }
        else
        {
            card_1.Flip();
            card_2.Flip();
        }
        card_1 = null;
        card_2 = null;

        checkingMatch = false;
    }

    bool CheckForWinner()
    {
       // verificar se todas as cartas estao desativadas; 
       //se todas as cartas estao desativadas crear mensagem celebracao; 


        foreach ( Card card in baralho )
        {
            if (card.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true; 


    }
        
}

    

