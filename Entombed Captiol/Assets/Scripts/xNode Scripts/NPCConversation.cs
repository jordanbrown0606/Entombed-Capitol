using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class NPCConversation : MonoBehaviour
{
    [SerializeField] Quest _secondaryQuest = null;

    public DialogueGraph dialogue;
    public TextMeshProUGUI spokenLine;
    public Transform responsePanel;
    public GameObject buttonPrefab;
    public GameObject panel;


    // Start is called before the first frame update
    void Start()
    {
        ClearButtons();
        foreach (Node item in dialogue.nodes)
        {
            if (item is EntryNode)
            {
                dialogue.current = item.GetPort("exit").Connection.node as CoreNodeBase;
                break;
            }
        }

        parseNode();
    }

    private void parseNode()
    {
        if(dialogue.current == null || spokenLine == null)
        {
            return;
        }

        switch(dialogue.current.GetDialogueType)
        {
            case "NPC":
                spokenLine.text = (dialogue.current as DialogueNodeBase).dialogueSpoken;
                SpawnResponseButtons();
                break;
            case "Response":
                ClearButtons();
                NextNode("exit");
                break;
            case "ExitNode":
                StartCoroutine(DialogueClose());
                DialogueOver(true);
                break;
            case "FalseExit":
                MoveKey(false);
                StartCoroutine(DialogueClose());
                DialogueOver(true);
                break;
            case "TrueExit":
                MoveKey(true);
                StartCoroutine(DialogueClose());
                DialogueOver(true);
                break;
        }
    }

    public void NextNode(string fieldName)
    {
        foreach(NodePort port in dialogue.current.Ports)
        {
            if(port.fieldName == fieldName)
            {
                dialogue.current = port.Connection.node as CoreNodeBase;
                break;
            }
        }

        parseNode();
    }

    private void SpawnResponseButtons()
    {
        foreach (NodePort port in dialogue.current.Ports)
        {
            if(port.Connection == null || port.IsInput)
            {
                continue;
            }

            if(port.Connection.node is ResponseDialogue)
            {
                ResponseDialogue rd = port.Connection.node as ResponseDialogue;

                Button b = Instantiate(buttonPrefab, responsePanel).GetComponent<Button>();

                b.onClick.AddListener(() => NextNode(port.fieldName));
                b.GetComponentInChildren<TextMeshProUGUI>().text = rd.dialogueSpoken.ToString();
            }
            else if(port.Connection.node is ExitNode)
            {
                NextNode(port.fieldName);
            }
        }
    }

    private void ClearButtons()
    {
        Transform[] children = responsePanel.GetComponentsInChildren<Transform>();

        for (int i = children.Length -1; i > 0; i--)
        {
            if(children[i] != responsePanel)
            {
                Destroy(children[i].gameObject);
            }
        }
    }

    public void DialogueOver(bool dialogue)
    {
        if(dialogue == true && _secondaryQuest != null)
        {
            QuestManager.instance.StartQuest(_secondaryQuest);
        }
        else
        {
            Debug.Log("No Secondary Quest");
        }
    }

    public void MoveKey(bool exitBool)
    {
        if(exitBool == true)
        {
            GetComponent<HagglerScript>().MoveTrue();
        }
        else
        {
            return;
        }
    }

    private IEnumerator DialogueClose()
    {
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
    }
}
