using UnityEngine.UI;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public ScriptablePartsUnion[] scriptablePartsUnions;

    public Image iconRepresentative;
    public Image missingParts1;
    public Image missingParts2;

    internal void UnionParts(int icon)
    {
        iconRepresentative.sprite = scriptablePartsUnions[icon].imageRepresentative;

        missingParts1.sprite = scriptablePartsUnions[icon].iconMissingParts1;
        missingParts2.sprite = scriptablePartsUnions[icon].iconMissingParts2;
    }
}
