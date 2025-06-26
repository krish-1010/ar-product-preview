using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProductSelectionController : MonoBehaviour
{
    
    public string productLink;
    public string productName;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SelectSystem");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void ChangeSceneindex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void changeProductLink(string link)
    {
        productLink = link;
    }
    public void changeProductName(string name)
    {
        productName = name;
    }

}
