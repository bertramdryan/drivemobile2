﻿using DriveMobile.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DriveMobile.Models
{
    public class Manifest
    {
        public int DriverId { get; set; }
        public object PowerId { get; set; }
        public int DivisionId { get; set; }
        public int Status { get; set; }
        public DateTime EstimatedStartTime { get; set; }
        public bool IsRouteComplete { get; set; }
        public bool IsBeingDetained { get; set; }
        public int LoadTypeId { get; set; }
        public int PadCount { get; set; }
        public int StrapCount { get; set; }
        public int BarCount { get; set; }
        public int DeckingCount { get; set; }
        public bool NeedsBlocking { get; set; }
        public object TrailerNumber { get; set; }
        public List<Stop> Stops { get; set; }
        [IgnoreDataMember]
        public IList<StopGroup> StopGroups { get; set; }
        public int Id { get; set; }


        public static async Task<List<Manifest>> GetManifests()
        {
            List<Manifest> manifestList = new List<Manifest>();

            string url = string.Format(Constants.DRIVE_BASE_URL, Constants.MANIFEST + App.driver.UserId);
            string maxDate = JsonConvert.SerializeObject(new { });
            StringContent stringContent = new StringContent(maxDate, Encoding.UTF8, "application/json");

            var response = await App.driveClient.PostAsync(url, stringContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                manifestList = JsonConvert.DeserializeObject<List<Manifest>>(json);

                foreach (Manifest manifest in manifestList)
                {
                    manifest.StopGroups = CreateStopGroups(manifest);
                }

                return manifestList;
            }

            return manifestList;

        }

        private static List<StopGroup> CreateStopGroups(Manifest manifest)
        {
            List<StopGroup> stopGroups = new List<StopGroup>();

            // outter iterator
            int stopGroupIterator = 0;

            while (stopGroupIterator < manifest.Stops.Count)
            {
                Stop stop = manifest.Stops[stopGroupIterator];

                Location tempLocation = new Location()
                {
                    LocationName = stop.LocationName,
                    Address1 = stop.StreetAddress1,
                    Address2 = stop.StreetAddress2,
                    City = stop.City,
                    State = stop.State,
                    Zip = stop.ZipCode,
                    PhoneNumber = stop.LocationPhone,
                    Lat = stop.Latitude,
                    Lng = stop.Longitude,

                };

                DockInfo tempDockInfo = new DockInfo()
                {
                    DockName = stop.DockName,
                    DockEmail = stop.DockEmail,
                    DockPhone = stop.DockPhone,
                    DockNotes = stop.DockNotes,
                };

                TrailerInfo tempTrailerInfo = new TrailerInfo()
                {
                    TrailerId = stop.TrailerId,
                    TrailerName = stop.TrailerName
                };

                StopGroup stopGroup = new StopGroup()
                {
                    Location = tempLocation,
                    StopType = stop.StopTypeName,
                    StopTypeId = stop.StopTypeId,
                    DispatchLoadId = stop.DispatchLoadId,
                    DockInto = tempDockInfo,
                    TrailerInfo = tempTrailerInfo,
                    EstimatedStartTime = stop.EarliestArrival,
                    LatestStartTime = stop.LatestArrival,
                    Stops = new List<Stop>()
                };

                // Adding currently compared stop.
                stopGroup.Stops.Add(stop);

                // Do the next stop(s) match? Good, adding it to this stop group.
                // sorry, future dev for such a crappy implimentation of this.
                // "I am not a smart man, but I know what MVC is." -Sr. Developer Gump
                // This is not an MVC app, it is just funny. 

                if (stopGroupIterator < manifest.Stops.Count)
                {
                    // inner iterator
                    int increment = 1;

                    // iterates until their isn't match. 
                    bool canIterate = true;

                    // skips a bunch of typing by extracting the stop here. 
                    // hope you understand. Lazy Dev. 
                    Stop stop2 = manifest.Stops[stopGroupIterator + increment];

                    while (canIterate && increment + stopGroupIterator < manifest.Stops.Count)
                    {
                        if (MatchLocationInfo(stop, stop2))
                        {
                            stopGroup.Stops.Add(stop2);
                            increment++;
                        }
                        else
                        {
                            canIterate = false;
                            stopGroupIterator += increment;
                        }
                    }

                }
            }
            return stopGroups;
        }

        private static bool MatchLocationInfo(Stop stop1, Stop stop2)
        {
            if (!string.IsNullOrEmpty(stop1.StreetAddress1)
                && !string.IsNullOrEmpty(stop2.StreetAddress1))
            {
                string streetAddress1 = stop1.StreetAddress1.Split(' ')[0];

                string streetAddress2 = stop2.StreetAddress1.Split(' ')[0];

                if (stop2.LocationName.Equals(stop1.LocationName) &&
              streetAddress1.Equals(streetAddress2) &&
              stop1.StopTypeId == stop2.StopTypeId)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
