namespace BasicMockTestingDemo
{
    public class Controller
    {
        public IDataSource DataSource { get; set; }
        public int[] Data { get; set; }

        public void Process()
        {
            if (this.DataSource.DataAvailable())
            {
                this.Data = this.DataSource.GetData();
            }
        }


        static void Main(string[] args)
        {

        }

    }
}
