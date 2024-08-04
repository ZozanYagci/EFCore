namespace CustomLinq
{
    public static class LinqExtensions
    {
        public static IEnumerable<UserModel> MyWhere_EvenId(this IEnumerable<UserModel> users)
        {
            var result= new List<UserModel>();
            foreach(var user in users)
            {
                if (user.Id % 2 == 0)
                    result.Add(user);
            }
            return result;
        }

        public static IEnumerable<UserModel> MyWhere_GmailUsers(this IEnumerable<UserModel> users)
        {
            var result = new List<UserModel>();
            foreach (var user in users)
            {
                if (user.EmailAddress.EndsWith("gmail.com"))
                    result.Add(user);
            }
            return result;
        }


        public static UserModel MyFirstOrDefault(this IEnumerable<UserModel> users)
        {
            foreach(var user in users)
            {
                return user;
            }
            return null;
        }

        public static List<UserModel> MyToList(this IEnumerable<UserModel> users)
        {
            var result= new List<UserModel>();
            foreach (var user in users)
            {
                result.Add(user);
            }
            return result;
        }
    }
}
