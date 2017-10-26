using System;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using RestSharp;

namespace Yandex.Api
{
    public class YandexApi
    {
        public info GetRegionInfo(string regionCode)
        {
            var restClient = new RestClient("https://export.yandex.com");

            var request = new RestRequest($"bar/reginfo.xml?region={regionCode}", Method.GET);
            request.RequestFormat = DataFormat.Xml;
            request.RootElement = "info";

            var restResponse = restClient.Execute<info>(request);

            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            info obj = null;
            try
            {
                strReader = new StringReader(restResponse.Content);
                serializer = new XmlSerializer(typeof(info));
                xmlReader = new XmlTextReader(strReader);
                obj = (info) serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                //Handle Exception Code
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;

            //return restResponse.Data;
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class info
    {
        private string langField;

        private infoRegion regionField;

        private object trafficField;

        private infoWeather weatherField;

        /// <remarks/>
        public infoRegion region
        {
            get { return regionField; }
            set { regionField = value; }
        }

        /// <remarks/>
        public object traffic
        {
            get { return trafficField; }
            set { trafficField = value; }
        }

        /// <remarks/>
        public infoWeather weather
        {
            get { return weatherField; }
            set { weatherField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string lang
        {
            get { return langField; }
            set { langField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoRegion
    {
        private ushort idField;

        private decimal latField;

        private decimal lonField;

        private string titleField;

        private byte zoomField;

        /// <remarks/>
        public string title
        {
            get { return titleField; }
            set { titleField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public ushort id
        {
            get { return idField; }
            set { idField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte zoom
        {
            get { return zoomField; }
            set { zoomField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal lat
        {
            get { return latField; }
            set { latField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal lon
        {
            get { return lonField; }
            set { lonField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeather
    {
        private byte climateField;

        private infoWeatherDay dayField;

        private byte regionField;

        private string sourceField;

        private infoWeatherUrl urlField;

        /// <remarks/>
        public string source
        {
            get { return sourceField; }
            set { sourceField = value; }
        }

        /// <remarks/>
        public infoWeatherDay day
        {
            get { return dayField; }
            set { dayField = value; }
        }

        /// <remarks/>
        public infoWeatherUrl url
        {
            get { return urlField; }
            set { urlField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte climate
        {
            get { return climateField; }
            set { climateField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte region
        {
            get { return regionField; }
            set { regionField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDay
    {
        private string countryField;

        private infoWeatherDayDate dateField;

        private infoWeatherDayDay_part[] day_partField;

        private string daytimeField;

        private byte summertimeField;

        private string sun_riseField;

        private string sunsetField;

        private string time_zoneField;

        private string titleField;

        private infoWeatherDayToday todayField;

        /// <remarks/>
        public string title
        {
            get { return titleField; }
            set { titleField = value; }
        }

        /// <remarks/>
        public string country
        {
            get { return countryField; }
            set { countryField = value; }
        }

        /// <remarks/>
        public string time_zone
        {
            get { return time_zoneField; }
            set { time_zoneField = value; }
        }

        /// <remarks/>
        [XmlElement("summer-time")]
        public byte summertime
        {
            get { return summertimeField; }
            set { summertimeField = value; }
        }

        /// <remarks/>
        public string sun_rise
        {
            get { return sun_riseField; }
            set { sun_riseField = value; }
        }

        /// <remarks/>
        public string sunset
        {
            get { return sunsetField; }
            set { sunsetField = value; }
        }

        /// <remarks/>
        public string daytime
        {
            get { return daytimeField; }
            set { daytimeField = value; }
        }

        /// <remarks/>
        public infoWeatherDayDate date
        {
            get { return dateField; }
            set { dateField = value; }
        }

        /// <remarks/>
        [XmlElement("day_part")]
        public infoWeatherDayDay_part[] day_part
        {
            get { return day_partField; }
            set { day_partField = value; }
        }

        /// <remarks/>
        public infoWeatherDayToday today
        {
            get { return todayField; }
            set { todayField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDate
    {
        private DateTime dateField;

        private infoWeatherDayDateDay dayField;

        private string daytimeField;

        private infoWeatherDayDateMonth monthField;

        private ushort yearField;

        /// <remarks/>
        public infoWeatherDayDateDay day
        {
            get { return dayField; }
            set { dayField = value; }
        }

        /// <remarks/>
        public infoWeatherDayDateMonth month
        {
            get { return monthField; }
            set { monthField = value; }
        }

        /// <remarks/>
        public ushort year
        {
            get { return yearField; }
            set { yearField = value; }
        }

        /// <remarks/>
        public string daytime
        {
            get { return daytimeField; }
            set { daytimeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public DateTime date
        {
            get { return dateField; }
            set { dateField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDateDay
    {
        private byte valueField;

        private string weekdayField;

        /// <remarks/>
        [XmlAttribute]
        public string weekday
        {
            get { return weekdayField; }
            set { weekdayField = value; }
        }

        /// <remarks/>
        [XmlText]
        public byte Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDateMonth
    {
        private string nameField;

        private byte valueField;

        /// <remarks/>
        [XmlAttribute]
        public string name
        {
            get { return nameField; }
            set { nameField = value; }
        }

        /// <remarks/>
        [XmlText]
        public byte Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDay_part
    {
        private byte dampnessField;

        private bool dampnessFieldSpecified;

        private ushort hectopascalField;

        private bool hectopascalFieldSpecified;

        private byte image_numberField;

        private bool image_numberFieldSpecified;

        private string imageField;

        private infoWeatherDayDay_partImagev2 imagev2Field;

        private infoWeatherDayDay_partImagev3 imagev3Field;

        private string observation_timeField;

        private DateTime observationField;

        private bool observationFieldSpecified;

        private ushort pressureField;

        private bool pressureFieldSpecified;

        private infoWeatherDayDay_partTemperature_from temperature_fromField;

        private infoWeatherDayDay_partTemperature_to temperature_toField;

        private infoWeatherDayDay_partTemperature temperatureField;

        private string time_zoneField;

        private ushort torrField;

        private bool torrFieldSpecified;

        private string typeField;

        private byte typeidField;

        private string weather_codeField;

        private string weather_typeField;

        private infoWeatherDayDay_partWind_direction wind_directionField;

        private byte wind_speedField;

        private bool wind_speedFieldSpecified;

        /// <remarks/>
        public string weather_type
        {
            get { return weather_typeField; }
            set { weather_typeField = value; }
        }

        /// <remarks/>
        public string weather_code
        {
            get { return weather_codeField; }
            set { weather_codeField = value; }
        }

        /// <remarks/>
        public string image
        {
            get { return imageField; }
            set { imageField = value; }
        }

        /// <remarks/>
        [XmlElement("image-v2")]
        public infoWeatherDayDay_partImagev2 imagev2
        {
            get { return imagev2Field; }
            set { imagev2Field = value; }
        }

        /// <remarks/>
        [XmlElement("image-v3")]
        public infoWeatherDayDay_partImagev3 imagev3
        {
            get { return imagev3Field; }
            set { imagev3Field = value; }
        }

        /// <remarks/>
        public infoWeatherDayDay_partTemperature_from temperature_from
        {
            get { return temperature_fromField; }
            set { temperature_fromField = value; }
        }

        /// <remarks/>
        public infoWeatherDayDay_partTemperature_to temperature_to
        {
            get { return temperature_toField; }
            set { temperature_toField = value; }
        }

        /// <remarks/>
        public byte image_number
        {
            get { return image_numberField; }
            set { image_numberField = value; }
        }

        /// <remarks/>
        [XmlIgnore]
        public bool image_numberSpecified
        {
            get { return image_numberFieldSpecified; }
            set { image_numberFieldSpecified = value; }
        }

        /// <remarks/>
        public byte wind_speed
        {
            get { return wind_speedField; }
            set { wind_speedField = value; }
        }

        /// <remarks/>
        [XmlIgnore]
        public bool wind_speedSpecified
        {
            get { return wind_speedFieldSpecified; }
            set { wind_speedFieldSpecified = value; }
        }

        /// <remarks/>
        public infoWeatherDayDay_partWind_direction wind_direction
        {
            get { return wind_directionField; }
            set { wind_directionField = value; }
        }

        /// <remarks/>
        public byte dampness
        {
            get { return dampnessField; }
            set { dampnessField = value; }
        }

        /// <remarks/>
        [XmlIgnore]
        public bool dampnessSpecified
        {
            get { return dampnessFieldSpecified; }
            set { dampnessFieldSpecified = value; }
        }

        /// <remarks/>
        public ushort hectopascal
        {
            get { return hectopascalField; }
            set { hectopascalField = value; }
        }

        /// <remarks/>
        [XmlIgnore]
        public bool hectopascalSpecified
        {
            get { return hectopascalFieldSpecified; }
            set { hectopascalFieldSpecified = value; }
        }

        /// <remarks/>
        public ushort torr
        {
            get { return torrField; }
            set { torrField = value; }
        }

        /// <remarks/>
        [XmlIgnore]
        public bool torrSpecified
        {
            get { return torrFieldSpecified; }
            set { torrFieldSpecified = value; }
        }

        /// <remarks/>
        public ushort pressure
        {
            get { return pressureField; }
            set { pressureField = value; }
        }

        /// <remarks/>
        [XmlIgnore]
        public bool pressureSpecified
        {
            get { return pressureFieldSpecified; }
            set { pressureFieldSpecified = value; }
        }

        /// <remarks/>
        public infoWeatherDayDay_partTemperature temperature
        {
            get { return temperatureField; }
            set { temperatureField = value; }
        }

        /// <remarks/>
        public string time_zone
        {
            get { return time_zoneField; }
            set { time_zoneField = value; }
        }

        /// <remarks/>
        public string observation_time
        {
            get { return observation_timeField; }
            set { observation_timeField = value; }
        }

        /// <remarks/>
        public DateTime observation
        {
            get { return observationField; }
            set { observationField = value; }
        }

        /// <remarks/>
        [XmlIgnore]
        public bool observationSpecified
        {
            get { return observationFieldSpecified; }
            set { observationFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte typeid
        {
            get { return typeidField; }
            set { typeidField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string type
        {
            get { return typeField; }
            set { typeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDay_partImagev2
    {
        private string sizeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute]
        public string size
        {
            get { return sizeField; }
            set { sizeField = value; }
        }

        /// <remarks/>
        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDay_partImagev3
    {
        private byte sizeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute]
        public byte size
        {
            get { return sizeField; }
            set { sizeField = value; }
        }

        /// <remarks/>
        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDay_partTemperature_from
    {
        private string class_nameField;

        private string colorField;

        private sbyte valueField;

        /// <remarks/>
        [XmlAttribute]
        public string class_name
        {
            get { return class_nameField; }
            set { class_nameField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }

        /// <remarks/>
        [XmlText]
        public sbyte Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDay_partTemperature_to
    {
        private string class_nameField;

        private string colorField;

        private sbyte valueField;

        /// <remarks/>
        [XmlAttribute]
        public string class_name
        {
            get { return class_nameField; }
            set { class_nameField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }

        /// <remarks/>
        [XmlText]
        public sbyte Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDay_partWind_direction
    {
        private string idField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute]
        public string id
        {
            get { return idField; }
            set { idField = value; }
        }

        /// <remarks/>
        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayDay_partTemperature
    {
        private string class_nameField;

        private string colorField;

        private sbyte valueField;

        /// <remarks/>
        [XmlAttribute]
        public string class_name
        {
            get { return class_nameField; }
            set { class_nameField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }

        /// <remarks/>
        [XmlText]
        public sbyte Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayToday
    {
        private infoWeatherDayTodayTemperature temperatureField;

        /// <remarks/>
        public infoWeatherDayTodayTemperature temperature
        {
            get { return temperatureField; }
            set { temperatureField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherDayTodayTemperature
    {
        private string class_nameField;

        private string colorField;

        private sbyte valueField;

        /// <remarks/>
        [XmlAttribute]
        public string class_name
        {
            get { return class_nameField; }
            set { class_nameField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string color
        {
            get { return colorField; }
            set { colorField = value; }
        }

        /// <remarks/>
        [XmlText]
        public sbyte Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class infoWeatherUrl
    {
        private string slugField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute]
        public string slug
        {
            get { return slugField; }
            set { slugField = value; }
        }

        /// <remarks/>
        [XmlText]
        public string Value
        {
            get { return valueField; }
            set { valueField = value; }
        }
    }
}