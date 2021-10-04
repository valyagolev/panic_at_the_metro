using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    public string current = "You find yourself deep underground, mood unbalanced, purpose uncertain";

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = current;
    }

    static public void Write(string s)
    {
        _instance.current = s;
    }

    // SINGLETON
    private static Log _instance;

    public static Log Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    // /SINGLETON
}
