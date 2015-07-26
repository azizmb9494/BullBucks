using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Bullbucks
{
	public static class Api
	{
		private static HttpClient _Client { get; set; }
	
		static Api() {
			_Client = new HttpClient ();
			_Client.BaseAddress = new Uri ("https://usfweb3.usf.edu/BullBucks/");
		}

		/// <summary>
		/// Get BullBuck$ Balance.
		/// </summary>
		/// <returns>Balance.</returns>
		/// <param name="card">Card Number.</param>
		/// <param name="uid">U Number.</param>
		async public static Task<decimal> GetBalance(string card, string uid) {
			FormUrlEncodedContent form = new FormUrlEncodedContent (new[] {
				new KeyValuePair<string, string> ("CardNumber", card),
				new KeyValuePair<string, string> ("UID", uid),
				new KeyValuePair<string, string> ("CMD", "Access My Account Info")
			});

			try {
				var resp = await _Client.PostAsync("default.asp", form);
				form = new FormUrlEncodedContent (new [] { new KeyValuePair<string, string> ("CMD", "I Agree") });
				resp = await _Client.PostAsync ("BBAgree.asp", form);

				string html = await resp.Content.ReadAsStringAsync ();
				html = html.Between("<p align=\"center\"><font size=\"5\" color=\"#00573C\"><b>The current balance on your Bull Buck$ Account is", "</b></font></p>").Trim().Remove(0, 1);

				decimal balance = 0;
				if (!String.IsNullOrEmpty(html)) {
					if (decimal.TryParse(html, out balance)) {
						return balance;
					} else {
						return -100;
					}
				} else {
					return -200;
				}
			} catch {
				return -300;
			}
		}


		/// <summary>
		/// Get BullBuck$ Balance.
		/// </summary>
		/// <returns>Balance.</returns>
		/// <param name="card">Card Number.</param>
		/// <param name="first">First Name.</param>
		/// <param name="last">Last Name.</param>
		async public static Task<decimal> GetBalance(string card, string first, string last) {
			FormUrlEncodedContent form = new FormUrlEncodedContent (new[] {
				new KeyValuePair<string, string> ("CardNumber", card),
				new KeyValuePair<string, string> ("CardFirstName", first.ToUpper()),
				new KeyValuePair<string, string> ("CardLastName", last.ToUpper()),
				new KeyValuePair<string, string> ("CMD", "Access My Account Info")
			});

			try {
				var resp = await _Client.PostAsync("default.asp", form);
				form = new FormUrlEncodedContent (new [] { new KeyValuePair<string, string> ("CMD", "I Agree") });
				resp = await _Client.PostAsync ("BBAgree.asp", form);
				string html = await resp.Content.ReadAsStringAsync ();
				html = html.Between("<p align=\"center\"><font size=\"5\" color=\"#00573C\"><b>The current balance on your Bull Buck$ Account is", "</b></font></p>").Trim().Remove(0, 1);
				decimal balance = 0;
				if (!String.IsNullOrEmpty(html)) {
					if (decimal.TryParse(html, out balance)) {
						return balance;
					} else {
						return -100;
					}
				} else {
					return -200;
				}
			} catch {
				return -300;
			}
		}

		private static string Between(this string value, string a, string b)
		{
			int posA = value.IndexOf(a);
			int posB = value.LastIndexOf(b);
			if (posA == -1)
			{
				return null;
			}

			if (posB == -1)
			{
				return null;
			}

			int adjustedPosA = posA + a.Length;
			if (adjustedPosA >= posB)
			{
				return null;
			}
			return value.Substring(adjustedPosA, posB - adjustedPosA);
		}

	}
}

