using UnityEngine;
using UnityEngine.UI;

public class ScoreTextLink : MonoBehaviour
{
    void Start()
    {
        //find text component
        Text txt = GetComponent<Text>();

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.UpdateTextBox(txt);
        }
    }
}
