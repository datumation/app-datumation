using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Datumation.Models
{
    public class UsState 
    {
        public string StateName {get;set;}
        public string StateAbbr {get;set;}
        public List<UsState> States {get {
            return new List<UsState>(){ 
              new UsState() { StateAbbr = "AL",StateName = "Alabama"},
new UsState() { StateAbbr = "AK",StateName = "Alaska"},
new UsState() { StateAbbr = "AZ",StateName = "Arizona"},
new UsState() { StateAbbr = "AR",StateName = "Arkansas"},
new UsState() { StateAbbr = "CA",StateName = "California"},
new UsState() { StateAbbr = "CO",StateName = "Colorado"},
new UsState() { StateAbbr = "CT",StateName = "Connecticut"},
new UsState() { StateAbbr = "DE",StateName = "Delaware"},
new UsState() { StateAbbr = "DC",StateName = "District of Columbia"},
new UsState() { StateAbbr = "FL",StateName = "Florida"},
new UsState() { StateAbbr = "GA",StateName = "Georgia"},
new UsState() { StateAbbr = "HI",StateName = "Hawaii"},
new UsState() { StateAbbr = "ID",StateName = "Idaho"},
new UsState() { StateAbbr = "IL",StateName = "Illinois"},
new UsState() { StateAbbr = "IN",StateName = "Indiana"},
new UsState() { StateAbbr = "IA",StateName = "Iowa"},
new UsState() { StateAbbr = "KS",StateName = "Kansas"},
new UsState() { StateAbbr = "KY",StateName = "Kentucky"},
new UsState() { StateAbbr = "LA",StateName = "Louisiana"},
new UsState() { StateAbbr = "ME",StateName = "Maine"},
new UsState() { StateAbbr = "MT",StateName = "Montana"},
new UsState() { StateAbbr = "NE",StateName = "Nebraska"},
new UsState() { StateAbbr = "NV",StateName = "Nevada"},
new UsState() { StateAbbr = "NH",StateName = "New Hampshire"},
new UsState() { StateAbbr = "NJ",StateName = "New Jersey"},
new UsState() { StateAbbr = "NM",StateName = "New Mexico"},
new UsState() { StateAbbr = "NY",StateName = "New York"},
new UsState() { StateAbbr = "NC",StateName = "North Carolina"},
new UsState() { StateAbbr = "ND",StateName = "North Dakota"},
new UsState() { StateAbbr = "OH",StateName = "Ohio"},
new UsState() { StateAbbr = "OK",StateName = "Oklahoma"},
new UsState() { StateAbbr = "OR",StateName = "Oregon"},
new UsState() { StateAbbr = "MD",StateName = "Maryland"},
new UsState() { StateAbbr = "MA",StateName = "Massachusetts"},
new UsState() { StateAbbr = "MI",StateName = "Michigan"},
new UsState() { StateAbbr = "MN",StateName = "Minnesota"},
new UsState() { StateAbbr = "MS",StateName = "Mississippi"},
new UsState() { StateAbbr = "MO",StateName = "Missouri"},
new UsState() { StateAbbr = "PA",StateName = "Pennsylvania"},
new UsState() { StateAbbr = "RI",StateName = "Rhode Island"},
new UsState() { StateAbbr = "SC",StateName = "South Carolina"},
new UsState() { StateAbbr = "SD",StateName = "South Dakota"},
new UsState() { StateAbbr = "TN",StateName = "Tennessee"},
new UsState() { StateAbbr = "TX",StateName = "Texas"},
new UsState() { StateAbbr = "UT",StateName = "Utah"},
new UsState() { StateAbbr = "VT",StateName = "Vermont"},
new UsState() { StateAbbr = "VA",StateName = "Virginia"},
new UsState() { StateAbbr = "WA",StateName = "Washington"},
new UsState() { StateAbbr = "WV",StateName = "West Virginia"},
new UsState() { StateAbbr = "WI",StateName = "Wisconsin"},
new UsState() { StateAbbr = "WY",StateName = "Wyoming"}
            };
        }}
    }

}