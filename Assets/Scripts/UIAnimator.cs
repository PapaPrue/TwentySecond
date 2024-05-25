
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image image;
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    float interval;
    float x;
    [SerializeField]
    int spriteNum;
    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime;
        if (x > interval)
        {
            x = 0;
            spriteNum++;
            if(spriteNum>sprites.Length-1)
                spriteNum = 0;
            image.sprite = sprites[spriteNum];
            //gameObject.GetComponent<Image>().sprite=
             //= sprites[spriteNum];
        }

    }
}
