[System.Serializable]
public class CollectableItem {
    public int seeds;
    public int worms;

    public CollectableItem()
    {
        seeds = 0;
        worms = 0;
    }

    public bool HasItems()
    {
        if (seeds > 0 || worms > 0)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Adds amount c1 and c2 together
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    /// <returns></returns>
    public static CollectableItem Add(CollectableItem c1, CollectableItem c2)
    {
        CollectableItem c = new CollectableItem();
        c.seeds = c1.seeds + c2.seeds;
        c.worms = c1.worms + c2.worms;
        return c;
    }

    /// <summary>
    /// Subtracts amount c2 from c1
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    /// <returns></returns>
    public static CollectableItem Subtract(CollectableItem c1, CollectableItem c2)
    {
        CollectableItem c = new CollectableItem();
        c.seeds = c1.seeds - c2.seeds;
        c.worms = c1.worms - c2.worms;
        return c;
    }

    public static bool HasEnoughResources(CollectableItem inventory, CollectableItem subtractAmount)
    {
        if (subtractAmount.seeds > inventory.seeds)
            return false;
        if (subtractAmount.worms > inventory.worms)
            return false;

        return true;
    }
}
