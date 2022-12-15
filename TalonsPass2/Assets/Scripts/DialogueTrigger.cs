using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [SerializeField] private bool playerInRange;
    public string scene;
    private void Awake()
    {
        playerInRange = false;
        visualCue.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.gameObject.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed() || Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("works");
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, gameObject);
            }
        }
        else
        {
            visualCue.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    public void Interrogate()
    {
        Debug.Log("Interrogate");
        SceneManager.LoadScene(scene);
    }
    
}