using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ADVTK
{
    public class FlagManager : MonoBehaviour
    {
        // a singleton reference to this object is used so it can be accessed anywhere in the project;
        public static FlagManager Instance { get; private set; }
        // A dictionary has been used for flags as it has an easy to understand key/value pair
        // eg "isSecurityDoorLocked", true
        public Dictionary<string, bool> flagList;
        
        // the file name for saved data
        [SerializeField] private string fileName = "flagdata.bin";
        // the file path for saved data
        [SerializeField] private string dictPath { get { return Application.dataPath + "/" + fileName; } }

        // Unity Methods
        private void Awake()
        {
            // Ensure this gameobject is persistent across sceene loads
            DontDestroyOnLoad(this);
            // Ensure this gameobject has a single instance (singleton)
            EnforceSingleton();
            flagList = new Dictionary<string, bool>();
            // Add all the flags you want setting at the start of the game below here 
            // e.g SetFlag("isSecurityDoorLocked", true);
        }

        // private methods
        private void EnforceSingleton()
        {
            // if there is already an instance of this destroy this object
            if (Instance != null && Instance != this)
            { Destroy(this); }
            // otherwise set the instance to this object
            else { Instance = this; }
        }
        
        // public methods

        public bool CheckFlag(string flagName)
        {
            if (!flagList.ContainsKey(flagName)) 
            {
                Debug.LogWarning("Trying to get a flag: " + flagName + "that has not been set");
                return false;
            }
            flagList.TryGetValue(flagName, out bool flagValue);
            return flagValue;
        }

        public void SetFlag (string flagName, bool flagValue)
        {
            if (flagList.ContainsKey(flagName))
            {
                flagList[flagName] = flagValue;
            }
            else
            {
                flagList.Add(flagName, flagValue);
            }
        }

        public void RemoveFlag(string flagName) 
        {
            if (flagList.ContainsKey(flagName))
            {
                
                flagList.Remove(flagName);
            }
            else
            {
                Debug.LogWarning("Trying to remove: " + flagName + "that has not been set");
            }
            
        }

        public void Save()
        {
            // temporary holder of our dictionary entry
            string serializedData;
            // open a file to write to
            using (var writer = new StreamWriter(File.Open(dictPath, FileMode.CreateNew)))
            {
                // for every flag in our dictionary
                foreach (KeyValuePair<string, bool> flag in flagList)
                {
                    // combign the key and data into our string
                    serializedData = flag.Key + "=" + flag.Value;
                    // and write that string out to our file
                    writer.WriteLine(serializedData);
                }
                // close our file once all the data is written
                writer.Close();
            }
        }
        public void Load()
        {
            using (var reader = new StreamReader(File.OpenRead(dictPath)))
            {
                // temporary holder of our dictionary entry
                string line;
                // temporary holder of the flag's value
                bool flagvalue;
                // the dictionary should be empty at this point but clear it to be sure.
                flagList.Clear();
                // Read (string) lines from the file until the end of the file.
                while ((line = reader.ReadLine()) != null)
                {
                    // elements[0] should always be the key name and elements[1] the value 
                    string[] elements = line.Split('=');
                    // convert our value back into a bool
                    if (elements[1] == "true") { flagvalue = true; }
                    else { flagvalue = false; }
                    // add the data back into the dictionary
                    flagList.Add(elements[0], flagvalue);
                }
                // close our file once all the data is read
                reader.Close();
            }
        }
    }
}

