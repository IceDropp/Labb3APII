<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
<h1>API Documentation</h1>

<h2>GET /persons</h2>
<pre>
  [
  {
    "personId": 1,
    "firstName": "Anna",
    "lastName": "Johansson",
    "phoneNumber": 41687312
  },
  {
    "personId": 2,
    "firstName": "Carl",
    "lastName": "Clemence",
    "phoneNumber": 14793744
  },
  {
    "personId": 3,
    "firstName": "William",
    "lastName": "Jonson",
    "phoneNumber": 3579146
  },
  {
    "personId": 4,
    "firstName": "Frida",
    "lastName": "Andersson",
    "phoneNumber": 6485219
  },
  {
    "personId": 5,
    "firstName": Donald
    "lastName": "Trump",
    "phoneNumber": 7951349
  },
  {
    "personId": 6,
    "firstName": "Eoin",
    "lastName": "Colfer",
    "phoneNumber": 3872541
  },
  {
    "personId": 7,
    "firstName": "Fredrik",
    "lastName": "Aronsson",
    "phoneNumber": 633789452
  }
]
  </pre>
GET /persons/{personId}/interests</h2>
<pre>
    [
  {
    "interestId": 1,
    "title": "Jaga",
    "description": "Jagar i Småland"
  }
]
  </pre>
GET /persons/{personId}/links</h2>
  <pre>
    [
  {
    "interestId": 1,
    "title": "Jaga",
    "description": "Jagar i Småland"
  }
]  
  </pre>
POST/person/{personId}/interests/{interestId}</h2>
  <pre>
    {
  "personInterestId": 4987,
  "fkPersonId": 2,
  "persons": {
    "personId": 2,
    "firstName": "Carl",
    "lastName": "Clemence",
    "phoneNumber": 14793744
  },
  "fkInterestId": 3,
  "interests": {
    "interestId": 3,
    "title": "Måla",
    "description": "Målar hemma"
  }
  </pre>
POST/persons/{personId}/interests/{interestId}/links</h2>
<pre>
  {
  "linkId": 5468,
  "url": "https://www.svt.se/",
  "fkInterestId": 4,
  "interests": {
    "interestId": 4,
    "title": "Tv",
    "description": "Spelar in ett Tv program"
  }
  }
  </pre>
