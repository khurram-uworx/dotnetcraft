using System.Collections.Generic;

namespace UWorx.DotNet
{
    public class Person
    {
        public string? FirstName { get; } // nullable reference type
        public string? LastName { get; } // nullable reference type
        public int Age { get; } // We can have int? :: nullable value types

        public Person(string firstName, string lastName) =>
          (FirstName, LastName) = (firstName, lastName); // too soon ? value tuples syntax can be used normally

        public void DoSomething() { /* we want it blank */ }
    }

    public static class NullableHelper
    {
        public static Person? MayBePerson() // return Person? (nullable reference type)
        {
            return null; // treat cs8603 warnings as well
        }

        public static string[] NullableCollection()
        {
            var list = new List<string?>();
            
            list.Add("Lahore");
            list.Add(null);
            #nullable disable
            //var person = MayBePerson();
            //string name = person?.FirstName;
            list.Add(MayBePerson().FirstName);

            return list.ToArray(); //why we should not do toarray here?
        }
    }
}
