using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestAspNet.Model;

namespace RestAspNet.Services.Implementation
{
	public class PersonServiceImpl : IPersonService
	{
		private volatile int count;

		public Person Create(Person person)
		{
			return person;
		}

		public void Delete(long id)
		{
			

		}

		public List<Person> FindAll()
		{
			List<Person> people = new List<Person>();
			for(int i = 0; i < 8; i++)
			{
				Person person = MockPerson(i);
				people.Add(person);
			}

			return people;
		}

		private Person MockPerson(int i)
		{
			return new Person
			{
				Id = IncrementedAndGet(),
				FirstName = "Amanda",
				LastName = "Nunes",
				Address = "São Paulo",
				Gender = "Femer"

			};
		}

		private long IncrementedAndGet()
		{
			return Interlocked.Increment(ref count);
		}

		public Person FindById(long id)
		{
			return new Person {
				Id = 1,
				FirstName = "Amanda",
				LastName = "Nunes",
				Address = "São Paulo",
				Gender = "Femer"
				
			};
		}

		public Person Update(Person person)
		{
			return person;
		}
	}
}
