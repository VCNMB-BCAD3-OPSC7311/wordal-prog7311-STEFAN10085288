namespace ICE_1__words_API
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Password { get; set; }
        public string ImgUrl { get; set; }


       public User() { }


        public User(string id, string name, decimal password, string imgUrl)
        {
            Id = id;
            Name = name;
            Password = password;
            ImgUrl = imgUrl;
        }
    }

    


}
