namespace katas.specs.PrettyPathPrint 
{
    public interface ValueReturningVisitor<ItemToVisit, ReturnType> : Visitor<ItemToVisit>
    {
        ReturnType get_result();
    }
}