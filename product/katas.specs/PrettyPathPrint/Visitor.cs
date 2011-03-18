namespace katas.specs.PrettyPathPrint
{
    public interface Visitor<ItemToVisit>
    {
        void process(ItemToVisit item);
    }
}
