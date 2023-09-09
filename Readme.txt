First you should add-migration and update-database to create a Db in your local SqlServer, then it will seed some data to tables by fluent api. 
-------
You can use these datas as an input for 'CalculateCongestionTax' method =>

** Hint **
 VehicleType enum :

        Car=0,
        Motorcycle=1,
        Tractor=2,
        Emergency=3,
        Diplomat=4,
        Foreign=5,
        Military=6
---------------- 
some examples for test the method =>
{
    "VehicleType": 1,
    "CityName": "Gothenburg",
    "DateStrings": [
      "2023-08-21T08:00:00",
      "2023-08-21T17:30:00",
        "2023-08-21T18:28:00"
    ]
 }

 {
    "VehicleType": 1,
    "CityName": "Gothenburg",
    "DateStrings": [
      "2023-08-21T08:00:00",
      "2023-08-21T12:30:00",
      "2023-08-21T17:30:00"
    ]
 }

 {
    "VehicleType": 3,
    "CityName": "Gothenburg",
    "DateStrings": [
      "2023-08-21T08:00:00",
      "2023-08-21T12:30:00",
      "2023-08-21T17:30:00"
    ]
 }

 {
    "VehicleType": 2,
    "CityName": "Stockholm",
    "DateStrings": [
      "2023-08-21T08:00:00",
      "2023-08-21T12:30:00",
      "2023-08-21T17:30:00"
    ]
 }

 {
    "VehicleType": 1,
    "CityName": "Stockholm",
    "DateStrings": [
      "2023-08-21T08:00:00",
      "2023-08-21T17:30:00",
        "2023-08-21T18:28:00"
    ]
 }
------
