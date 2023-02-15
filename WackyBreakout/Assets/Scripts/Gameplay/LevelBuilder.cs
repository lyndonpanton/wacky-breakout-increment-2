using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPaddle;
    // Start is called before the first frame update
    void Start()
    {
        GameObject paddle = Instantiate(prefabPaddle);

        paddle.transform.position = new Vector2(
            0,
            -4.2f
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
