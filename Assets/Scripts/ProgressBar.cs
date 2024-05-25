using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Shift shift;
    public Sprite[] sprites;
    public Image status;
    public Image image;
    private void Update()
    {
        image.fillAmount = (shift.satisfaction / 100);
        if (image.fillAmount > .5)
        {
            status.sprite = sprites[0];
            image.color = Color.green;
        }
        else if (image.fillAmount < .5 && image.fillAmount > .25)
        {
            status.sprite = sprites[1];
            image.color = Color.yellow;
        }
        else
        {
            status.sprite = sprites[2];
            image.color = Color.red;
            
        }
    }

}
