using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ITriggerBox
{

    List<GameObject> Boxes { get; set; } 
    void AddBox(GameObject box, string tagbox1, string tagbox2, string tagbox3);
}

public class TriggerBox : ITriggerBox
{

    public List<GameObject> Boxes { get; set; }

    public TriggerBox()
    {

        Boxes = new List<GameObject>(); 
    }
    public void AddBox(GameObject box, string tagbox1, string tagbox2, string tagbox3)
    {

        if (box.gameObject.layer == 9 && Boxes.Count<4) //checks if its a box layer and its less than three
        {
            if (box.gameObject.tag == tagbox1 || box.gameObject.tag == tagbox2 || box.gameObject.tag == tagbox3)
            { 
                Boxes.Add(box);
            }
        
        }
    } 
}