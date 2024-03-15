namespace TaskLanit
{
    public abstract class ACar
    {
        public readonly string m_CarMake;
        public string m_ColorCar { get; set; }
        public ACar(string _ColorCar, string _CarMake)
        {
            m_ColorCar = _ColorCar;
            m_CarMake = _CarMake;
        }
    }
    public class Mercedes : ACar
    {
        public Mercedes(string _ColorCar) : base(_ColorCar, "Mercedes")
        {

        }
    }
    public class BMV : ACar
    {
        public BMV(string _ColorCar) : base(_ColorCar, "BMV")
        {
            
        }
    }
}
