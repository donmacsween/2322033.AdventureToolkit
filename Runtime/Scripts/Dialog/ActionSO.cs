
using UnityEngine;

namespace ADVTK
{
    [CreateAssetMenu(fileName = "Action", menuName = "ADVTK/Action")]
    public class ActionSO : ScriptableObject
    {
        // enum defined in DialogManager.cs - can be customised to extend the toolkit
        // showNextDialog,setNPCDialog,exitDialog,setFlagTrue,setFlagFalse, giveItem,takeItem
        public actionTypes  actionType;
        // a string index in the FlagManager.cs system
        public string       flag;
        public ItemSO       item;
        public DialogSO     dialog;
    }
}
