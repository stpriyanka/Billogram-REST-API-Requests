﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http;
namespace Billogram_api_calls
{
	static class Program
	{
		static void Main(string[] args)
		{
			RunAsync_fetch_single_billogram().Wait();
		}

		/// <summary>
		/// GET
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_get_single_customer()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			const int customerId = 1;

			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.GetAsync("https://sandbox.billogram.com/api/v2/customer/" + customerId);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();
		}

		//404
		private static async Task RunAsync_Connection_to_api()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var client = new HttpClient();


			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.GetAsync("https://sandbox.billogram.com/api/v2/");

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();

			Console.WriteLine(responseBody);

			Console.ReadLine();

		}

		/// <summary>
		/// POST
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_create_a_customer()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var Data = new
			{
				customer_no = 8,
				name = "customer8",
				company_type = "individual",
				org_no = "",
				contact = new
				{
					name = "customer8",
					email = "stpriyanka2011@gmail.com"
				},
				address = new
				{
					street_address = "Armegatan",
					zipcode = 17171,
					city = "kista",
					country = "SE"
				},
			};


			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.PostAsJsonAsync("https://sandbox.billogram.com/api/v2/customer/", Data);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();

			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);


			Console.ReadLine();
		}

		/// <summary>
		/// POST {save in draft}
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_create_billogram_as_Unattested_state()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var data = new
			{
				customer = new
				{
					customer_no = 1
				},
				items = new[]
				{
     				new { count = 1, discount = 0, item_no = 1 }
				}
			};


			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.PostAsJsonAsync("https://sandbox.billogram.com/api/v2/billogram/", data);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();

		}

		private static async Task RunAsync_send_billogram()
		{

			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var data = new
			{
				method = "Email"
			};

			const string unattestedBillogramId = "49sEHHY";

			var queryString = unattestedBillogramId + "/command/send/";
			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.PostAsJsonAsync("https://sandbox.billogram.com/api/v2/billogram/" + queryString, data);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();

		}






		/// <summary>
		/// GET
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_fetch_single_billogram()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			const string billogramId = "QPsMRVY";


			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.GetAsync("https://sandbox.billogram.com/api/v2/billogram/" + billogramId);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();

			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();

		}


		/// <summary>
		/// GET
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_fetch_list_of_billograms()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			const string baseUrl = "https://sandbox.billogram.com/api/v2/billogram/";

			var query = HttpUtility.ParseQueryString(string.Empty);
			query["page"] = "1";
			query["page_size"] = "50";
			string queryString = query.ToString();

			HttpResponseMessage response = await client.GetAsync(baseUrl + "?" + queryString);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();

		}


		/// <summary>
		/// GET
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_get_billograms_list_by_unpaid_state()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			const string baseUrl = "https://sandbox.billogram.com/api/v2/billogram/";

			var query = HttpUtility.ParseQueryString(string.Empty);
			query["page"] = "1";
			query["page_size"] = "50";
			query["filter_type"] = "field";
			query["filter_field"] = "state";
			query["filter_value"] = "unpaid";
			string queryString = query.ToString();

			HttpResponseMessage response = await client.GetAsync(baseUrl + "?" + queryString);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();

		}

		/// <summary>
		/// GET
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_get_billograms_list_by_unattested_state()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			const string baseUrl = "https://sandbox.billogram.com/api/v2/billogram/";

			var query = HttpUtility.ParseQueryString(string.Empty);
			query["page"] = "1";
			query["page_size"] = "50";
			query["filter_type"] = "field";
			query["filter_field"] = "state";
			query["filter_value"] = "unattested";
			string queryString = query.ToString();

			HttpResponseMessage response = await client.GetAsync(baseUrl + "?" + queryString);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();

		}

		/// <summary>
		/// GET
		/// </summary>
		/// <returns></returns>
		private static async Task RunAsync_get_billograms_list_by_customerNo()
		{
			const string authUser = "3331-0lgWtglW";
			const string authKey = "761b54eb59aeca57e1a8cfa16fe67693";

			var client = new HttpClient();

			var byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			const string baseUrl = "https://sandbox.billogram.com/api/v2/billogram/";

			var query = HttpUtility.ParseQueryString(string.Empty);
			query["page"] = "1";
			query["page_size"] = "50";
			query["filter_type"] = "field";
			query["filter_field"] = "customer:customer_no";
			query["filter_value"] = "1";
			string queryString = query.ToString();

			HttpResponseMessage response = await client.GetAsync(baseUrl + "?" + queryString);

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			IDictionary<string, JToken> rates = (JObject)json["data"];

			Dictionary<string, dynamic> dictionary = rates.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

			Console.WriteLine(json);

			Console.ReadLine();

		}


	}
}
