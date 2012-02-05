using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace katas.specs.PrettyPathPrint
{
    public static class VisitorExtensions
    {
        // this version allows us to use this method by passing in an anonymous block of code,
        // rather than having to create a visitor interface/class/delegate
        public static void visit_all_items_using<ItemToVisit>(this IEnumerable<ItemToVisit> all_items, Action<ItemToVisit> visitor)
        {
            foreach (var item_to_visit in all_items) visitor(item_to_visit);
        }

        public static void visit_all_items_using<ItemToVisit>(this IEnumerable<ItemToVisit> all_items, Visitor<ItemToVisit> visitor)
        {
            visit_all_items_using(all_items, visitor.process);
        }

        public static ReturnType get_the_result_of_visiting_all_items_with<ItemToVisit, ReturnType>(
            this IEnumerable<ItemToVisit> all_items, ValueReturningVisitor<ItemToVisit, ReturnType> visitor)
        {
            all_items.visit_all_items_using(visitor);
            return visitor.get_result();
        }
    }
}
