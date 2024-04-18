
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour
{
    // Singleton Property
                     public static  UIManager   Instance { get; private set; }
    [Header("Audio Settings")]
    [SerializeField] private        AudioClip   onPointerOverSound;
    [SerializeField] private        AudioClip   onPointerClickSound;
                     private        AudioSource uiAudioSource;
    [Header("Panel References")]
                     public         GameObject  startGamePanel;
                     public         GameObject  loadScenePanel;
                     public         GameObject  loadGamePanel;
                     public         GameObject  creditsPanel;
                     public         GameObject  exitPanel;
                     public         GameObject  settingsPanel;
    [Header("Panel Management")]
    [SerializeField] private        GameObject  initialPanel;
    [SerializeField] private        GameObject  currentPanel;

    // - Unity MonoBehaviour methods ------------------------------------------------|
    // - Private Methods ------------------------------------------------------------|
    
    /// <summary>
    ///  Unity method called before the first frame of a scene is rendered
    ///  used for initialisation of key components
    /// </summary>
    private void Awake()
    {
        // Get a reference to the audio source on this gameobject
        uiAudioSource = GetComponent<AudioSource>();
    }
    // - Private Methods ------------------------------------------------------------|

    /// <summary>
    /// Ensures there is only one instance of this manager
    /// </summary>
    private void EnforceSingleton()
    {
        if (Instance != null && Instance != this)
        { Destroy(this); }
        else
        { Instance = this; }
    }

    // + Public Methods -------------------------------------------------------------|

    /// <summary>Shows the desired panel</summary>
    /// <param name="panel">The GameObject with UI Panel to be show</param>
    public void ShowPanel(GameObject panel)
    {
        // if there are no panels currently open
        if (currentPanel == null) 
        {
            // make the parameter panel the current one
            currentPanel = panel;
            // and show it
            panel.SetActive(true);
        }
        else
        {
            // hide the current panel
            HidePanel(currentPanel);
            // show the parameter panel
            panel.SetActive(true);
            // make the parameter panel the current one
            currentPanel = panel;
        }
    }

    /// <summary>Hides the desired panel</summary>
    /// <param name="panel">The GameObject with UI Panel to be hidden</param>
    public void HidePanel(GameObject panel)
    {
        // hide the current panel
        panel.SetActive(false);
        // nulls the current panel
        currentPanel = null;
    }
   
    /// <summary>
    /// Called from an Event Trigger component on the UI buttons
    /// when the player moves the pointer over a button
    /// </summary>
    public void PlayPointerOverSound()
    
    {
        // If the developer has set a sound clip
        if (onPointerOverSound != null)
        {
            // play the sound once
            uiAudioSource.PlayOneShot(onPointerOverSound);
        }
    }

    /// <summary>
    /// Called from an Event Trigger component on the UI buttons
    /// when the player clicks on a button
    /// </summary>
    public void PlayPointerClickSound()
    {
        // If the developer has set a sound clip
        if (onPointerClickSound != null)
        {
            // play the sound once
            uiAudioSource.PlayOneShot(onPointerClickSound);
        }
    }

}
