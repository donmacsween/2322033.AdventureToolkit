// Author  : Don MacSween.
// Purpose : A data store for optional conditions within dialog
using UnityEngine;

namespace ADVTK
{
    [CreateAssetMenu(fileName = "Condition", menuName = "ADVTK/Condition")]
    public class ConditionSO : ScriptableObject
    {
        public string   flagToBeChecked;
        public bool     checkTrueOrFalse;
    }
}
