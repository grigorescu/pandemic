using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Pandemic
{
    public class Map
    {
        
        private class CityData
        {
            private int[] diseases;
            private bool station = false;

            public CityData()
            {
                diseases =  new int[4];
                diseases[(int) DiseaseColor.BLACK] = 0;
                diseases[(int) DiseaseColor.BLUE] = 0;
                diseases[(int) DiseaseColor.YELLOW] = 0;
                diseases[(int) DiseaseColor.ORANGE] = 0;
            }

            public CityData(CityData other)
            {
                diseases = new int[4];
                diseases[(int)DiseaseColor.BLACK] = other.diseases[(int)DiseaseColor.BLACK];
                diseases[(int)DiseaseColor.BLUE] = other.diseases[(int)DiseaseColor.BLUE];
                diseases[(int)DiseaseColor.YELLOW] = other.diseases[(int)DiseaseColor.YELLOW];
                diseases[(int)DiseaseColor.ORANGE] = other.diseases[(int)DiseaseColor.ORANGE];
                station = other.station;
            }

            public int disease(DiseaseColor color)
            {
                return diseases[(int) color];
            }

            public bool hasStation()
            {
                return station;
            }

            public CityData addDisease(DiseaseColor color)
            {
                CityData result = new CityData(this);
                Debug.Assert(diseases[(int)color] < 3);
                result.diseases[(int)color]++;
                return result;
            }

        }

        private Dictionary<City, CityData> cities;
        int _outbreakCount = 0;

        public int outbreakCount
        {
            get { return _outbreakCount; }
        }

        public Map()
        {
            cities = new Dictionary<City, CityData>();
        }

        public Map(Map oldMap)
        {
            cities = new Dictionary<City, CityData>(oldMap.cities);
            _outbreakCount = oldMap.outbreakCount;
        }

        //dangerous...modifies the Map
        public Map addDisease(City c)
        {
            Map result = new Map(this);
            DiseaseColor color = c.color;
            if (result.cities[c].disease(color) < 3)
            {
                result.cities[c] = result.cities[c].addDisease(color);

            } else {
                //outbreak
                List<City> outbreaks = new List<City>();
                outbreaks.Add(c);
                List<City> toEvaluate = new List<City>();
                toEvaluate.AddRange(c.adjacent);
                while(toEvaluate.Count != 0) 
                {
                    City current = toEvaluate.ElementAt(0);
                    toEvaluate.RemoveAt(0);
                    if (outbreaks.Contains(current))
                        continue;
                    if (result.cities[current].disease(color) < 3)
                    {
                        result.cities[current] = result.cities[current].addDisease(color);
                    }
                    else
                    {
                        toEvaluate.AddRange(current.adjacent);
                        outbreaks.Add(current);
                    }

                }
                result._outbreakCount += outbreaks.Count;
            }
            
            return result;
        }

        public int diseaseLevel(City city, DiseaseColor color)
        {
            return cities[city].disease(color);
        }

        public City addCity(String name, DiseaseColor color)
        {
            City city = new City(name, color);
            cities[city] = new CityData();

            return city;
        }

    }
}
