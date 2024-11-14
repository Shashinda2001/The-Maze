using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] cubes; // Assign the cube GameObjects in the Inspector
    private Vector3 emptyPosition; // The position of the empty space
    private Vector3[] initialPositions; // To store the initial positions of the cubes
    private Vector3[] correctPositions; // Correct arrangement of the cubes

    private void Start()
    {
        // Set up the initial positions of the cubes
        initialPositions = new Vector3[]
        {
            new Vector3(114.472488f, 77.3110046f, 400.939789f),
            new Vector3(130.854752f, 77.3110046f, 400.939789f),
            new Vector3(147.806824f, 77.3110046f, 400.939789f),
            new Vector3(114.472488f, 93.965538f, 400.939819f),
            new Vector3(130.854752f, 93.965538f, 400.939819f),
            new Vector3(147.806824f, 93.965538f, 400.939819f),
            new Vector3(114.472488f, 111.05838f, 400.939819f),
            new Vector3(130.854752f, 111.05838f, 400.939819f),
            new Vector3(147.806824f, 111.05838f, 400.939819f)
        };

        // Set the correct positions (this should match the initial order)
        correctPositions = (Vector3[])initialPositions.Clone();

        // Shuffle the cubes and set one position as empty
        ShuffleCubes();
        emptyPosition = GetRandomEmptyPosition(); // Get the position of the empty cube initially
    }

    private void Update()
    {
        // Use KeyCode keys for cube movement to avoid conflict with WASD player controls
        if (Input.GetKeyDown(KeyCode.I))
        {
            MoveCube(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            MoveCube(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            MoveCube(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            MoveCube(Vector3.right);
        }

        // Check for win condition
        if (IsSolved())
        {
            Debug.Log("Puzzle Solved!");
        }
    }

    private void MoveCube(Vector3 direction)
    {
        Vector3 targetPosition = emptyPosition + direction;

        // Check if the target position corresponds to a cube's position
        foreach (var cube in cubes)
        {
            // Check if the cube's current position is close to the target position
            if (Vector3.Distance(cube.transform.position, targetPosition) < 0.1f)
            {
                // Move the cube to the empty position
                cube.transform.position = emptyPosition;
                emptyPosition = targetPosition; // Update the empty position
                Debug.Log($"Moved cube to empty position: {emptyPosition}");
                LogCubePositions(); // Log positions after each move
                return; // Exit after moving one cube
            }
        }

        Debug.Log("No cube found to move into the empty position.");
    }

    private void ShuffleCubes()
    {
        // Shuffle the cube positions randomly
        for (int i = 0; i < cubes.Length; i++)
        {
            GameObject temp = cubes[i];
            int randomIndex = Random.Range(i, cubes.Length);
            cubes[i] = cubes[randomIndex];
            cubes[randomIndex] = temp;

            // Update the position of each cube based on the shuffled array
            cubes[i].transform.position = initialPositions[i];
        }
    }

    private bool IsSolved()
    {
        // Check if the current positions match the correct positions
        for (int i = 0; i < cubes.Length; i++)
        {
            // Use a tolerance for floating-point comparison
            if (Vector3.Distance(cubes[i].transform.position, correctPositions[i]) > 0.1f)
            {
                return false; // Not solved yet
            }
        }
        return true; // All cubes are in the correct position
    }

    private Vector3 GetRandomEmptyPosition()
    {
        // Initially, set the last position as empty
        return initialPositions[8];
    }

    private void LogCubePositions()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            Debug.Log($"Cube {i} Position: {cubes[i].transform.position}");
        }
        Debug.Log($"Empty Position: {emptyPosition}");
    }
}
