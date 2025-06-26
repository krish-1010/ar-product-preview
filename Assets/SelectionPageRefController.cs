using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPageRefController : MonoBehaviour
{
    public void ChangeProductLink(string link)
    {
        GameObject.Find("ProductSelectionManager").GetComponent<ProductSelectionController>().productLink = link;
    }

    public void ChangeProductName(string name)
    {
        GameObject.Find("ProductSelectionManager").GetComponent<ProductSelectionController>().productName = name;
    }

    public void changeSceneWithIndex(int index)
    {
        GameObject.Find("ProductSelectionManager").GetComponent<ProductSelectionController>().ChangeSceneindex(index);
    }
}
