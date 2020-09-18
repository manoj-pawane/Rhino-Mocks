namespace BasicMockTestingDemo
{
    public interface IDataSource
    {
        bool DataAvailable();

        int[] GetData();
    }
}
