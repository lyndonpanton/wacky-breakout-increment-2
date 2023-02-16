using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;

    // Start is called before the first frame update
    void Start()
    {
        GameObject paddle = Instantiate(prefabPaddle);

        paddle.transform.position = new Vector2(
            0,
            -4.2f
        );

        GameObject dataBlock = Instantiate(prefabStandardBlock);
        BoxCollider2D dataBlockBC2D = dataBlock.GetComponent<BoxCollider2D>();

        float blockWidth = dataBlockBC2D.size.x;
        float blockHeight = dataBlockBC2D.size.y;
        //float blockWidth = dataBlock.transform.localScale.x;
        //float blockHeight = dataBlock.transform.localScale.y;
        float blockXGap;
        float blockYap;

        float currentYPosition = ScreenUtils.ScreenTop - blockHeight;

        for (int i = 0; i < 3; i++)
        {
            // change current y position here
            currentYPosition = currentYPosition - (i * blockHeight);

            float currentXPosition = 0;

            int k = 0;
            for (int j = 0; j < 11; j++)
            {

                GameObject block = Instantiate(prefabStandardBlock);

                if (j == 0 || j % 2 == 1)
                {
                    // change current x position here
                    currentXPosition = Mathf.Abs(currentXPosition) + (k * blockWidth);
                    block.transform.position = new Vector2(
                        currentXPosition,
                        currentYPosition
                    );

                    k++;
                }
                else
                {
                    // change current x position here
                    currentXPosition = -currentXPosition;
                    block.transform.position = new Vector2(
                        currentXPosition,
                        currentYPosition
                    );
                }
            }
        }

        Destroy(dataBlock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
