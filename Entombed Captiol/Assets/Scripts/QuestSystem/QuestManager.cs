using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class QuestStatus
{
    public Quest questData;

    public Dictionary<int, Quest.Status> objectiveStatuses;

    public QuestStatus(Quest questData)
    {
        this.questData = questData;

        objectiveStatuses = new Dictionary<int, Quest.Status>();

        for (int i = 0; i < questData.objectives.Count; i += 1)
        {
            var objectiveData = questData.objectives[i];

            objectiveStatuses[i] = objectiveData.initialStatus;
        }
    }

    public Quest.Status questStatus
    {
        get
        {
            for (int i = 0; i < questData.objectives.Count; i += 1)
            {
                var objectiveData = questData.objectives[i];

                if (objectiveData.optional)
                    continue;

                var objectiveStatus = objectiveStatuses[i];

                if (objectiveStatus == Quest.Status.Failed)
                {
                    return Quest.Status.Failed;
                }
                else if (objectiveStatus != Quest.Status.Complete)
                {
                    return Quest.Status.Incomplete;
                }
            }
            return Quest.Status.Complete;

        }
    }

    public override string ToString()
    {
        var stringBuilder = new System.Text.StringBuilder();

        for (int i = 0; i < questData.objectives.Count; i += 1)
        {
            var objectiveData = questData.objectives[i];
            var objectiveStatus = objectiveStatuses[i];

            if (objectiveData.visible == false && objectiveStatus == Quest.Status.Incomplete)
            {
                continue;
            }

            if (objectiveData.optional)
            {
                stringBuilder.AppendFormat("{0} - Optional - {1}\n", objectiveData.name, objectiveStatus.ToString());
            }
            else
            {
                stringBuilder.AppendFormat("{0} - {1}\n", objectiveData.name, objectiveStatus.ToString());
            }
        }

        stringBuilder.AppendLine();
        //stringBuilder.AppendFormat("Status: {0}", this.questStatus.ToString());

        return stringBuilder.ToString();
    }
}
public class QuestManager : MonoBehaviour
{
    [SerializeField] Quest startingQuest = null;

    [SerializeField] TextMeshProUGUI objectiveSummary = null;

    [SerializeField] TextMeshProUGUI questName = null;

    public static QuestManager instance;

    public QuestStatus activeQuest;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        if (startingQuest != null)
        {
            StartQuest(startingQuest);
        }
    }

    public void StartQuest(Quest quest)
    {
        activeQuest = new QuestStatus(quest);

        UpdateObjectiveSummaryText();

        Debug.LogFormat("Started quest {0}", activeQuest.questData.name);
    }

    void UpdateObjectiveSummaryText()
    {
        string label;

        if (activeQuest == null)
        {
            label = "No active quests.";
        }
        else
        {
            label = activeQuest.ToString();
        }

        objectiveSummary.text = label;
        questName.text = activeQuest.questData.name;
    }

    public void UpdateObjectiveStatus(Quest quest, int objectiveNumber, Quest.Status status)
    {
        if (activeQuest == null)
        {
            Debug.LogError("Tried to set an objective status, but no quest is active!");
            return;
        }

        if (activeQuest.questData != quest)
        {
            Debug.LogWarningFormat("Tried to set an objective status for quest {0}, but this is not the active quest.", quest.questName);
            return;
        }

        activeQuest.objectiveStatuses[objectiveNumber] = status;

        UpdateObjectiveSummaryText();
    }
}
