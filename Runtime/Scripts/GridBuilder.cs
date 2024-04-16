// Author  : Don MacSween.
// Purpose : This class builds a grid of prefabs and subsequent AI NavMeshSurface 

// Included namespaces
using UnityEngine;
using UnityEngine.Events;
using Unity.AI.Navigation;

namespace ADVTK
{
    // Ensure that a NavMeshSurface is available on this GameObject
    [RequireComponent(typeof(NavMeshSurface))]
    public class GridBuilder : MonoBehaviour
    {
        // Seralized     Accessor Datatype                  Name                Initial value      
        [SerializeField] private Vector3                    gridOrigin;
        [SerializeField] private int                        gridSizeX           = 0;
        [SerializeField] private int                        gridSizeZ           = 0;
     //   [SerializeField] private float                      gridY               = 0f;
        [SerializeField] private float                      gridCellSize        = 0f;
        [SerializeField] private GameObject                 defaultTilePrefab   = null;
        [SerializeField] private bool                       enableNavigation = true;
       
        [SerializeField] private GridTileSO[]               tiles;
        [SerializeField] private UnityEvent                 postBuildEvents = null;
                         private NavMeshSurface             surface;

       
        /// <summary>
        /// Validates & initialises fields then invokes the initial methods
        /// Awake is used as it happens before the first frame of the scene is rendered
        /// so the player does not see the grid being built, with the tradeoff of 
        /// a slightly longer load time
        /// </summary>
        private void Awake()
        {
            // field validation
            if (gridSizeX <= 0 || gridSizeZ <= 0 || gridCellSize <= 0f || gridCellSize == 0)
            {
                Debug.LogError("One or more properties have not been set on the GridBuilder script");
            }                 
            // Builds the grid of prefabs
            BuildGrid();
            // Builds an AI navigation mesh if required
            if (enableNavigation) 
            {
                // Assigns the (required) NavMeshSurface
                surface = gameObject.GetComponent<NavMeshSurface>();
                BuildGridNavMeshSurface(); 
            }
            // Invoke any custom scripts the developer has added in scene
            if (postBuildEvents != null) { postBuildEvents.Invoke(); }
        }

        /// <summary>
        /// Builds the grid from prefabs included in the tiles array 
        /// </summary>
        private void BuildGrid()
        {
           
            // Loop through the Z & X axis
            for (int gridX = 0; gridX < gridSizeX; gridX++)
            {
                for (int gridZ = 0; gridZ < gridSizeZ; gridZ++)
                {
                    // Temp index holder - used as both an index and flag 
                    int m_tilefound = -1;
                    // Loop through the array of set tiles
                    for (int i = 0; i < tiles.Length; i++)
                    {
                        // if a tile has been set for this location set our temp index holder to the index value
                        if (tiles[i].tileXPosition == gridX && tiles[i].tileZPosition == gridZ)
                        {
                            m_tilefound = i;
                        }
                    }
                    if (m_tilefound >= 0)
                    {
                        GameObject tile = Instantiate(tiles[m_tilefound].tilePrefab, this.gameObject.transform);
                        tile.transform.position = new Vector3(gridX * gridCellSize, tiles[m_tilefound].YOffset, gridZ * gridCellSize);
                    }
                    // otherwise use the default tile
                    else
                    {
                        if (defaultTilePrefab != null)
                        {
                            GameObject tile = Instantiate(defaultTilePrefab, this.gameObject.transform);
                            tile.transform.position = new Vector3(gridX * gridCellSize, 0f, gridZ * gridCellSize);
                        }  
                    }
                }
            }
        }
       
        /// <summary>
        /// Builds a navigation mesh over the prefabs instantiated in BuildGrid()
        /// </summary>
        private void BuildGridNavMeshSurface()
        {
            // Set the surface to only build a navmesh from the children of this gameobject
            surface.collectObjects = CollectObjects.Children;
            // if you wish to customise your NavMesh's properties do it here 

            // build the navmesh
            surface.BuildNavMesh();
        }
    }
}

// Unity Manual / Scripting References
// https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
// https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshSurface.html
// https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
// C# Array reference
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays
