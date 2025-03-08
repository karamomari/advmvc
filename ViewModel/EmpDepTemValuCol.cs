namespace AdvProject.ViewModel
{
    public class EmpDepTemValuCol
    {
        public string EmpName { set; get; }
        public string DepName { set; get; }
        public string Color { set; get; }
        //public List<int> Values { set; get; }
        public List<int> Values { get; set; } = new List<int>();
        public string msg { set; get; }

    }
}
