using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListView : MonoBehaviour
{


    private List<ListItem> _ListItems = new List<ListItem>();
    public List<ListItem> ListItems
    {
        get { return _ListItems; }
        set
        {
            _ListItems = value;
            RefreshListItemPositions();
        }
        
    }

    GameObject ContentContainer;
    GameObject ScrollView;
    GameObject Viewport;
    GameObject HorizontalScrollbar;
    GameObject VerticalScrollbar;

    // Start is called before the first frame update
    void Awake()
    {
        List<Transform> children = new List<Transform>(GetComponentsInChildren<Transform>());
        ScrollView = children.Find((child) => { return child.name == "Scroll View"; }).gameObject;
        Viewport = children.Find((child) => { return child.name == "Viewport"; }).gameObject;
        ContentContainer = children.Find((child) => { return child.name == "Content"; }).gameObject;
        VerticalScrollbar = children.Find((child) => { return child.name == "Scrollbar Vertical"; }).gameObject;
    }
    private void Start()
    {
       
    }

    public void AddItem(ListItem item)        
    {
        item.transform.SetParent(ContentContainer.transform, false);
        ListItems = new List<ListItem>(ContentContainer.GetComponentsInChildren<ListItem>());
    }
    public void RemoveItem(ListItem item)
    {
        Destroy(item);
        ListItems = new List<ListItem>(ContentContainer.GetComponentsInChildren<ListItem>());
    }
    public void SetItems(List<ListItem> items)
    {
        foreach (ListItem listItem in _ListItems)
        {
            Destroy(listItem);
        }

        foreach (ListItem item in items)
        {
            item.transform.SetParent(ContentContainer.transform, false);
        }
        ListItems = new List<ListItem>(ContentContainer.GetComponentsInChildren<ListItem>());
    }
    private void RefreshListItemPositions()
    {
        foreach (ListItem listItem in ListItems)
        {
            RectTransform rectTransform = listItem.GetComponent<RectTransform>();
            float height = rectTransform.rect.height;
            int index = ListItems.IndexOf(listItem);
            float yPos = (-height / 2) - (height * index);
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, yPos, rectTransform.localPosition.z);
            ContentContainer.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (height * index));
        }
    }

    public T InstantiateListItemPrefab<T>(string prefabName) where T : ListItem
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        T listItemInstance = Instantiate<GameObject>(prefab) as T;
        listItemInstance.Init();
        return listItemInstance;
    }


}
