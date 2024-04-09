// Author : Don MacSween
// Purpose : This classs is a template container to store data on grid tiles

// Included namespaces
using UnityEngine;

// Add a context menu to create new scriptable objects from this template
[CreateAssetMenu(fileName = "NewTile", menuName = "ADVTK/Tile")]
public class GridTileSO : ScriptableObject
{
    #region Fields
    // Accessor Datatype   Name             Value
    [Tooltip("This is the X part of an array so the first element starts at 0")]
    public      int        tileXPosition;
    [Tooltip("This is the Z part of an array so the first element starts at 0")]
    public      int        tileZPosition;
    [Tooltip("Height above the grid to place this prefab")]
    public      float      YOffset           = 0f;
    [Tooltip("The Tile Prefab to use")]
    public      GameObject tilePrefab;
    #endregion
}
// Unity Manual reference
// https://docs.unity3d.com/Manual/class-ScriptableObject.html
// C# Array reference
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays
