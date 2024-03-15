using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace TaskLanit
{
    public abstract class ACarShowroom
    {
        public readonly int m_MaxCountCar;
        public readonly string m_Name;
        public Dictionary<string, List<ACar>> m_ListCar { get; set; }
        public ACarShowroom(int _MaxCountCar, string _name)
        {
            m_ListCar = new Dictionary<string, List<ACar>>();
            m_MaxCountCar = _MaxCountCar;
            m_Name = _name;
        }
        private void Init(string _key)
        {
            if (!m_ListCar.ContainsKey(_key))
            {
                m_ListCar.Add(_key, new List<ACar>());
            }
        }
        public int GetCarsCount(ACar _Car)
        {
            string key = $"{_Car.GetType().Name}_{_Car.m_ColorCar}";
            Init(key);
            return m_ListCar[key].Count;
        }
        public bool CheckCountCars(ACar _Car)
        {
            string key = $"{_Car.GetType().Name}_{_Car.m_ColorCar}";
            Init(key);

            int allCountCar = 0;
            foreach (var item in m_ListCar)
            {
                allCountCar += item.Value.Count;
            }
            if (allCountCar>=100)
            {
                return false;
            }
            return true;
        }
        public bool AddCar(ACar _Car)
        {
            string key = $"{_Car.GetType().Name}_{_Car.m_ColorCar}";
            Init(key);
            m_ListCar[key].Add(_Car);
            return true;
        }
    }
    public class CarShowroomGreen : ACarShowroom
    {
        public CarShowroomGreen(int _MaxCountCar) : base(_MaxCountCar,"Green")
        {

        }
    }
    public class CarShowroomBlue : ACarShowroom
    {
        public CarShowroomBlue(int _MaxCountCar) : base(_MaxCountCar, "Blue")
        {

        }
    }
}
