﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CarManager.Data;

namespace CarManager.Web.Controllers
{
	public class CarAsyncController : ApiController
	{
		private static readonly ICarRepository _carRepository = new DbCarRepository();

		public IEnumerable<Car> Get()
		{
			return _carRepository.GetAll();
		}

		public Task<Car> GetAsync(int id)
		{
			Debug.WriteLine(HttpContext.Current.Request.Url);
			return Task.Factory.StartNew(() => _carRepository.Get(id));
		}

		public void Put(Car car)
		{
			_carRepository.Update(car);
		}

		public void Delete(int id)
		{
			_carRepository.Delete(id);
		}

		public HttpResponseMessage Post(Car car)
		{
			_carRepository.Add(car);
			var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Created);
			httpResponseMessage.Headers.Location = new Uri(Request.RequestUri.ToString()
				+ "/" + car.Id.ToString());
			return httpResponseMessage;
		}

	}
}