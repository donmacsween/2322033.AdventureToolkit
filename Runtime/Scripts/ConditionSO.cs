
using UnityEngine;

namespace ADVTK
{
    [CreateAssetMenu(fileName = "Condition", menuName = "ADVTK/Condition")]
    public class ConditionSO : ScriptableObject
    {
        public string flagToBeChecked;
        public bool checkTrueOrFalse;
    }
}
