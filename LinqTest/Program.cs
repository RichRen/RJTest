using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static IEnumerable<Person> personList = new List<Person>() {
                new Person() { Id =1,Name="rj1"},
                new Person() { Id =2,Name="rj2"},
                new Person() { Id =3,Name="rj3"},
                new Person() { Id =1,Name="rj2"},
                new Person() { Id =1,Name="r3"},
            };

        static void Main(string[] args)
        {
            //ComparerTest();

            PredicateTest();

            Console.Read();
        }

        public static void ComparerTest()
        {
            var equalityComparer1 = Equality<Person>.CreateComparer(p => p.Id);
            var equalityComparer4 = Equality<Person>.CreateComparer(p => p.Name, StringComparer.CurrentCultureIgnoreCase);

            

            var list = personList.Distinct().ToList();

            list = personList.Distinct(equalityComparer1).ToList();

            var comparer1 = Comparison<Person>.CreateComparer(p => p.Id);
            var comparer4 = Comparison<Person>.CreateComparer(p => p.Name, StringComparer.CurrentCultureIgnoreCase);
        }

        public static void PredicateTest()
        {
            Expression<Func<Person, bool>> condition1 = item => item.Id < 3;
            Expression<Func<Person, bool>> condition2 = item => item.Name=="rj2";

            Expression<Func<Person, bool>> condition3 = condition1.Or(condition2);

            var list = personList.AsQueryable().Where(condition3).ToList();
        }
    }
}
