namespace AnimalServiceTest
{
    public class UnitSqlAccount
    {
        [Fact]
        public void FindAccount()
        {
            User user = new("Test", "Test");
            user.Login();

            Assert.Equal(14, user.ToID());
        }
    }
}