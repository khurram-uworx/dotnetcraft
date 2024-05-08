                                // implicit using (project setting)
                                // global usings
using Core;                     // explicit using
using static System.Console;    // using static methods

Person? p = NullableHelper.MayBePerson();
//p!.LastName   null forgiving
// check for null
if (null != p)
    WriteLine(p.FirstName);

WriteLine("Finished, press Enter to exit");
ReadLine();
