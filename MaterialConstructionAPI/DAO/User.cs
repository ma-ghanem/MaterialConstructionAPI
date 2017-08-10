using System.Data;

namespace MaterialConstructionAPI.DAO
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static User Create(IDataRecord record)
        {
            return new User
            {
                Id = (int)record["user_id"],
                Name = (string)record["user_name"]
            };
        }
    }
}