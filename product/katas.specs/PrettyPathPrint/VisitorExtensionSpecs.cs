 using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using Machine.Specifications;
 using developwithpassion.specifications.rhino;
 using developwithpassion.specifications.extensions;

namespace katas.specs.PrettyPathPrint
{   
    public class VisitorExtensionSpecs
    {
        public abstract class concern : Observes
        {
        
        }

        [Subject(typeof(VisitorExtensions))]
        public class when_visiting_all_of_the_items_in_an_iterator_with_a_visitor : concern
        {
            Establish c = () =>
                                      {
                                          all_items = Enumerable.Range(1, 100).Select(x => x.ToString()).ToList();
                                          visitor = an<Visitor<string>>();
                                      };

            private Because b = () => VisitorExtensions.visit_all_items_using(all_items, visitor);

            It should_process_each_item_through_the_visitor
                = () =>
                  all_items.each(x => visitor.received(y => y.process(x)));


            static IEnumerable<string> all_items;
            static Visitor<string> visitor;
        }
    }

    internal class ValueReturningVisitor<T, T1>
    {
    }
}
