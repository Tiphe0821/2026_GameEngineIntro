using UnityEngine;

public class TestScript : MonoBehaviour
{
    public string playerName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("HelloWorld");
        Debug.LogError("HelloWorld!!");
        Debug.LogWarning("Helloworld!!!!");

        Debug.Log("Hello " + playerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
