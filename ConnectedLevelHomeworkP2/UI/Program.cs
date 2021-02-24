using ConnectedLevelHomeworkP2.Data;

namespace ConnectedLevelHomeworkP2.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataAccess = new DataAccess();

            dataAccess.CreateTable();
        }
    }
}
