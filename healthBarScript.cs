using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{
    //Billboard - Something that always turns and faces camera
    //Such as a health bar always facing camera view
    //Implement with a quick and easy script

    public Slider sl1;
    public Gradient gradient1;

    public Image fill; //Declare image for gradient

    public void setMaxHealth(int health)
    {
        sl1.maxValue = health;
        sl1.value = health;

        fill.color = gradient1.Evaluate(1f); //Assigning gradient to image
    }

    public void setHealth(int health)
    {
        sl1.value = health;

        fill.color = gradient1.Evaluate(sl1.normalizedValue);
    }



}
