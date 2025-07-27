This API is deployed as an App Service on Microsoft Azure.

Below is the URL and the request object you can use to test it via Postman.
GET https://redsailtechnologiespaymentprocessingmoduleapi20250727021314.azurewebsites.net/daily_totals/calculate

GET https://redsailtechnologiespaymentprocessingmoduleapi20250727021314.azurewebsites.net/daily_totals/calculate_async

[
		{
			"Amount"    : "1",
			"Currency"  : "USD",
			"Timestamp" : "2025-07-25T12:12:12"
		},
		{
			"Amount"    : "2",
			"Currency"  : "USD",
			"Timestamp" : "2025-07-25T11:11:11"
		},
		{
			"Amount"    : "3",
			"Currency"  : "USD",
			"Timestamp" : "2025-07-26T10:10:10"
		},
		{
			"Amount"    : "4",
			"Currency"  : "USD",
			"Timestamp" : "2025-07-26T09:00:00"
		},
		{
			"Amount"    : "5",
			"Currency"  : "EUR",
			"Timestamp" : "2025-07-26T12:12:12"
		},
		{
			"Amount"    : "6",
			"Currency"  : "EUR",
			"Timestamp" : "2025-07-26T11:11:11"
		},
		{
			"Amount"    : "7",
			"Currency"  : "EUR",
			"Timestamp" : "2025-07-25T10:10:10"
		},
		{
			"Amount"    : "8",
			"Currency"  : "EUR",
			"Timestamp" : "2025-07-25T09:00:00"
		}
]
