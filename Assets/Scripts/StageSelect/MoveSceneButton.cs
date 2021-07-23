using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveSceneButton : MonoBehaviour
{
    [SerializeField] Scene scene;

    [SerializeField] Color color;

    [SerializeField] string description;

    private Text difficulty;

    private Color default_color;

    private string default_description;

    public void OnButtonClick()
    {
        SceneManager.LoadScene(scene.handle);
    }

    public void OnButtonHighlighted()
    {
        Debug.Log(description);

        difficulty.color = color;
        difficulty.text = description;
    }

    public void OnButtonDishighlighted()
    {
        difficulty.color = Color.white;
        difficulty.text = ""; 
    }

    // Start is called before the first frame update
    void Start()
    {
        difficulty = GameObject.Find("Difficulty").GetComponent<Text>();

        default_color = new Color(
            difficulty.color.r,
            difficulty.color.g,
            difficulty.color.b
            );

        default_description = string.Copy(difficulty.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
