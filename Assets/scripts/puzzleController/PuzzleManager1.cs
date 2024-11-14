using UnityEngine;
using System.Collections;

public class PuzzleManager1 : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    private int[,] puzzleMatrix;
    private int emptyRow, emptyCol;

    public int ShuffleNum = 3;

    private int checking = 0;

    public bool isreach = false;

    public bool IspuzzleComplete = false;

    void Start()
    {

             // IspuzzleComplete = false;
        // Initialize the puzzle matrix
        puzzleMatrix = new int[,]
            {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8}
            };
            // Set emptyRow and emptyCol to the new position of '0'
            emptyRow = 0;
            emptyCol = 0;

            // Assign initial positions to puzzle pieces
            for (int i = 0; i < 9; i++)
            {
                int row = i / 3;
                int col = i % 3;
                puzzlePieces[i].transform.position = GetWorldPosition(row, col);
            }

            // Randomize the puzzle
            StartCoroutine(ShufflePuzzleCoroutine(ShuffleNum));

        //



    }

    void Update()
    {
        if (isreach && !IspuzzleComplete)
        {
            //
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                TryMoveDown();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                TryMoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                TryMoveLeft();
            }

            // Check for win condition

            if (IsSolved() && checking == ShuffleNum )//&& !IspuzzleComplete)
            {
                Debug.Log("Puzzle Solved!");
                IspuzzleComplete = true;                 
            }
            //

        }
        
    }

    bool TryMoveUp()
    {
        if (emptyRow > 0)
        {
            Swap(emptyRow, emptyCol, emptyRow - 1, emptyCol);
            emptyRow--;
            return true; // Indicate successful move
        }
        return false; // Indicate failed move
    }

    bool TryMoveDown()
    {
        if (emptyRow < 2)
        {
            Swap(emptyRow, emptyCol, emptyRow + 1, emptyCol);
            emptyRow++;
            return true;
        }
        return false;
    }

    bool TryMoveLeft()
    {
        if (emptyCol > 0)
        {
            Swap(emptyRow, emptyCol, emptyRow, emptyCol - 1);
            emptyCol--;
            return true;
        }
        return false;
    }

    bool TryMoveRight()
    {
        if (emptyCol < 2)
        {
            Swap(emptyRow, emptyCol, emptyRow, emptyCol + 1);
            emptyCol++;
            return true;
        }
        return false;
    }

    void Swap(int row1, int col1, int row2, int col2)
    {
        int temp = puzzleMatrix[row1, col1];
        puzzleMatrix[row1, col1] = puzzleMatrix[row2, col2];
        puzzleMatrix[row2, col2] = temp;

        // Update the positions of the swapped pieces
        puzzlePieces[puzzleMatrix[row1, col1]].transform.position = GetWorldPosition(row1, col1);
        puzzlePieces[puzzleMatrix[row2, col2]].transform.position = GetWorldPosition(row2, col2);
    }

    Vector3 GetWorldPosition(int row, int col)
    {
        // Adjust the x and y coordinates based on the given positions
        float x = 114.472488f + col * 16.382264f;
        float y = 111.0584f - row * 16.65453f;
        float z = 400.939789f;

        return new Vector3(x, y, z);
    }

    bool IsSolved()
    {
        int expectedValue = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (puzzleMatrix[i, j] != expectedValue)
                {
                    return false;
                }
                expectedValue++;
            }
        }
        return true;
    }
    //
    IEnumerator ShufflePuzzleCoroutine(int shuffleCount)
    {
        for (int i = 0; i < shuffleCount; i++)
        {
            checking++;
            int direction = Random.Range(0, 4);

            switch (direction)
            {
                case 0:
                    TryMoveUp();
                    break;
                case 1:
                    TryMoveDown();
                    break;
                case 2:
                    TryMoveRight();
                    break;
                case 3:
                    TryMoveLeft();
                    break;
            }

            // Wait for 1 second before the next move
            yield return new WaitForSeconds(1f);
        }
    }



}