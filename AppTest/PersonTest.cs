using IntegrationAndUnitTesting.Entities;
using System;
using System.Collections;
using System.Xml.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppTest
{
    public class Classfixture
    {
        public Person person => new Person();
    }
    public class PersonTest:IClassFixture<Classfixture>
    {
        private readonly Classfixture _classfixture;
        private readonly ITestOutputHelper _outputHelper;

        public PersonTest(Classfixture classfixture,ITestOutputHelper outputHelper)
        {
            this._classfixture = classfixture;
            this._outputHelper = outputHelper;
            _outputHelper.WriteLine("constractclass");
     
        }

        [Fact]
        public void Test1()
        {

            var person1 = _classfixture.person.FirstName="milad";

            Assert.Equal(person1, "milad",ignoreCase:false);

        }
        [Fact]
        public void Test2()
        {

            Assert.IsType(typeof(Person), _classfixture.person);

        }
       

        [Theory]
        [InlineData("milad")]
        [InlineData("Milad")]
        [InlineData("MilaD")]
        public void Test4(string name)
        {
            var person1 = _classfixture.person.FirstName = name;

            Assert.Equal(person1, "milad", ignoreCase: true);
         

        }
      
        [Theory]
        [MemberData(nameof(Data))]
       
        public void Test5(string name,string lastname)
        {
            var person02=new Person() { FirstName = name,LastName = lastname };

           Assert.Equal(person02.FirstName,"ali" );    


        }

        public static IEnumerable<object[]> Data =>
          new List<object[]>
          {
            new object[] {"ali","vahidi"}

          };

        [Theory]
        [ClassData(typeof(PersonTestData))]

        public void Test6(Person person)
        {
 

            Assert.Equal(person.FirstName, "ali",ignoreCase:true);


        }

        public static IEnumerable<object[]> Data2 =>
          new List<object[]>
          {
            new object[] { new Person() { FirstName = "ali", LastName = "hamidi" } }

          };
    }

    public class PersonTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Person() { FirstName = "ali", LastName = "hamidi" } };
            yield return new object[] { new Person() { FirstName = "Ali", LastName = "hamidi" } };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


}