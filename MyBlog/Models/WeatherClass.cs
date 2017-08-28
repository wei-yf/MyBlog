using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class WeatherClass
    {
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
    public class Weather
    {
        /// <summary>
        /// 小雨
        /// </summary>
        public string dat_condition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dat_low_temperature { get; set; }
        /// <summary>
        /// 南风
        /// </summary>
        public string wind_direction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int high_temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int low_temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tomorrow_weather_icon_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dat_high_temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tomorrow_aqi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int wind_level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dat_weather_icon_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string update_time { get; set; }
        /// <summary>
        /// 雷阵雨
        /// </summary>
        public string day_condition { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string night_condition { get; set; }
        /// <summary>
        /// 优
        /// </summary>
        public string tomorrow_quality_level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int moji_city_id { get; set; }
        /// <summary>
        /// 青岛
        /// </summary>
        public string city_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int aqi { get; set; }
        /// <summary>
        /// 多云转小雨
        /// </summary>
        public string tomorrow_condition { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string current_condition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tomorrow_low_temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string weather_icon_id { get; set; }
        /// <summary>
        /// 优
        /// </summary>
        public string quality_level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tomorrow_high_temperature { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Weather weather { get; set; }
        /// <summary>
        /// 青岛
        /// </summary>
        public string city { get; set; }
    }
}