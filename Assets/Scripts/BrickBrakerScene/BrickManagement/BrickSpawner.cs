using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    /// <summary>
    /// Left-Boundary gameobject. Should not overlap with TopBoundary and should start beneath it.
    /// </summary>
    [SerializeField] private SpriteRenderer leftBoundary;

    /// <summary>
    /// The brick-prefab
    /// </summary>
    [SerializeField] private GameObject pfbBrick;

    /// <summary>
    /// The amount of bricks to be spawned along x- and y-axis
    /// </summary>
    [SerializeField] private int brickCountX;
    [SerializeField] private int brickCountY;

    /// <summary>
    /// Defining space between spawned bricks and boundary, based on top-left corner
    /// </summary>
    [SerializeField] private float boundaryOffsetX = 0.5f;
    [SerializeField] private float boundaryOffsetY = 0.5f;

    /// <summary>
    /// Automatically called when attached gameobject is initialized
    /// </summary>
    private void Start()
    {
        SpawnBricks(GetSpawnStartPosition());
    }


    /// <summary>
    /// Spawns bricks using the pfbBrick
    /// </summary>
    /// <param name="startPos">The top-left starting position</param>
    private void SpawnBricks(Vector2 startPos)
    {
        SpriteRenderer r = pfbBrick.GetComponentInChildren<SpriteRenderer>();
        float xSize = r.bounds.size.x;
        float ySize = r.bounds.size.y;

        for (int i = 1; i <= brickCountX; i++) 
        {
            for(int j = 1; j <= brickCountY; j++)
            {
                GameObject newBrick = Instantiate(pfbBrick, transform);
                Vector2 adjustement = new Vector2(xSize * i, ySize * j * -1);
                newBrick.transform.position = startPos + adjustement;
            }
        }
    }


    /// <summary>
    /// Creates the starting position, using leftboundary sprite renderer and transform.position
    /// </summary>
    /// <returns>Accurate position relative to leftBoundary and offset.</returns>
    private Vector2 GetSpawnStartPosition()
    {
        Vector2 basePos = leftBoundary.transform.position;
        float xCorr = leftBoundary.bounds.size.x / 2;
        float yCorr = leftBoundary.bounds.size.y / 2;
        basePos.x += xCorr + boundaryOffsetX;
        basePos.y += yCorr + boundaryOffsetY * -1;

        return basePos;
    }

}
