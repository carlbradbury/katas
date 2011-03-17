
using System;
using System.IO;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using katas.PrettyPathPrint;
using Machine.Specifications;

namespace katas.specs.PrettyPathPrint
{
    
    class PrettyPathPrinterSpecs
    {

        public abstract class concern : Observes<PrettyPathPrinter>
        {
        }

        [Subject(typeof(PrettyPathPrinter))]
        public class when_printing_path_with_depth_of_one :concern
        {
            private Establish e = () =>
                                      {
                                          path = @"C:\Program Files";
                                      };
            
            Because b = () =>
                result = sut.print(path);

            It should_contain_one_newline_character = () =>
                result.ShouldContain(Environment.NewLine);

            static string result;
            static string path;
        }

        [Subject(typeof(PrettyPathPrinter))]
        public class when_path_does_not_exist : concern
        {
            private Establish e = () =>
            {
                path = "xxx";
            };
            Because b = () =>
                           catch_exception(() => sut.print(path));

            It should_throw_a_security_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();

            static string result;
            static string path;
        }
    }
}
