This API is deployed as an App Service on Microsoft Azure.
It has two similar endpoints: _calculate_ and _calculate_async_. The only difference is that _calculate_async_ supports asynchronous execution and requires authentication.

Below are the URLs and the request object you can use to test them via Postman:
GET https://redsailtechnologiespaymentprocessingmoduleapi20250727021314.azurewebsites.net/daily_totals/calculate

GET https://redsailtechnologiespaymentprocessingmoduleapi20250727021314.azurewebsites.net/daily_totals/calculate_async

[
   {
      "Amount":"1",
      "Currency":"USD",
      "Timestamp":"2025-07-25T12:12:12"
   },
   {
      "Amount":"2",
      "Currency":"USD",
      "Timestamp":"2025-07-25T11:11:11"
   },
   {
      "Amount":"3",
      "Currency":"USD",
      "Timestamp":"2025-07-26T10:10:10"
   },
   {
      "Amount":"4",
      "Currency":"USD",
      "Timestamp":"2025-07-26T09:00:00"
   },
   {
      "Amount":"5",
      "Currency":"EUR",
      "Timestamp":"2025-07-26T12:12:12"
   },
   {
      "Amount":"6",
      "Currency":"EUR",
      "Timestamp":"2025-07-26T11:11:11"
   },
   {
      "Amount":"7",
      "Currency":"EUR",
      "Timestamp":"2025-07-25T10:10:10"
   },
   {
      "Amount":"8",
      "Currency":"EUR",
      "Timestamp":"2025-07-25T09:00:00"
   }
]

To obtain the token:
POST https://login.microsoftonline.com/acc07c8f-5675-4983-b505-e15cd2ac7a5d/oauth2/v2.0/token
Content Type: x-www-form-urlencoded

client_id:f9bd3d07-b3f5-4da0-9a38-95f205caf765
scope:api://f9bd3d07-b3f5-4da0-9a38-95f205caf765/.default
client_secret:FmZ8Q~dCCveKyPxZsZ3hn6HrAJAdiNcwgXf9BcD.
grant_type:client_credentials
