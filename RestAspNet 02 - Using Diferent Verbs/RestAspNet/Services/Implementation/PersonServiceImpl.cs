﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestAspNet.Model;
using RestAspNet.Model.Context;

namespace RestAspNet.Services.Implementation
{
	public class PersonServiceImpl : IPersonService
	{

		private MySqlContext _context;
		public PersonServiceImpl(MySqlContext context)
		{
			_context = context;
		}


		public Person Create(Person person)
		{
			try
			{
				_context.Add(person);
				_context.SaveChanges();
			}
			catch(Exception ex)
			{
				throw ex;
			}

			return person;
		}

		public void Delete(long id)
		{

			var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
			try
			{
				if(result != null)
				{
					_context.Persons.Remove(result);
					_context.SaveChanges();
				}
				
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public List<Person> FindAll()
		{
			return _context.Persons.ToList();
		}

		public Person FindById(long id)
		{
			return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
		}

		public Person Update(Person person)
		{
			if (!Exist(person.Id)) return new Person();

			var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
			try
			{
				_context.Entry(result).CurrentValues.SetValues(person);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return person;
		}

		private bool Exist(long? id)
		{
			return _context.Persons.Any(p => p.Id.Equals(id));
		}
	}
}
