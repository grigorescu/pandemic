using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class Map
    {

        List<City> cities;


        public Map()
        {
            cities = new List<City>();
        }

        public int addDisease(City c)
        {
            if (c.addDisease())
            {
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
                    if (current.addDisease(c.color))
                    {
                        toEvaluate.AddRange(current.adjacent);
                        outbreaks.Add(current);
                    }

                }
                return outbreaks.Count;
            }
            
            return 0;
        }

        public City addCity(String name, DiseaseColor color)
        {
            City city = new City(name, color);
            cities.Add(city);

            return city;
        }

    }
}
