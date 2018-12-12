using DayOut.Data;
using DayOut.Models;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace DayOut.Class
{
    public static class Geocode
    {

        public static double latitude;
        public static double longtitude;
        public static bool isValidLocation = false;

        public static bool GetLongLat(Customer customer, string state)
        {
            string url = SetUrl(customer, state);
            string result = GET(url);
            JObject o = JObject.Parse(result);
            var lat = o["results"][0]["geometry"]["location"]["lat"];
            var lng = o["results"][0]["geometry"]["location"]["lng"];
            var locType = o["results"][0]["geometry"]["location_type"];
            string locResult = locType.ToString();
            if (locResult == "ROOFTOP")
            {
                isValidLocation = true;
            }
            latitude = Convert.ToDouble(lat);
            longtitude = Convert.ToDouble(lng);
            return true;
            try
            {

            }
            catch
            {
                return false;
            }
        }
        private static string SetUrl (Customer customer, string statePass)
        {
            string address = ReplaceSpaceWithPlus(customer.StreetAddress);
            string city = ReplaceSpaceWithPlus(customer.City);
            string state = statePass;
            string urlGeocode = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address + ",+" + city + ",+" + state + "&key=AIzaSyCm51Yofz7jCEmtkvN4mFady9iETRhqm_s";
            return urlGeocode;
        }
        private static string ReplaceSpaceWithPlus(string address)
        {
            address = address.Replace(" ", "+");
            return address;
        }
        private static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
    }
}