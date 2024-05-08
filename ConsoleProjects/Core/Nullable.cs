namespace Core
{
    class Person
    {
        public string? FirstName { get; }
        public string? LastName { get; }
        public int Age { get; } // Nullable<int>

        public Person(string firstName, string lastName) =>
          (FirstName, LastName) = (firstName, lastName); // too soon ?

        public void DoSomething() { /* we want it blank */ }
    }

    static class NullableHelper
    {
        public static Person? MayBePerson() // return Person?
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
